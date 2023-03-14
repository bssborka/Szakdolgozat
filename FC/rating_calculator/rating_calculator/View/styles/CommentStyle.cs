using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rating_calculator.View.styles
{
	class CommentStyle
	{
		public void CommentForm(Form form)
		{
			form.Region = Region.FromHrgn(RoundedRect.CreateRoundRectRgn(0, 0, 800, 400, 25, 25));
			form.FormBorderStyle = FormBorderStyle.None;
			form.BackColor = Color.FromArgb(21, 41, 50);
		}
		public void CommentPositiveList(ListBox lb)
		{
			lb.Size = new Size(250, 250);
			lb.Location = new Point(20, 100);
			lb.ForeColor = Color.FromArgb(247, 247, 247);
			lb.BackColor = Color.FromArgb(21, 41, 50);
			lb.Font = new Font("Bauhaus 95", 15f, FontStyle.Bold);
			lb.BorderStyle = 0;
		}
		public void CommentNegativeList(ListBox lb)
		{
			lb.Size = new Size(250, 250);
			lb.Location = new Point(500, 100);
			lb.ForeColor = Color.FromArgb(247, 247, 247);
			lb.BackColor = Color.FromArgb(21, 41, 50);
			lb.Font = new Font("Bauhaus 95", 15f, FontStyle.Bold);
			lb.BorderStyle = 0;
		}
		public void BackButton(Label lb)
		{
			lb.Size = new Size(100, 100);
			lb.Location = new Point(750, 10);
			lb.Text = "\u21B6";
			lb.ForeColor = Color.FromArgb(247, 247, 247);
			lb.Font = new Font("Bauhaus 95", 20f, FontStyle.Bold);
			lb.Region = Region.FromHrgn(RoundedRect.CreateRoundRectRgn(0, 0, 50, 30, 15, 15));
		}

		public void CprUserSatisficationLb(CircularProgressBar.CircularProgressBar cpr)
		{
			cpr.Font = new Font("Myriad Arabic", 18f, FontStyle.Bold);
			cpr.TextMargin = new Padding(2, 4, 0, 0);
			cpr.SubscriptText = "";
			cpr.SuperscriptText = "";
			cpr.Location = new Point(300, 150);
			cpr.Size = new Size(150, 150);
			cpr.Style = ProgressBarStyle.Continuous;

			cpr.ProgressWidth = 6;
			cpr.ProgressColor = Color.FromArgb(0, 194, 203);
			cpr.OuterColor = Color.FromArgb(21, 41, 50);
			cpr.InnerColor = Color.FromArgb(11, 31, 40);
			cpr.ForeColor = Color.FromArgb(247, 247, 247);
			cpr.BackColor = Color.FromArgb(21, 41, 50);
		}
		public void PositiveLb(Label funcLb)
		{
			funcLb.Text = "Pozitív értékelések:";
			funcLb.Size = new Size(300, 30);
			funcLb.Location = new Point(10, 40);
			funcLb.ForeColor = Color.FromArgb(0, 194, 203);
			funcLb.Font = new Font("Bauhaus 95", 20f, FontStyle.Regular);
		}
		public void NegativeLb(Label funcLb)
		{
			funcLb.Text = "Negatív értékelések:";
			funcLb.Size = new Size(270, 30);
			funcLb.Location = new Point(500, 40);
			funcLb.ForeColor = Color.FromArgb(0, 194, 203);
			funcLb.Font = new Font("Bauhaus 95", 20f, FontStyle.Regular);
		}
		public void UserStatisficationLb(Label funcLb)
		{
			funcLb.Text = "Felhasználók\nmegelégedettsége \nszázalékosan:";
			funcLb.Size = new Size(300, 100);
			funcLb.Location = new Point(310, 70);
			funcLb.ForeColor = Color.FromArgb(247, 247, 247);
			funcLb.Font = new Font("Myriad Arabic", 15f, FontStyle.Italic);
		}
	}
}
