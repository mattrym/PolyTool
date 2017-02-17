using System.Drawing;
using System.Collections.Generic;
using PolyTool3.Graphic.Structures;
using PolyTool3.Polygons;

namespace PolyTool3.Graphic.Renderers
{
	class PolygonDrawer
	{
		private static readonly int WIDTH = 11;
		private static readonly int RADIUS = (WIDTH - 1) / 2;

		private List<Polygon> polygons;
		private DirectBitmap directBitmap;

		public PolygonDrawer(DirectBitmap _directBitmap, List<Polygon> _polygons)
		{
			directBitmap = _directBitmap;
			polygons = _polygons;
		}

		public void DrawVertices()
		{
			using (Graphics graphics = Graphics.FromImage(directBitmap.Bitmap))
			{
				foreach (Polygon polygon in polygons)
				{
					foreach (Vertex vertex in polygon.Vertices)
					{
						graphics.FillEllipse(Brushes.Red, vertex.X - RADIUS, vertex.Y - RADIUS, WIDTH, WIDTH);
					}
				}
			}	
		}

		public void DrawEdges()
		{
			using (Graphics graphics = Graphics.FromImage(directBitmap.Bitmap))
			{
				foreach (Polygon polygon in polygons)
				{
					foreach (Edge edge in polygon.Edges)
					{
						graphics.DrawLine(Pens.Black, edge.V1.X, edge.V1.Y, edge.V2.X, edge.V2.Y);
					}
				}
			}
		}
	}
}