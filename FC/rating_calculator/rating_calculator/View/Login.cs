using rating_calculator.View;
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

namespace rating_calculator
{
	public partial class Login : Form
	{
		#region Elements
		private const int WM_NCHITTEST = 0x84;
		private const int HT_CLIENT = 0x1;
		private const int HT_CAPTION = 0x2;
		RoundedButton quitBtn, minBtn;
		TextBox usernameTb, passwordTb;
		Button loginBtn;
		Label usernameLb, passwordLb, register;
		readonly LoginEvents le = new LoginEvents();
		string username, password;
		internal RoundedButton QuitBtn { get => quitBtn; set => quitBtn = value; }
		internal RoundedButton MinBtn { get => minBtn; set => minBtn = value; }
		public TextBox UsernameTb { get => usernameTb; set => usernameTb = value; }
		public TextBox PasswordTb { get => passwordTb; set => passwordTb = value; }
		public Button LoginBtn { get => loginBtn; set => loginBtn = value; }
		public Label UsernameLb { get => usernameLb; set => usernameLb = value; }
		public Label PasswordLb { get => passwordLb; set => passwordLb = value; }
		public Label Register { get => register; set => register = value; }
		#endregion
		public Login()
		{
			InitializeComponent();

			this.CenterToScreen();
			LoginStyle();

			LoginBtn.Click += LoginBtn_Click;
			Register.Click += Register_Click;
			UsernameTb.TextChanged += UsernameTb_TextChanged;
			PasswordTb.TextChanged += PasswordTb_TextChanged;
			QuitBtn.Click += QuitBtn_Click;
			MinBtn.Click += MinBtn_Click;
		}

		private void MinBtn_Click(object sender, EventArgs e)
		{
			le.Minimize(this);
		}

		private void QuitBtn_Click(object sender, EventArgs e)
		{
			le.Quit();
		}

		private void PasswordTb_TextChanged(object sender, EventArgs e)
		{
			password = PasswordTb.Text;
		}

		private void UsernameTb_TextChanged(object sender, EventArgs e)
		{
			username = UsernameTb.Text;
		}

		private void Register_Click(object sender, EventArgs e)
		{
			this.Hide();
			le.RegistrationClick();
		}

		private void LoginBtn_Click(object sender, EventArgs e)
		{
			ErrorLog el = new ErrorLog();
			this.Hide();
			if (password == null)
			{
				el.ErrorTypeLb.Text = "A jelszó nem lehet üres";
				el.Show();
			}
			else
			{
				AdminValidation av = new AdminValidation(username, password);
				if (av.Validation() == "sikeres")
				{
					le.LoginClick();
				}
				else if (av.Validation() == "jelszo hiba")
				{
					el.ErrorTypeLb.Text = "Nem megfelelő jelszó";
					el.Show();
				}
				else
				{
					el.ErrorTypeLb.Text = "Nem megfelelő felhasználónév";
					el.Show();
				}
			}
		}

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (m.Msg == WM_NCHITTEST)
				m.Result = (IntPtr)(HT_CAPTION);
		}

		private void LoginStyle()
		{
			LoginStyle ls = new LoginStyle();

			ls.LoginForm(this);

			PictureBox pb1 = new PictureBox
			{
				Image = Image.FromFile("Fit.png"),
				Location = new Point(75, 30),
				Size = new Size(150, 150)
			};
			this.Controls.Add(pb1);

			UsernameTb = new TextBox();
			ls.UsernameTb(UsernameTb);
			this.Controls.Add(UsernameTb);

			PasswordTb = new TextBox();
			ls.PasswordTb(PasswordTb);
			this.Controls.Add(PasswordTb);

			LoginBtn = new Button();
			ls.LoginBtn(LoginBtn);
			this.Controls.Add(LoginBtn);

			QuitBtn = new RoundedButton();
			ls.QuitBtn(QuitBtn);
			this.Controls.Add(QuitBtn);

			MinBtn = new RoundedButton();
			ls.MinBtn(MinBtn);
			this.Controls.Add(MinBtn);

			UsernameLb = new Label();
			ls.UsernameLb(UsernameLb);
			this.Controls.Add(UsernameLb);

			PasswordLb = new Label();
			ls.PasswordLb(PasswordLb);
			this.Controls.Add(PasswordLb);

			Register = new Label();
			ls.Register(Register);
			this.Controls.Add(Register);
		}

	}
}