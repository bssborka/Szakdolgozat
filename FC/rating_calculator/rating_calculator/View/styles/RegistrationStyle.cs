using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rating_calculator.View.styles
{
	class RegistrationStyle
	{
		public void LoginBtn(Button btn)
		{

			btn.Size = new Size(150, 30);
			btn.Location = new Point(20, 400);
			btn.Text = "REGISZTRÁLOK";
			btn.ForeColor = Color.FromArgb(247, 247, 247);
			btn.Font = new Font("Bauhaus 95", 10f, FontStyle.Bold);
			btn.Region = Region.FromHrgn(RoundedRect.CreateRoundRectRgn(0, 0, 150, 30, 15, 15));
			btn.TabStop = false;
			btn.FlatStyle = FlatStyle.Flat;
			btn.FlatAppearance.BorderSize = 0;
		}
		public void BackBtn(Button btn)
		{

			btn.Size = new Size(80, 30);
			btn.Location = new Point(180, 400);
			btn.Text = "VISSZA";
			btn.ForeColor = Color.FromArgb(247, 247, 247);
			btn.Font = new Font("Bauhaus 95", 10f, FontStyle.Bold);
			btn.Region = Region.FromHrgn(RoundedRect.CreateRoundRectRgn(0, 0, 80, 30, 15, 15));
			btn.TabStop = false;
			btn.FlatStyle = FlatStyle.Flat;
			btn.FlatAppearance.BorderSize = 0;
		}
		public void UsernameLb(Label username)
		{

			username.Text = "FELHASZNÁLÓNÉV";
			username.Size = new Size(200, 30);
			username.Location = new Point(40, 150);
			username.ForeColor = Color.FromArgb(0, 194, 203);
			username.Font = new Font("Bauhaus 95", 10f, FontStyle.Italic);
		}
		public void UsernameTb(TextBox username)
		{

			username.Size = new Size(200, 20);
			username.Location = new Point(40, 170);
			username.Font = new Font("Bauhaus 95", 15f, FontStyle.Bold);
			username.BackColor = Color.FromArgb(247, 247, 247);
			username.MaxLength = 14;
			username.Region = Region.FromHrgn(RoundedRect.CreateRoundRectRgn(0, 0, 200, 30, 15, 15));
		}
		public void PasswordTb(TextBox password)
		{

			password.Size = new Size(200, 20);
			password.Location = new Point(40, 230);
			password.Text = "";
			password.PasswordChar = '*';
			password.MaxLength = 14;
			password.Font = new Font("Bauhaus 95", 15f, FontStyle.Bold);
			password.BackColor = Color.FromArgb(247, 247, 247);
			password.Region = Region.FromHrgn(RoundedRect.CreateRoundRectRgn(0, 0, 200, 30, 15, 15));
		}
		public void KeyTb(TextBox key)
		{

			key.Size = new Size(200, 20);
			key.Location = new Point(40, 360);
			key.Text = "";
			key.PasswordChar = '*';
			key.MaxLength = 14;
			key.Font = new Font("Bauhaus 95", 15f, FontStyle.Bold);
			key.BackColor = Color.FromArgb(247, 247, 247);
			key.Region = Region.FromHrgn(RoundedRect.CreateRoundRectRgn(0, 0, 200, 30, 15, 15));
		}
		public void RegisterLb(Label registerLb)
		{

			registerLb.Text = "REGISZTRÁCIÓ";
			registerLb.Size = new Size(240, 50);
			registerLb.Location = new Point(30, 60);
			registerLb.ForeColor = Color.FromArgb(0, 194, 203);
			registerLb.Font = new Font("Bauhaus 95", 20f, FontStyle.Bold);
		}
		public void PasswordLb(Label password)
		{

			password.Text = "JELSZÓ";
			password.Size = new Size(200, 30);
			password.Location = new Point(40, 210);
			password.ForeColor = Color.FromArgb(0, 194, 203);
			password.Font = new Font("Bauhaus 95", 10f, FontStyle.Italic);
		}
		public void KeyLb(Label key)
		{

			key.Text = "KULCS";
			key.Size = new Size(200, 30);
			key.Location = new Point(40, 340);
			key.ForeColor = Color.FromArgb(0, 194, 203);
			key.Font = new Font("Bauhaus 95", 10f, FontStyle.Italic);
		}

		public void PasswordVerifyTb(TextBox password)
		{

			password.Size = new Size(200, 20);
			password.Location = new Point(40, 290);
			password.Text = "";
			password.PasswordChar = '*';
			password.MaxLength = 14;
			password.Font = new Font("Bauhaus 95", 15f, FontStyle.Bold);
			password.BackColor = Color.FromArgb(247, 247, 247);
			password.Region = Region.FromHrgn(RoundedRect.CreateRoundRectRgn(0, 0, 200, 30, 15, 15));
		}

		public void VerifyPassLb(Label password)
		{

			password.Text = "JELSZÓ MEGERŐSÍTÉSE";
			password.Size = new Size(200, 30);
			password.Location = new Point(40, 270);
			password.ForeColor = Color.FromArgb(0, 194, 203);
			password.Font = new Font("Bauhaus 95", 10f, FontStyle.Italic);
		}
		public void ErrorLb(Label password)
		{

			password.Text = "a két jelszó nem egyezik";
			password.Size = new Size(200, 30);
			password.Location = new Point(40, 320);
			password.ForeColor = Color.FromArgb(153, 0, 0);
			password.Font = new Font("Bauhaus 95", 8f, FontStyle.Bold);
		}
		public void RegistrationForm(Form registrationForm)
		{
			registrationForm.Region = System.Drawing.Region.FromHrgn(RoundedRect.CreateRoundRectRgn(0, 0, 300, 450, 25, 25));
			registrationForm.FormBorderStyle = FormBorderStyle.None;
			registrationForm.BackColor = Color.FromArgb(21, 41, 50);
		}
	}
}
