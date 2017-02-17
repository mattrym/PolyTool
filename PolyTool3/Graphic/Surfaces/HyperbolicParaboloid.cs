using PolyTool3.Graphic.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyTool3.Graphic.Surfaces
{
	class HyperbolicParaboloid : ISurface
	{
		private double a;
		private int p, q;

		public HyperbolicParaboloid(double _a, int _p, int _q)
		{
			a = _a;
			p = _p;
			q = _q;
		}

		public double this[int X, int Y]
		{
			get
			{
				return a * (X - p) * (Y - q);
			}
		}

		public Vector GradientVector(int x, int y)
		{
			double dx = -dX(x, y);
			double dy = -dY(x, y);
			return new Vector(dx, dy, 1);
		}

		private double dX(int X, int Y)
		{
			return a * (Y - q);
		}

		private double dY(int X, int Y)
		{
			return a * (X - p);
		}
	}
}
