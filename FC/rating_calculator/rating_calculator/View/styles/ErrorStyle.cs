using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rating_calculator.View.styles
{
	class ErrorStyle
	{
		public void BackBtn(Button btn)
		{

			btn.Size = new Size(200, 30);
			btn.Location = new Point(100, 150);
			btn.Text = "VISSZA";
			btn.ForeColor = Color.FromArgb(247, 247, 247);
			btn.Font = new Font("Bauhaus 95", 10f, FontStyle.Bold);
			btn.Region = Region.FromHrgn(RoundedRect.CreateRoundRectRgn(0, 0, 200, 30, 15, 15));
			btn.TabStop = false;
			btn.FlatStyle = FlatStyle.Flat;
			btn.FlatAppearance.BorderSize = 0;
		}
		public void ErrorLb(Label username)
		{
			username.Text = "HIBA A BEJELENTKEZÉS SORÁN";
			username.Size = new Size(400, 30);
			username.Location = new Point(20, 50);
			username.ForeColor = Color.FromArgb(247, 247, 247);
			username.Font = new Font("Bauhaus 95", 15f, FontStyle.Bold);
		}
		public void ErrorTypeLb(Label username)
		{
			username.Text = "";
			username.Size = new Size(400, 30);
			username.Location = new Point(60, 100);
			username.ForeColor = Color.FromArgb(0, 194, 203);
			username.Font = new Font("Bauhaus 95", 13f, FontStyle.Italic);
		}

		public void ErrorForm(Form registrationForm)
		{
			registrationForm.Region = System.Drawing.Region.FromHrgn(RoundedRect.CreateRoundRectRgn(0, 0, 400, 200, 25, 25));
			registrationForm.FormBorderStyle = FormBorderStyle.None;
			registrationForm.BackColor = Color.FromArgb(21, 41, 50);
		}
	}
}
