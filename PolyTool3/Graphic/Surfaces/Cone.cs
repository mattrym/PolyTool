using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolyTool3.Graphic.Structures;
using System.Windows.Forms;

namespace PolyTool3.Graphic.Surfaces
{
	class Cone : ISurface
	{
		private double a;
		private int p, q;
		private double?[,] cache;

		public Cone(double _a, int _p, int _q)
		{
			a = _a;
			p = _p;
			q = _q;
		}

		public double this[int X, int Y]
		{
			get
			{
				return a * Math.Sqrt((X - p) * (X - p) + (Y - q) * (Y - q));
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
			if(X == p && Y == q)
			{
				return 0;
			}
			return a * (X - p) / Math.Sqrt((X - p) * (X - p) + (Y - q) * (Y - q));
		}

		private double dY(int X, int Y)
		{
			if (X == p && Y == q)
			{
				return 0;
			}
			return a * (Y - q) / Math.Sqrt((X - p) * (X - p) + (Y - q) * (Y - q));
		}
	}
}
