using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyTool3.Polygons
{
	class Edge
	{
		private Polygon polygon;

		public Vertex V1 { get; private set; }
		public Vertex V2 { get; private set; }

		public int middleX => (V1.X + V2.X) / 2;
		public int middleY => (V1.Y + V2.Y) / 2;

		public int deltaX => V2.X - V1.X;
		public int deltaY => V2.Y - V1.Y;
		public int A => (V2.Y - V1.Y);
		public int B => (V1.X - V2.X);
		public int C => (V1.Y * V2.X - V2.Y * V1.X);

		public Edge(Canvas _canvas, Polygon _polygon, Vertex _v1, Vertex _v2)
		{
			polygon = _polygon;
			V1 = _v1;
			V2 = _v2;
		}

		public void Invert()
		{
			Vertex aux = V1;
			V1 = V2;
			V2 = aux;
		}
	}
}
