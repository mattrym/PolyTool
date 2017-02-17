using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PolyTool3.Polygons
{
	class Polygon
	{
		private Canvas Canvas { get; set; }
        public List<Vertex> Vertices { get; }
		public List<Edge> Edges { get; }

		/* Some useful properties for further calculations */
		public int Count => Vertices.Count;
		public bool Empty => Vertices.Count == 0;
		public bool Closed => First?.LeftEdge != null;
		public Vertex First => Vertices.FirstOrDefault();
		public Vertex Last => Vertices.LastOrDefault();

		public int minX => Vertices.Min(vertex => vertex.X);
		public int maxX => Vertices.Max(vertex => vertex.X);
		public int minY => Vertices.Min(vertex => vertex.Y);
		public int maxY => Vertices.Max(vertex => vertex.Y);

		public Polygon(Canvas _canvas)
		{
			Canvas = _canvas;
			Vertices = new List<Vertex>();
			Edges = new List<Edge>();
		}

		public Vertex AddVertex(int x, int y)
		{
			Vertex vertex = new Vertex(Canvas, this, x, y);
			if (!Empty)
			{
				Edge edge = new Edge(Canvas, this, Last, vertex);
				Last.RightEdge = vertex.LeftEdge = edge;
				Edges.Add(edge);
            }
			Vertices.Add(vertex);
			Canvas.Invalidate();
			return vertex;
		}

		public void NormalizeToCC()
		{
			if(Closed)
			{
				Vertex minX = Vertices.OrderBy(v => v.X).First();
				if(minX.RightEdge.V2.Y < minX.Y)
				{
					foreach (Vertex vertex in Vertices)
					{
						vertex.InvertEdges();
					}
					foreach (Edge edge in Edges)
					{
						edge.Invert();
					}
					Vertices.Reverse();
					Edges.Reverse();
				}
			}
		}

		public void MoveVertex(Vertex vertex, int x, int y)
		{
			vertex.X += x;
			vertex.Y += y;
			Canvas.Invalidate();
		}

		public void MovePolygon(int x, int y)
		{
			foreach(Vertex vertex in Vertices)
			{
				vertex.X += x;
				vertex.Y += y;			// without any additional calculations
			}
			Canvas.Invalidate();
		}

		public bool DeleteVertex(Vertex vertex)
		{
			if(!Closed || Count > 3)		// if polygon is not closed or not triangle
			{
				if(vertex.LeftEdge != null && vertex.RightEdge != null)
				{
					Vertex leftVertex = vertex.LeftEdge.V1, rightVertex = vertex.RightEdge.V2;
					Edge newEdge = new Edge(Canvas, this, leftVertex, rightVertex);
					leftVertex.RightEdge = rightVertex.LeftEdge = newEdge;
					Edges.Remove(vertex.LeftEdge);			// replacing two edges with one
					Edges.Remove(vertex.RightEdge);			// and removing unneccessary items
					Edges.Add(newEdge);		
				}
				else if(vertex.LeftEdge != null)
				{
					Edges.Remove(vertex.LeftEdge);			// only left edge to remove
					vertex.LeftEdge.V1.RightEdge = null;
				}
				else if(vertex.RightEdge != null)
				{
					Edges.Remove(vertex.RightEdge);			// only right edge to remove
					vertex.RightEdge.V2.LeftEdge = null;
				}
				Vertices.Remove(vertex);
				Canvas.Invalidate();
				return true;
			}
			MessageBox.Show("You cannot remove vertices from triangle.");
			return false;
		}

		public bool ClosePolygon()
		{
			if(!Closed && Count > 2)	// if not closed and at least triangle-to-be
			{
				Edge edge = new Edge(Canvas, this, Last, First);
				Last.RightEdge = First.LeftEdge = edge;		// just adding new edge
				Edges.Add(edge);                            // to the polygon
				NormalizeToCC();
				Canvas.Invalidate();
				return true;
			}
			MessageBox.Show("This polygon cannot be closed.");
			return false;
		}
	}
}
