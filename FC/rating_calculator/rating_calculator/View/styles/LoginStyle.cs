using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rating_calculator.View.styles
{
	class LoginStyle
	{
		public void LoginBtn(Button btn)
		{
			btn.Size = new Size(200, 30);
			btn.Location = new Point(50, 350);
			btn.Text = "BEJELENTKEZÉS";
			btn.ForeColor = Color.FromArgb(247, 247, 247);
			btn.Font = new Font("Bauhaus 95", 15f, FontStyle.Bold);
			btn.Region = Region.FromHrgn(RoundedRect.CreateRoundRectRgn(0, 0, 200, 30, 15, 15));
			btn.TabStop = false;
			btn.FlatStyle = FlatStyle.Flat;
			btn.FlatAppearance.BorderSize = 0;
		}
		public void MinBtn(RoundedButton btn)
		{
			btn.Size = new Size(13, 13);
			btn.Location = new Point(258, 10);
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
			btn.Location = new Point(275, 10);
			btn.ForeColor = Color.FromArgb(247, 247, 247);
			btn.BackColor = Color.FromArgb(237, 0, 18);
			btn.Font = new Font("Bauhaus 95", 10f, FontStyle.Bold);
			btn.TabStop = false;
			btn.FlatStyle = FlatStyle.Flat;
			btn.FlatAppearance.BorderSize = 0;

		}
		public void UsernameLb(Label username)
		{
			username.Text = "FELHASZNÁLÓNÉV";
			username.Size = new Size(200, 30);
			username.Location = new Point(40, 200);
			username.ForeColor = Color.FromArgb(0, 194, 203);
			username.Font = new Font("Bauhaus 95", 10f, FontStyle.Italic);
		}
		public void UsernameTb(TextBox username)
		{
			username.Size = new Size(200, 20);
			username.Location = new Point(50, 220);
			username.Font = new Font("Bauhaus 95", 15f, FontStyle.Bold);
			username.BackColor = Color.FromArgb(247, 247, 247);
			username.MaxLength = 14;
			username.Region = Region.FromHrgn(RoundedRect.CreateRoundRectRgn(0, 0, 200, 30, 15, 15));
		}
		public void PasswordTb(TextBox password)
		{
			password.Size = new Size(200, 20);
			password.Location = new Point(50, 280);
			password.Text = "";
			password.PasswordChar = '*';
			password.MaxLength = 14;
			password.Font = new Font("Bauhaus 95", 15f, FontStyle.Bold);
			password.BackColor = Color.FromArgb(247, 247, 247);
			password.Region = Region.FromHrgn(RoundedRect.CreateRoundRectRgn(0, 0, 200, 30, 15, 15));
		}
		public void LoginLb(Label loginLb)
		{
			loginLb.Text = "ADMIN BEJELENTKEZÉS";
			loginLb.Size = new Size(260, 100);
			loginLb.Location = new Point(30, 90);
			loginLb.ForeColor = Color.FromArgb(0, 194, 203);
			loginLb.Font = new Font("Bauhaus 95", 20f, FontStyle.Bold);
		}
		public void PasswordLb(Label password)
		{
			password.Text = "JELSZÓ";
			password.Size = new Size(200, 30);
			password.Location = new Point(40, 260);
			password.ForeColor = Color.FromArgb(0, 194, 203);
			password.Font = new Font("Bauhaus 95", 10f, FontStyle.Italic);
		}
		public void Register(Label register)
		{
			register.Text = "Új admin regisztrálása";
			register.Size = new Size(200, 30);
			register.Location = new Point(75, 400);
			register.ForeColor = Color.FromArgb(0, 194, 203);
			register.Font = new Font("Bauhaus 95", 10f, FontStyle.Italic);
		}
		public void LoginForm(Form loginForm)
		{
			loginForm.Region = Region.FromHrgn(RoundedRect.CreateRoundRectRgn(0, 0, 300, 450, 25, 25));
			loginForm.FormBorderStyle = FormBorderStyle.None;
			loginForm.BackColor = Color.FromArgb(21, 41, 50);
			
		}
	}
}
