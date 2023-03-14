using rating_calculator.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rating_calculator.ViewModel
{
	class LoginEvents
	{
		public void LoginClick()
		{
			Dashboard dashboard = new Dashboard();
			dashboard.ShowDialog();
		}
		public void RegistrationClick()
		{
			Registration registration = new Registration();
			registration.ShowDialog();
			registration.Dispose();
		}
		public void Quit() => Application.Exit();
		public void Minimize(Form form) => form.WindowState = FormWindowState.Minimized;
	}
}
