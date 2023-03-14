using rating_calculator.Model;
using rating_calculator.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rating_calculator.ViewModel
{
	class RegisterEvents
	{
		readonly Login login = new Login();
		readonly ConnectToDB db = new ConnectToDB();

		public void Back()
		{
			login.ShowDialog();
			login.Dispose();
		}
		public void Register(string username, string password, string key)
		{
			if (PasswordSafe(password))
			{
				string keyForAuthorization = "123Uc!22vy";
				AdminValidation av = new AdminValidation(username, password);
				if (key == keyForAuthorization)
				{
					if (av.Validation() == "felhasznalo hiba")
					{
						CreateAdmin(username, Sha256(password));
						login.ShowDialog();
					}
				}
				else
				{
					MessageBox.Show("Nem megfelelő hitelesítési kulcs!!");
					login.ShowDialog();
				}
			}
			else
			{
				Registration r = new Registration();
				r.ShowDialog();
				r.Dispose();
			}
		}

		private void CreateAdmin(string username, string password)
		{
			if (!Int32.TryParse(db.Szamot_ad("SELECT MAX(adminId) FROM admins;"), out int id)) id = 1;
			id++;
			db.AddAdmin(id, username, password);
		}

		private string Sha256(string randomString)
		{
			var crypt = new System.Security.Cryptography.SHA256Managed();
			var hash = new System.Text.StringBuilder();
			byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
			foreach (byte theByte in crypto)
			{
				hash.Append(theByte.ToString("x2"));
			}
			crypt.Dispose();
			return hash.ToString();
		}
		private bool PasswordSafe(string password)
		{
			List<string> list = FillList;
			if (list.Contains(password))
			{
				MessageBox.Show("Ne használjon gyakran ismételt, egyszerű jelszavakat!");
				return false;
			}
			else if (password.Length < 8)
			{
				MessageBox.Show("legalább 8 karakter hosszú jelszót adjon meg!");
				return false;
			}
			else if (!password.Any(char.IsDigit))
			{
				MessageBox.Show("legalább 1 számot kell tartalmaznia!");
				return false;
			}
			else if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
			{
				MessageBox.Show("legalább 1 speciális karaktert kell tartalmaznia!");
				return false;
			}
			else { return true; }
		}
		private List<string> FillList {
			get {
				List<string> list = File.ReadAllLines("passwords.txt").ToList();
				return list;
			}
		}
	}
}
