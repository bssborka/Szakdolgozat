using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace rating_calculator.View.styles
{
	class RoundedRect
	{
		[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
		public static extern IntPtr CreateRoundRectRgn
	   (
	   int nLeftRect,
	   int nTopRect,
	   int nRightRect,
	   int nBottomRect,
	   int nWidhtEllipse,
	   int nHeightEllipse
	   );
	}
}
