using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ML.DataOperationsCatalog;
using static rating_calculator.ViewModel.predictions.SentimentData;

namespace rating_calculator.ViewModel.predictions
{
	class Predict
	{
		readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "review.txt");
		readonly static CommentEvents ce = new CommentEvents();
		readonly List<string> sentimentsList = ce.GetAllComment();
		public void RunPredictions()
		{
			MLContext mlContext = new MLContext();
			TrainTestData splitDataView = LoadData(mlContext);
			ITransformer model = BuildAndTrainModel(mlContext, splitDataView.TrainSet);
			Evaluate(mlContext, model, splitDataView.TestSet);
			UseModelWithBatchItems(mlContext, model);
		}

		private TrainTestData LoadData(MLContext mlContext)
		{
			IDataView dataView = mlContext.Data.LoadFromTextFile<SentimentData>(_dataPath, hasHeader: false);
			TrainTestData splitDataView = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
			return splitDataView;
		}
		private ITransformer BuildAndTrainModel(MLContext mlContext, IDataView splitTrainSet)
		{
			var estimator = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimentData.SentimentText)).Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));
			var model = estimator.Fit(splitTrainSet);
			return model;
		}
		private void Evaluate(MLContext mlContext, ITransformer model, IDataView splitTestSet)
		{
			IDataView predictions = model.Transform(splitTestSet);
			_ = mlContext.BinaryClassification.Evaluate(predictions, "Label");
		}
		public List<string> positive = new List<string>();
		public List<string> negative = new List<string>();
		public void UseModelWithBatchItems(MLContext mlContext, ITransformer model)
		{
			IEnumerable<SentimentData> sentiments;
			foreach (var comment in sentimentsList)
			{
				sentiments = new[] { new SentimentData { SentimentText = comment } };
				IDataView batchComments = mlContext.Data.LoadFromEnumerable(sentiments);

				IDataView predictions = model.Transform(batchComments);

				IEnumerable<SentimentPrediction> predictedResults = mlContext.Data.CreateEnumerable<SentimentPrediction>(predictions, reuseRowObject: false);
				foreach (var item in predictedResults.ToList())
				{
					if (item.Probability > 0.35)
					{
						if (item.Prediction == true)
						{
							positive.Add(item.SentimentText);
						}
						else if (item.Prediction == false)
						{
							negative.Add(item.SentimentText);
						}
					}
				}

			}
		}
	}
}
