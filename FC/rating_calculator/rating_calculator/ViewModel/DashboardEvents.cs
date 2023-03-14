using rating_calculator.Model;
using rating_calculator.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rating_calculator.ViewModel
{
	class DashboardEvents
	{
		readonly ConnectToDB db = new ConnectToDB();
		public void Logout()
		{
			Login login = new Login();
			login.ShowDialog();
			login.Dispose();
		}
		public void Comments()
		{
			Comment comment = new Comment();
			comment.ShowDialog();
			comment.Dispose();
		}

		public DataSet ChartData {
			get {
				DataSet table = db.Tablazatot_ad("SELECT * FROM `graph`");
				return table;
			}
		}

		public void UpdateUserCount()
		{
			int users = Convert.ToInt32(db.Szamot_ad("SELECT COUNT(userId) FROM users;"));
			db.AddUserCount(users);
		}
		public void Quit() => Application.Exit();
		public void Minimize(Form form) => form.WindowState = FormWindowState.Minimized;
	}
}
