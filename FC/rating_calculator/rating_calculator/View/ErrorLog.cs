using rating_calculator.View.styles;
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
	public partial class ErrorLog : Form
	{
		#region Elements
		private const int WM_NCHITTEST = 0x84;
		private const int HT_CLIENT = 0x1;
		private const int HT_CAPTION = 0x2;
		private Label errorTypeLb;
		Label errorLb;
		Button back;
		public Label ErrorTypeLb { get => errorTypeLb; set => errorTypeLb = value; }
		public Label ErrorLb { get => errorLb; set => errorLb = value; }
		public Button Back { get => back; set => back = value; }
		#endregion
		public ErrorLog()
		{
			InitializeComponent();
			
			ErrorLogStyle();
			Screen screen = Screen.FromControl(this);
			Rectangle workingArea = screen.WorkingArea;
			this.Location = new Point()
			{
				X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - 400) / 2),
				Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - 200) / 2)
			};
			Back.Click += Back_Click;
		}

		private void Back_Click(object sender, EventArgs e)
		{
			this.Hide();
			Login l = new Login();
			l.Show();
		}

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (m.Msg == WM_NCHITTEST)
				m.Result = (IntPtr)(HT_CAPTION);
		}
		private void ErrorLogStyle()
		{
			ErrorStyle es = new ErrorStyle();
			this.CenterToScreen();
			es.ErrorForm(this);

			ErrorLb = new Label();
			es.ErrorLb(ErrorLb);
			this.Controls.Add(ErrorLb);

			ErrorTypeLb = new Label();
			es.ErrorTypeLb(ErrorTypeLb);
			this.Controls.Add(ErrorTypeLb);
			Back = new Button();
			es.BackBtn(Back);
			this.Controls.Add(Back);
		}
	}
}
