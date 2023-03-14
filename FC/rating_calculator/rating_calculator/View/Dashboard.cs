using rating_calculator.View.styles;
using rating_calculator.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace rating_calculator.View
{
	public partial class Dashboard : Form
	{
		#region Elements
		private const int WM_NCHITTEST = 0x84;
		private const int HT_CLIENT = 0x1;
		private const int HT_CAPTION = 0x2;
		RoundedButton quitBtn, minBtn;
		readonly DashboardEvents de = new DashboardEvents();
		Label title, userLb, userCount, userGrowthLb, userGrowth, logoutBtn;
		CircularProgressBar.CircularProgressBar cpr, cpr2, cpr3, cpr4;
		Button commentBtn;
		Chart graph;

		internal RoundedButton QuitBtn { get => quitBtn; set => quitBtn = value; }
		internal RoundedButton MinBtn { get => minBtn; set => minBtn = value; }
		public Label Title { get => title; set => title = value; }
		public Label UserLb { get => userLb; set => userLb = value; }
		public Label UserCount { get => userCount; set => userCount = value; }
		public Label UserGrowthLb { get => userGrowthLb; set => userGrowthLb = value; }
		public Label UserGrowth { get => userGrowth; set => userGrowth = value; }
		public Label LogoutBtn { get => logoutBtn; set => logoutBtn = value; }
		public CircularProgressBar.CircularProgressBar Cpr { get => cpr; set => cpr = value; }
		public CircularProgressBar.CircularProgressBar Cpr2 { get => cpr2; set => cpr2 = value; }
		public CircularProgressBar.CircularProgressBar Cpr3 { get => cpr3; set => cpr3 = value; }
		public CircularProgressBar.CircularProgressBar Cpr4 { get => cpr4; set => cpr4 = value; }
		public Button CommentBtn { get => commentBtn; set => commentBtn = value; }
		public Chart Graph { get => graph; set => graph = value; }
		#endregion
		public Dashboard()
		{
			InitializeComponent();

			this.CenterToScreen();
			DashboardStyle();
			de.UpdateUserCount();
			LogoutBtn.Click += LogoutBtn_Click;
			CommentBtn.Click += CommentBtn_Click;
			QuitBtn.Click += QuitBtn_Click;
			MinBtn.Click += MinBtn_Click;
		}

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (m.Msg == WM_NCHITTEST)
				m.Result = (IntPtr)(HT_CAPTION);
		}

		private void MinBtn_Click(object sender, EventArgs e)
		{
			de.Minimize(this);
		}

		private void QuitBtn_Click(object sender, EventArgs e)
		{
			de.Quit();
		}

		private void CommentBtn_Click(object sender, EventArgs e)
		{
			this.Hide();
			de.Comments();
		}

		private void LogoutBtn_Click(object sender, EventArgs e)
		{
			this.Hide();
			de.Logout();
		}
		public void DashboardStyle()
		{
			DashboardStyle ds = new DashboardStyle();
			ds.DashboardForm(this);

			Title = new Label();
			ds.Title(Title);
			this.Controls.Add(Title);

			UserLb = new Label();
			ds.UserLb(UserLb);
			this.Controls.Add(UserLb);

			UserCount = new Label();
			ds.UserCount(UserCount);
			this.Controls.Add(UserCount);

			UserGrowthLb = new Label();
			ds.UserGrowthLb(UserGrowthLb);
			this.Controls.Add(UserGrowthLb);

			UserGrowth = new Label();
			ds.UserGrowth(UserGrowth);
			this.Controls.Add(UserGrowth);

			CommentBtn = new Button();
			ds.CommentBtn(CommentBtn);
			this.Controls.Add(CommentBtn);

			QuitBtn = new RoundedButton();
			ds.QuitBtn(QuitBtn);
			this.Controls.Add(QuitBtn);
			MinBtn = new RoundedButton();
			ds.MinBtn(MinBtn);
			this.Controls.Add(MinBtn);

			LogoutBtn = new Label();
			ds.LogoutBtn(LogoutBtn);
			this.Controls.Add(LogoutBtn);

			Cpr = new CircularProgressBar.CircularProgressBar();
			ds.CprGraph(Cpr);
			this.Controls.Add(Cpr);

			Cpr = new CircularProgressBar.CircularProgressBar();
			ds.CprGraph(Cpr);
			this.Controls.Add(Cpr);

			Cpr2 = new CircularProgressBar.CircularProgressBar();
			ds.CprFunc(Cpr2);
			this.Controls.Add(Cpr2);

			Cpr3 = new CircularProgressBar.CircularProgressBar();
			ds.CprExercises(Cpr3);
			this.Controls.Add(Cpr3);

			Cpr4 = new CircularProgressBar.CircularProgressBar();
			ds.CprGroups(Cpr4);
			this.Controls.Add(Cpr4);

			Graph = new Chart();
			ds.Graph(Graph);
			this.Controls.Add(Graph);
		}
	}
}
