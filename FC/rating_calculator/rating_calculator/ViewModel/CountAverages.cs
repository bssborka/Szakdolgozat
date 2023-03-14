using rating_calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rating_calculator.ViewModel
{
	class CountAverages
	{
		readonly ConnectToDB db = new ConnectToDB();
		public double AverageGraphic {
			get {
				if (!double.TryParse(db.Szamot_ad("SELECT AVG(review.graphics) FROM review"), out double graphics))
				{
					graphics = 0;
				}
				return graphics;
			}
		}

		public double AverageFunctions {
			get {
				if (!double.TryParse(db.Szamot_ad("SELECT AVG(review.functions) FROM review"), out double functions))
				{
					functions = 0;
				}
				return functions;
			}
		}

		public double AverageExercises {
			get {
				if (!double.TryParse(db.Szamot_ad("SELECT AVG(review.exercises) FROM review"), out double exercises))
				{
					exercises = 0;
				}
				return exercises;
			}
		}

		public double AverageGroups {
			get {
				if (!double.TryParse(db.Szamot_ad("SELECT AVG(review.groups) FROM review"), out double groups))
				{
					groups = 0;
				}
				return groups;
			}
		}

		public double NumberOfUsers {
			get {
				if (!double.TryParse(db.Szamot_ad("SELECT SUM(users.userId) FROM users"), out double users))
				{
					users = 0;
				}
				return users;
			}
		}

		public double GrowthOfUsers {
			get {
				double users = NumberOfUsers;
				if (!double.TryParse(db.Szamot_ad("SELECT numberOfUsers FROM graph WHERE date=(SELECT MAX(date) FROM graph)"), out double userCount))
				{
					userCount = 0;
				}
				return users - userCount;
			}
		}
	}
}
