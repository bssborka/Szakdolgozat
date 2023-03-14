﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rating_calculator.View.styles
{
	class RoundedButton:Button
	{
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			var graphicsPath = new GraphicsPath();
			graphicsPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
			this.Region = new Region(graphicsPath);
			base.OnPaint(e);
		}
	}
}
