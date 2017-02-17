using PolyTool3.Graphic.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyTool3.Graphic.Surfaces
{
	class Paraboloid : ISurface
	{
		private double a;
		private int p, q;

		public Paraboloid(double _a, int _p, int _q)
		{
			a = _a;
			p = _p;
			q = _q;
		}

		public double this[int X, int Y]
		{
			get
			{
				return a * (X - p) * (X - p) + a * (Y - q) * (Y - q);
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
			return 2 * a * (X - p);
		}

		private double dY(int X, int Y)
		{
			return 2 * a * (Y - q);
		}
	}
}
