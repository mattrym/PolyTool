using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyTool3.Graphic.Backgrounds
{
	class ColorBackground : IBackground
	{
		private double r, g, b;

		public ColorBackground(Color _color)
		{
			r = _color.R / (double) 255;
			g = _color.G / (double) 255;
			b = _color.B / (double) 255;
		}

		public double R(int x, int y) => r;

		public double G(int x, int y) => g;

		public double B(int x, int y) => b;
	}
}
