using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyTool3.Graphic.Structures
{
	class Vector
	{
		public static double operator* (Vector vector1, Vector vector2)
		{
			double cos = vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z;
			return cos > 0 ? cos : 0;
		}

		private double x, y, z;

		public Vector(double _x, double _y, double _z)
		{
			double length = Math.Sqrt(_x * _x + _y * _y + _z * _z);
			x = _x / length;
			y = _y / length;
			z = _z / length;
		}

		public double X => x;
		public double Y => y;
		public double Z => z;
	}
}
