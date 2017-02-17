using PolyTool3.Graphic.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyTool3.Graphic.Surfaces
{
	class Plane : ISurface
	{
		private double a;
		private Vector[,] normalMap;

		public Plane(double _a)
		{
			a = _a;
		}

		public double this[int X, int Y]
		{
			get
			{
				return a;
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
			return 0;
		}

		private double dY(int X, int Y)
		{
			return 0;
		}
	}
}
