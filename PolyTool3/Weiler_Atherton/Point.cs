using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyTool3.Weiler_Atherton
{
	/* Class defining crossing point for new vertex - used as well for so far defined polygon vertices */
	class Point
	{
		public Point WindowNext { get; set; }
		public Point SubjectNext { get; set; }
		public int X { get; }
		public int Y { get; }
		public bool CrossPoint { get; }

		public Point(int _X, int _Y, bool _CrossPoint)
		{
			X = _X;
			Y = _Y;
			CrossPoint = _CrossPoint;
		}
	}
}
