using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rating_calculator.Model
{
	class ConnectToDB
	{
		readonly string kapcs_string;
		MySqlConnection kapcs_mysql;
		readonly MySqlDataAdapter adapter_mysql = new MySqlDataAdapter();
		public ConnectToDB()
		{
			kapcs_string = "datasource=127.0.0.1;database=fitclock;uid=root;pwd=";
		}

		public bool Megnyitas()
		{
			try
			{
				kapcs_mysql = new MySqlConnection(kapcs_string);
				kapcs_mysql.Open();
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}
		public bool Bezaras()
		{
			try
			{
				kapcs_mysql.Close();
				kapcs_mysql.Dispose();
				adapter_mysql.Dispose();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public string Szamot_ad(string LKS)
		{
			Bezaras();
			if (Megnyitas())
			{
				try
				{
					MySqlCommand parancs = new MySqlCommand(LKS, kapcs_mysql);
					string command = parancs.ExecuteScalar().ToString();
					parancs.Dispose();
					return command;
				}
				catch (Exception H)
				{
					return H.ToString();
				}
			}

			return "Hiba!";
		}
		public List<string> Listat_ad(string LKS)
		{
			Bezaras();
			List<string> valaszlista = new List<string>();
			if (Megnyitas())
			{
				try
				{
					MySqlCommand parancs = new MySqlCommand(LKS, kapcs_mysql);
					MySqlDataReader olvaso = parancs.ExecuteReader();
					while (olvaso.Read())
					{
						valaszlista.Add(olvaso[0].ToString());
					}
					parancs.Dispose();
				}
				catch (Exception ex)
				{
					valaszlista.Add(ex.ToString());
				}
				return valaszlista;
			}
			valaszlista.Add("kapcsolati hiba");
			return valaszlista;
		}
		public DataSet Tablazatot_ad(string LKS)
		{
			Bezaras();
			DataSet adatok = new DataSet();
			if (Megnyitas())
			{
				try
				{
					adapter_mysql.SelectCommand = new MySqlCommand(LKS, kapcs_mysql);
					adapter_mysql.Fill(adatok);
					return adatok;
				}
				catch (Exception)
				{
					return adatok;
				}
			}
			return adatok;
		}


		public void testInsert(string n)
		{
			Bezaras();
			if (Megnyitas())
			{
				try
				{
					MySqlCommand parancs = new MySqlCommand
					{
						CommandText = "INSERT INTO review(reviewId, graphics, functions, exercises, groups, comments) VALUES (" + n + "," + n + "," + n + "," + n + "," + n + ",'');",
						Connection = kapcs_mysql
					};
					parancs.ExecuteNonQuery();
					parancs.Dispose();
				}
				catch (Exception) { }
			}
		}
		public void Ddl_dml(string LKS)
		{
			Bezaras();
			if (Megnyitas())
			{
				try
				{
					MySqlCommand parancs = new MySqlCommand
					{
						CommandText = LKS,
						Connection = kapcs_mysql
					};
					parancs.ExecuteNonQuery();
					parancs.Dispose();
				}
				catch (Exception) { }
			}
		}

		public bool AddAdmin(int id, string user, string pass)
		{
			Bezaras();
			if (Megnyitas())
			{
				try
				{
					MySqlCommand parancs = new MySqlCommand
					{
						Connection = kapcs_mysql,
						CommandText = "INSERT INTO admins(adminId, username, password) VALUES('" + id + "', '" + user + "', '" + pass + "');"
					};
					parancs.ExecuteNonQuery();
					parancs.Dispose();
					return true;
				}
				catch (Exception) { }
			}
			return false;
		}

		public bool AddUserCount(int users)
		{
			Bezaras();
			if (Megnyitas())
			{
				try
				{
					MySqlCommand parancs = new MySqlCommand
					{
						Connection = kapcs_mysql,
						CommandText = "INSERT INTO graph(numberOfUsers, date) VALUES('" + users + "', '" + DateTime.Now + "');"
					};
					parancs.ExecuteNonQuery();
					parancs.Dispose();
					return true;
				}
				catch (Exception) { }
			}
			return false;
		}
	}
}
