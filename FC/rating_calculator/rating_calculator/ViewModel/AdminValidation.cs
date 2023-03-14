using rating_calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rating_calculator.ViewModel
{
	class AdminValidation
	{
		readonly ConnectToDB db = new ConnectToDB();

		private string username;
		private string password;
		readonly List<string> usernames;
		List<string> passwords;

		public AdminValidation(string username, string password)
		{
			usernames = db.Listat_ad("SELECT admins.username FROM admins;");
			this.username = username;
			this.password = password;
		}

		public string Username { get => username; set => username = value; }
		public string Password { get => password; set => password = value; }

		public string Validation()
		{
			if (usernames.Contains(username))
			{
				passwords = db.Listat_ad("SELECT admins.password FROM admins WHERE admins.username LIKE '" + username + "';");
				if (passwords.Contains(Sha256(password))) { return "sikeres"; } else { return "jelszo hiba"; }
			}
			else { return "felhasznalo hiba"; }

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
	}
}
