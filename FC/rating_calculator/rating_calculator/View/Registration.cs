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

namespace rating_calculator.View
{
	public partial class Registration : Form
	{
		#region Elements
		private const int WM_NCHITTEST = 0x84;
		private const int HT_CLIENT = 0x1;
		private const int HT_CAPTION = 0x2;
		readonly RegistrationStyle rs = new RegistrationStyle();
		readonly RegisterEvents re = new RegisterEvents();
		TextBox usernameTb, passwordTb, keyTb, passwordVerifyTb;
		Button registerBtn, backBtn;
		Label registerLb, usernameLb, passwordLb, keyLb, verifyPassLb, errorLb;
		public TextBox UsernameTb { get => usernameTb; set => usernameTb = value; }
		public TextBox PasswordTb { get => passwordTb; set => passwordTb = value; }
		public TextBox KeyTb { get => keyTb; set => keyTb = value; }
		public TextBox PasswordVerifyTb { get => passwordVerifyTb; set => passwordVerifyTb = value; }
		public Button RegisterBtn { get => registerBtn; set => registerBtn = value; }
		public Button BackBtn { get => backBtn; set => backBtn = value; }
		public Label RegisterLb { get => registerLb; set => registerLb = value; }
		public Label UsernameLb { get => usernameLb; set => usernameLb = value; }
		public Label PasswordLb { get => passwordLb; set => passwordLb = value; }
		public Label KeyLb { get => keyLb; set => keyLb = value; }
		public Label VerifyPassLb { get => verifyPassLb; set => verifyPassLb = value; }
		public Label ErrorLb { get => errorLb; set => errorLb = value; }
		#endregion
		public Registration()
		{
			InitializeComponent();
			RegistrationStyle();
			Screen screen = Screen.FromControl(this);
			Rectangle workingArea = screen.WorkingArea;
			this.Location = new Point()
			{
				X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - 300) / 2),
				Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - 450) / 2)
			};

			
			
			RegisterBtn.Enabled = false;
			ErrorLb.Visible = false;
			PasswordTb.TextChanged += PasswordTb_TextChanged;
			PasswordVerifyTb.TextChanged += PasswordVerifyTb_TextChanged;
			BackBtn.Click += BackBtn_Click;
			RegisterBtn.Click += RegisterBtn_Click;
		}

		private void BackBtn_Click(object sender, EventArgs e)
		{
			this.Hide();
			re.Back();
		}

		private void RegisterBtn_Click(object sender, EventArgs e)
		{
			this.Hide();
			re.Register(UsernameTb.Text, PasswordTb.Text, KeyTb.Text);
		}

		private void PasswordVerifyTb_TextChanged(object sender, EventArgs e)
		{
			Verification();
		}

		private void PasswordTb_TextChanged(object sender, EventArgs e)
		{
			Verification();
		}
		void Verification()
		{

			if (PasswordTb.Text == PasswordVerifyTb.Text && PasswordTb.Text != "")
			{
				RegisterBtn.Enabled = true;
				ErrorLb.Visible = false;
			}
			else
			{
				RegisterBtn.Enabled = false;
				ErrorLb.Visible = true;
			}
		}
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (m.Msg == WM_NCHITTEST)
				m.Result = (IntPtr)(HT_CAPTION);
		}
		public void RegistrationStyle()
		{
			rs.RegistrationForm(this);
			this.CenterToScreen();

			UsernameTb = new TextBox();
			rs.UsernameTb(UsernameTb);
			this.Controls.Add(UsernameTb);

			PasswordTb = new TextBox();
			rs.PasswordTb(PasswordTb);
			this.Controls.Add(PasswordTb);

			PasswordVerifyTb = new TextBox();
			rs.PasswordVerifyTb(PasswordVerifyTb);
			this.Controls.Add(PasswordVerifyTb);

			KeyTb = new TextBox();
			rs.KeyTb(KeyTb);
			this.Controls.Add(KeyTb);

			RegisterBtn = new Button();
			rs.LoginBtn(RegisterBtn);
			this.Controls.Add(RegisterBtn);

			BackBtn = new Button();
			rs.BackBtn(BackBtn);
			this.Controls.Add(BackBtn);

			RegisterLb = new Label();
			rs.RegisterLb(RegisterLb);
			this.Controls.Add(RegisterLb);

			UsernameLb = new Label();
			rs.UsernameLb(UsernameLb);
			this.Controls.Add(UsernameLb);

			PasswordLb = new Label();
			rs.PasswordLb(PasswordLb);
			this.Controls.Add(PasswordLb);

			VerifyPassLb = new Label();
			rs.VerifyPassLb(VerifyPassLb);
			this.Controls.Add(VerifyPassLb);

			KeyLb = new Label();
			rs.KeyLb(KeyLb);
			this.Controls.Add(KeyLb);

			ErrorLb = new Label();
			rs.ErrorLb(ErrorLb);
			this.Controls.Add(ErrorLb);
		}
	}
}
