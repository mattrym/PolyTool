using PolyTool3.Polygons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyTool3.Weiler_Atherton
{ 
	class PolygonMerger
	{
		enum POLYGON { WINDOW, SUBJECT }

		public static Polygon Union(Canvas canvas, Polygon window, Polygon subject)
		{
			Point startPoint;
			POLYGON startPolygon;
			FindAndOrderPoints(window, subject, out startPoint, out startPolygon);

			if (startPoint.X == int.MaxValue)
			{
				return window.minX < subject.minX ? window : subject;
			}

			Point currentPoint = startPoint;
			POLYGON currentPolygon = startPolygon;
			Polygon polygon = new Polygon(canvas);

			do
			{
				polygon.AddVertex(currentPoint.X, currentPoint.Y);

				if (currentPolygon == POLYGON.WINDOW)
				{
					currentPolygon = currentPoint.CrossPoint ? POLYGON.SUBJECT : POLYGON.WINDOW;
					currentPoint = currentPoint.CrossPoint ? currentPoint.SubjectNext : currentPoint.WindowNext;
				}
				else
				{
					currentPolygon = currentPoint.CrossPoint ? POLYGON.WINDOW : POLYGON.SUBJECT;
					currentPoint = currentPoint.CrossPoint ? currentPoint.WindowNext : currentPoint.SubjectNext;
				}
			} while (currentPoint != startPoint); //end do while there are more points

			polygon.ClosePolygon();
			return polygon;
		}

		private static void FindAndOrderPoints(Polygon window, Polygon subject, 
			out Point startPoint, out POLYGON startPolygon)
		{
			startPolygon = POLYGON.WINDOW;
			startPoint = new Point(int.MaxValue, int.MaxValue, false);
			WindowPointList windowPoints = new WindowPointList();
			SubjectPointList subjectPoints = new SubjectPointList();
			Dictionary<Edge, List<Point>> edgeCrossPoints = FindPoints(window, subject);

			foreach (Edge windowEdge in window.Edges)
			{
				Point vertexPoint = new Point(windowEdge.V1.X, windowEdge.V1.Y, false);
				if(vertexPoint.X < startPoint.X)
				{
					startPoint = vertexPoint;
					startPolygon = POLYGON.WINDOW;
				}
				windowPoints.Add(vertexPoint);

				edgeCrossPoints[windowEdge].Sort((p1, p2) => 
				{
					return Math.Abs(p1.X - windowEdge.V1.X) - Math.Abs(p2.X - windowEdge.V1.X);
				});
				foreach(Point point in edgeCrossPoints[windowEdge])
				{
					windowPoints.Add(point);
				}
			}
			foreach (Edge subjectEdge in subject.Edges)
			{
				Point vertexPoint = new Point(subjectEdge.V1.X, subjectEdge.V1.Y, false);
				if (vertexPoint.X < startPoint.X)
				{
					startPoint = vertexPoint;
					startPolygon = POLYGON.SUBJECT;
				}
				subjectPoints.Add(vertexPoint);

				edgeCrossPoints[subjectEdge].Sort((p1, p2) => 
				{
					return Math.Abs(p1.X - subjectEdge.V1.X) - Math.Abs(p2.X - subjectEdge.V1.X);
				});
				foreach (Point point in edgeCrossPoints[subjectEdge])
				{
					subjectPoints.Add(point);
				}
			}
		}

		private static Dictionary<Edge, List<Point>> FindPoints(Polygon window, Polygon subject)
		{
			Point crossPoint;
			Dictionary<Edge, List<Point>> edgeCrossPoints = new Dictionary<Edge, List<Point>>();

			foreach (Edge edge in window.Edges)
			{
				edgeCrossPoints.Add(edge, new List<Point>());
			}
			foreach (Edge edge in subject.Edges)
			{
				edgeCrossPoints.Add(edge, new List<Point>());
			}

			foreach (Edge windowEdge in window.Edges)
			{
				foreach (Edge subjectEdge in subject.Edges)
				{
					if (IntersectionPoint(windowEdge, subjectEdge, out crossPoint))
					{
						edgeCrossPoints[windowEdge].Add(crossPoint);
						edgeCrossPoints[subjectEdge].Add(crossPoint);
					}
				}
			}
			return edgeCrossPoints;
		}

		/* Just function counting cross product between */
		private static int CrossProduct(int dx1, int dy1, int dx2, int dy2)
		{
			return dx1 * dy2 - dx2 * dy1;
		}

		private static bool IntersectionPoint(Edge windowEdge, Edge subjectEdge, out Point crossPoint)
		{
			crossPoint = null;
			int v1deltaX = subjectEdge.V1.X - windowEdge.V1.X;
			int v1deltaY = subjectEdge.V1.Y - windowEdge.V1.Y;
			double crossProduct = CrossProduct(windowEdge.deltaX, windowEdge.deltaY, subjectEdge.deltaX, subjectEdge.deltaY);

			if(crossProduct != 0)
			{
				double p = CrossProduct(v1deltaX, v1deltaY, subjectEdge.deltaX, subjectEdge.deltaY) / crossProduct;
				double q = CrossProduct(v1deltaX, v1deltaY, windowEdge.deltaX, windowEdge.deltaY) / crossProduct;

				if (0 <= p && p <= 1 && 0 <= q && q <= 1)
				{
					int x = windowEdge.V1.X + (int)(windowEdge.deltaX * p);
					int y = windowEdge.V1.Y + (int)(windowEdge.deltaY * p);
					crossPoint = new Point(x, y, true);
					return true;
				}
			}
			return false;
		}
	}
}
