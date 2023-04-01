using rating_calculator.View.styles;
using rating_calculator.ViewModel;
using rating_calculator.ViewModel.predictions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rating_calculator.View
{
	public partial class Comment : Form
	{
		#region Elements
		private const int WM_NCHITTEST = 0x84;
		private const int HT_CLIENT = 0x1;
		private const int HT_CAPTION = 0x2;
		Label positiveLb, negativeLb, userSatisficationLb, backLb;
		ListBox commentPositiveLb, commentNegativeLb;
		CircularProgressBar.CircularProgressBar cpr;
		readonly CommentStyle cs = new CommentStyle();
		readonly CommentEvents ge = new CommentEvents();
		readonly Predict p = new Predict();
		public Label PositiveLb { get => positiveLb; set => positiveLb = value; }
		public Label NegativeLb { get => negativeLb; set => negativeLb = value; }
		public Label UserSatisficationLb { get => userSatisficationLb; set => userSatisficationLb = value; }
		public Label BackLb { get => backLb; set => backLb = value; }
		public ListBox CommentPositiveLb { get => commentPositiveLb; set => commentPositiveLb = value; }
		public ListBox CommentNegativeLb { get => commentNegativeLb; set => commentNegativeLb = value; }
		public CircularProgressBar.CircularProgressBar Cpr { get => cpr; set => cpr = value; }
		#endregion
		public Comment()
		{
			InitializeComponent();
			CommentStyle();
			Screen screen = Screen.FromControl(this);
			Rectangle workingArea = screen.WorkingArea;
			this.Location = new Point()
			{
				X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - 800) / 2),
				Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - 400) / 2)
			};			
			BackLb.Click += BackLb_Click;
		}
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (m.Msg == WM_NCHITTEST) m.Result = (IntPtr)(HT_CAPTION);
		}
		private void BackLb_Click(object sender, EventArgs e)
		{
			Dashboard d = new Dashboard();
			this.Hide();
			d.ShowDialog();
		}
		private void CommentStyle()
		{
			p.RunPredictions();

			cs.CommentForm(this);
			this.CenterToScreen();

			CommentPositiveLb = new ListBox();
			cs.CommentPositiveList(CommentPositiveLb);
			this.Controls.Add(CommentPositiveLb);
			CommentPositiveLb.Items.Clear();
			p.positive.RemoveAll(x => x == "" || x == " ");
			CommentPositiveLb.DataSource = p.positive;

			CommentNegativeLb = new ListBox();
			cs.CommentNegativeList(CommentNegativeLb);
			this.Controls.Add(CommentNegativeLb);
			CommentNegativeLb.Items.Clear();
			p.negative.RemoveAll(x => x == "" || x == " ");
			CommentNegativeLb.DataSource = p.negative;

			Cpr = new CircularProgressBar.CircularProgressBar();
			cs.CprUserSatisficationLb(Cpr);
			this.Controls.Add(Cpr);
			Cpr.Minimum = 1;
			Cpr.Maximum = 100;
			Cpr.Value = Convert.ToInt32(ge.UserStatisfication(p.positive.Count, p.negative.Count));
			Cpr.Text = ge.UserStatisfication(p.positive.Count, p.negative.Count).ToString() + "%";

			BackLb = new Label();
			cs.BackButton(BackLb);
			this.Controls.Add(BackLb);

			PositiveLb = new Label();
			cs.PositiveLb(PositiveLb);
			this.Controls.Add(PositiveLb);

			NegativeLb = new Label();
			cs.NegativeLb(NegativeLb);
			this.Controls.Add(NegativeLb);

			UserSatisficationLb = new Label();
			cs.UserStatisficationLb(UserSatisficationLb);
			this.Controls.Add(UserSatisficationLb);
		}
	}
}
