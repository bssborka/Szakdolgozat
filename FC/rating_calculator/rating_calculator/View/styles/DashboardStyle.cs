using rating_calculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace rating_calculator.View.styles
{
	class DashboardStyle
	{
		readonly CountAverages ca = new CountAverages();
		readonly DashboardEvents de = new DashboardEvents();
		public void Title(Label title)
		{
			title.Text = "Felhasználók elégedettsége";
			title.Size = new Size(600, 50);
			title.Location = new Point(0, 20);
			title.ForeColor = Color.FromArgb(0, 194, 203);
			title.Font = new Font("Bauhaus 95", 30f, FontStyle.Bold);
		}

		public void UserLb(Label funcLb)
		{
			funcLb.Text = "Felhasználók száma:";
			funcLb.Size = new Size(300, 30);
			funcLb.Location = new Point(420, 320);
			funcLb.ForeColor = Color.FromArgb(0, 194, 203);
			funcLb.Font = new Font("Bauhaus 95", 20f, FontStyle.Regular);
		}
		public void UserCount(Label funcStat)
		{
			funcStat.Text = ca.NumberOfUsers.ToString();
			funcStat.Size = new Size(100, 30);
			funcStat.Location = new Point(550, 370);
			funcStat.ForeColor = Color.FromArgb(247, 247, 247);
			funcStat.Font = new Font("Bauhaus 95", 20f, FontStyle.Regular);
		}
		public void UserGrowthLb(Label funcLb)
		{
			funcLb.Text = "Felhasználók növekedése a legutóbbi mérés óta:";
			funcLb.Size = new Size(350, 80);
			funcLb.Location = new Point(420, 400);
			funcLb.ForeColor = Color.FromArgb(0, 194, 203);
			funcLb.Font = new Font("Bauhaus 95", 20f, FontStyle.Regular);
		}
		public void UserGrowth(Label funcStat)
		{
			funcStat.Text = ca.GrowthOfUsers.ToString();
			funcStat.Size = new Size(100, 30);
			funcStat.Location = new Point(550, 480);
			funcStat.ForeColor = Color.FromArgb(247, 247, 247);
			funcStat.Font = new Font("Bauhaus 95", 20f, FontStyle.Regular);
		}

		public void CommentBtn(Button btn)
		{
			btn.Size = new Size(400, 50);
			btn.Location = new Point(200, 250);
			btn.Text = "Megjegyzések megtekintése";
			btn.ForeColor = Color.FromArgb(247, 247, 247);
			btn.Font = new Font("Bauhaus 95", 15f, FontStyle.Bold);
			btn.Region = Region.FromHrgn(RoundedRect.CreateRoundRectRgn(0, 0, 400, 50, 15, 15));
			btn.TabStop = false;
			btn.FlatStyle = FlatStyle.Flat;
			btn.FlatAppearance.BorderSize = 0;
		}
		public void LogoutBtn(Label btn)
		{
			btn.Size = new Size(100, 50);
			btn.Location = new Point(740, 30);
			btn.Text = "\u2345";
			btn.ForeColor = Color.FromArgb(247, 247, 247);
			btn.Font = new Font("Bauhaus 95", 30f, FontStyle.Bold);
		}
		public void DashboardForm(Form dashboardForm)
		{
			dashboardForm.Region = System.Drawing.Region.FromHrgn(RoundedRect.CreateRoundRectRgn(0, 0, 800, 600, 25, 25));
			dashboardForm.Size = new Size(2000, 1800);
			dashboardForm.FormBorderStyle = FormBorderStyle.None;
			dashboardForm.BackColor = Color.FromArgb(21, 41, 50);
		}

		public void MinBtn(RoundedButton btn)
		{
			btn.Size = new Size(13, 13);
			btn.Location = new Point(750, 10);
			btn.ForeColor = Color.FromArgb(247, 247, 247);
			btn.BackColor = Color.FromArgb(0, 194, 203);
			btn.Font = new Font("Bauhaus 95", 10f, FontStyle.Bold);
			btn.TabStop = false;
			btn.FlatStyle = FlatStyle.Flat;
			btn.FlatAppearance.BorderSize = 0;
		}
		public void QuitBtn(RoundedButton btn)
		{
			btn.Size = new Size(13, 13);
			btn.Location = new Point(770, 10);
			btn.ForeColor = Color.FromArgb(247, 247, 247);
			btn.BackColor = Color.FromArgb(237, 0, 18);
			btn.Font = new Font("Bauhaus 95", 10f, FontStyle.Bold);
			btn.TabStop = false;
			btn.FlatStyle = FlatStyle.Flat;
			btn.FlatAppearance.BorderSize = 0;

		}

		public void CprGraph(CircularProgressBar.CircularProgressBar cpr)
		{
			cpr.Text = "Grafika \n" + ca.AverageGraphic.ToString();
			cpr.Font = new Font("Myriad Arabic", 18f, FontStyle.Bold);
			cpr.TextMargin = new Padding(2, 4, 0, 0);
			cpr.SubscriptText = "";
			cpr.SuperscriptText = "";
			cpr.Location = new Point(40, 80);
			cpr.Size = new Size(150, 150);
			cpr.Style = ProgressBarStyle.Continuous;
			cpr.Value = Convert.ToInt32(ca.AverageGraphic * 10);
			cpr.Minimum = 1;
			cpr.Maximum = 50;
			cpr.ProgressWidth = 6;
			cpr.ProgressColor = Color.FromArgb(0, 194, 203);
			cpr.OuterColor = Color.FromArgb(21, 41, 50);
			cpr.InnerColor = Color.FromArgb(11, 31, 40);
			cpr.ForeColor = Color.FromArgb(247, 247, 247);
			cpr.BackColor = Color.FromArgb(21, 41, 50);
		}

		public void CprFunc(CircularProgressBar.CircularProgressBar cpr)
		{
			cpr.Text = "Funkció \n" + ca.AverageFunctions.ToString();
			cpr.Font = new Font("Myriad Arabic", 18f, FontStyle.Bold);
			cpr.TextMargin = new Padding(2, 4, 0, 0);
			cpr.SubscriptText = "";
			cpr.SuperscriptText = "";
			cpr.Location = new Point(220, 80);
			cpr.Size = new Size(150, 150);
			cpr.Style = ProgressBarStyle.Continuous;
			cpr.Value = Convert.ToInt32(ca.AverageFunctions * 10);
			cpr.Minimum = 1;
			cpr.Maximum = 50;
			cpr.ProgressWidth = 6;
			cpr.ProgressColor = Color.FromArgb(0, 194, 203);
			cpr.OuterColor = Color.FromArgb(21, 41, 50);
			cpr.InnerColor = Color.FromArgb(11, 31, 40);
			cpr.ForeColor = Color.FromArgb(247, 247, 247);
			cpr.BackColor = Color.FromArgb(21, 41, 50);
		}

		public void CprExercises(CircularProgressBar.CircularProgressBar cpr)
		{
			cpr.Text = "Gyakorlat \n" + ca.AverageExercises.ToString();
			cpr.Font = new Font("Myriad Arabic", 18f, FontStyle.Bold);
			cpr.TextMargin = new Padding(2, 4, 0, 0);
			cpr.SubscriptText = "";
			cpr.SuperscriptText = "";
			cpr.Location = new Point(400, 80);
			cpr.Size = new Size(150, 150);
			cpr.Style = ProgressBarStyle.Continuous;
			cpr.Value = Convert.ToInt32(ca.AverageExercises * 10);
			cpr.Minimum = 1;
			cpr.Maximum = 50;
			cpr.ProgressWidth = 6;
			cpr.ProgressColor = Color.FromArgb(0, 194, 203);
			cpr.OuterColor = Color.FromArgb(21, 41, 50);
			cpr.InnerColor = Color.FromArgb(11, 31, 40);
			cpr.ForeColor = Color.FromArgb(247, 247, 247);
			cpr.BackColor = Color.FromArgb(21, 41, 50);
		}
		public void CprGroups(CircularProgressBar.CircularProgressBar cpr)
		{
			cpr.Text = "Csapat \n" + ca.AverageGroups.ToString();
			cpr.Font = new Font("Myriad Arabic", 18f, FontStyle.Bold);
			cpr.TextMargin = new Padding(2, 4, 0, 0);
			cpr.SubscriptText = "";
			cpr.SuperscriptText = "";
			cpr.Location = new Point(580, 80);
			cpr.Size = new Size(150, 150);
			cpr.Style = ProgressBarStyle.Continuous;
			cpr.Value = Convert.ToInt32(ca.AverageGroups * 10);
			cpr.Minimum = 1;
			cpr.Maximum = 50;
			cpr.ProgressWidth = 6;
			cpr.ProgressColor = Color.FromArgb(0, 194, 203);
			cpr.OuterColor = Color.FromArgb(21, 41, 50);
			cpr.InnerColor = Color.FromArgb(11, 31, 40);
			cpr.ForeColor = Color.FromArgb(247, 247, 247);
			cpr.BackColor = Color.FromArgb(21, 41, 50);
		}

		public void Graph(Chart g)
		{
			g.Location = new Point(20, 310);
			g.Size = new Size(350, 270);
			g.BackColor = Color.FromArgb(11, 31, 40);
			g.ForeColor = Color.FromArgb(247, 247, 247);
			g.Region = Region.FromHrgn(RoundedRect.CreateRoundRectRgn(0, 0, 350, 270, 15, 15));
			g.Font = new Font("Segoe Script", 18f, FontStyle.Bold);


			g.ChartAreas.Add("0");
			g.ChartAreas[0].AxisX.LineColor = Color.FromArgb(247, 247, 247);
			g.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(247, 247, 247);
			g.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.FromArgb(247, 247, 247);
			g.ChartAreas[0].AxisY.LineColor = Color.FromArgb(247, 247, 247);
			g.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(247, 247, 247);
			g.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.FromArgb(247, 247, 247);
			g.ChartAreas["0"].BackColor = Color.FromArgb(11, 31, 40);
			g.ChartAreas["0"].AxisX.MajorGrid.LineWidth = 0;
			g.ChartAreas["0"].AxisY.MajorGrid.LineWidth = 0;
			g.Series.Add("users");
			g.Series.Clear();
			g.Series.Add("Series1");
			g.Series[0].XValueMember = "date";
			g.Series[0].YValueMembers = "numberOfUsers";
			DataSet dataset = de.ChartData;
			g.DataSource = dataset;
			g.DataBind();

		}
	}
}
