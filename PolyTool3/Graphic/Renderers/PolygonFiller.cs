using PolyTool3.Graphic.Structures;
using PolyTool3.Polygons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyTool3.Graphic.Renderers
{
	partial class PolygonFiller
	{
		private List<Polygon> polygons;
		private DirectBitmap directBitmap;
		private SurfaceRenderer surfaceRenderer;

		public PolygonFiller(DirectBitmap _directBitmap, SurfaceRenderer _surfaceRenderer, List<Polygon> _polygons)
		{
			directBitmap = _directBitmap;
			surfaceRenderer = _surfaceRenderer;
			polygons = _polygons;
		}

		public void FillPolygons()
		{
			foreach (Polygon polygon in polygons)
			{
				if (polygon.Closed)
				{
					FillPolygon(polygon);
				}
			}
		}

		private void FillPolygon(Polygon polygon)
		{
			int minY, maxY;
			SortedList<int, List<EdgeTableNode>> edgeTable = CreateEdgeTable(polygon, out minY, out maxY);
			List<EdgeTableNode> activeEdgeTable = new List<EdgeTableNode>();

			for (int y = minY; y <= maxY; ++y)
			{
				EdgeTableNode startNode = null, endNode = null;
				foreach (EdgeTableNode node in activeEdgeTable)
				{
					if (startNode == null)
					{
						startNode = node;
					}
					else
					{
						endNode = node;
						Parallel.For(Math.Max(0, startNode.X), endNode.X + 1, x =>
						{
							if (0 <= y && y < directBitmap.Height)
							{
								directBitmap[x, y] = surfaceRenderer.RenderPixel(x, y);
							}
						});
						startNode = endNode = null;
					}
				}

				if (edgeTable.ContainsKey(y))
				{
					activeEdgeTable.AddRange(edgeTable[y]);
				}
				activeEdgeTable.Sort((node1, node2) => node1.X - node2.X);

				activeEdgeTable.RemoveAll(node => node.MaxY == y);
				foreach(EdgeTableNode node in activeEdgeTable)
				{
					node.Increment();
				}
			}
		}

		private SortedList<int, List<EdgeTableNode>> CreateEdgeTable(Polygon polygon, out int minY, out int maxY)
		{
			int key;
			EdgeTableNode value;
			SortedList<int, List<EdgeTableNode>> edgeTable = new SortedList<int, List<EdgeTableNode>>();

			foreach (Edge edge in polygon.Edges)
			{
				if (edge.V1.Y > edge.V2.Y)
				{
					key = edge.V2.Y;
					value = new EdgeTableNode(edge.V2.X, (edge.deltaX / (double) edge.deltaY), edge.V1.Y);
				}
				else
				{
					key = edge.V1.Y;
					value = new EdgeTableNode(edge.V1.X, (edge.deltaX / (double) edge.deltaY), edge.V2.Y);
				}
				if (!edgeTable.ContainsKey(key))
				{
					edgeTable[key] = new List<EdgeTableNode>();
				}
				edgeTable[key].Add(value);
			}

			minY = polygon.Edges.Min(edge => Math.Min(edge.V1.Y, edge.V2.Y));
			maxY = polygon.Edges.Max(edge => Math.Max(edge.V1.Y, edge.V2.Y));
			return edgeTable;
		}

		private class EdgeTableNode
		{
			public int MaxY { get; }
			public int X => (int)RealX;

			private double RealX { get; set; }
			private double IncX { get; }

			public EdgeTableNode(int _RealX, double _IncX, int _MaxY)
			{
				RealX = _RealX;
				IncX = _IncX;
				MaxY = _MaxY;
			}

			public void Increment()
			{
				RealX += IncX;
			}
		}
	}
}
