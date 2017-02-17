using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyTool3.Polygons
{
	class Vertex
	{
		public static readonly int WIDTH = 11;
		public static readonly int RADIUS = (WIDTH - 1) / 2;

		public int X { get; set; }
		public int Y { get; set; }
		public Edge LeftEdge { get; set; }
		public Edge RightEdge { get; set; }
		public Polygon Polygon { get; }

		public Vertex(Canvas _canvas, Polygon _polygon, int _X, int _Y)
		{
			Polygon = _polygon;
			X = _X;
			Y = _Y;
		}

		public void InvertEdges()
		{
			Edge aux = LeftEdge;
			LeftEdge = RightEdge;
			RightEdge = aux;
		}
	}
}
