using rating_calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rating_calculator.ViewModel
{
	class CommentEvents
	{
		readonly ConnectToDB db = new ConnectToDB();

		public List<string> GetAllComment()
		{
			List<string> commentList = db.Listat_ad("SELECT comments FROM review WHERE comments NOT LIKE 'NULL';");
			return commentList;
		}

		public double UserStatisfication(double y, double x)
		{
			//List<string> commentList = GetAllComment();
			double statisfication = y / (x + y) * 100;
			return statisfication;
		}
	}
}
