using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PolyTool3.Graphic;
using PolyTool3.Graphic.Renderers;
using PolyTool3.Weiler_Atherton;
using PolyTool3.Polygons;

namespace PolyTool3
{
	partial class Canvas : UserControl
	{
		private Renderer renderer;
		private ContextMenu vertexContextMenu;

		private Vertex currentVertex;                               // brand-new vertex (not released since created)
		private Polygon mergingSubject;

		private List<Polygon> polygons;
		private Polygon DrawnPolygon => polygons.Last();        // currently drawn polygon
		private Polygon currentPolygon => currentVertex.Polygon;

		public Canvas(Renderer _renderer, List<Polygon> _polygons)
		{
			renderer = _renderer;
			polygons = _polygons;

			polygons.Add(new Polygon(this));
			vertexContextMenu = new ContextMenu(new MenuItem[] 
			{
				new MenuItem("Delete vertex", (sender, e) => 
				{
					currentPolygon.DeleteVertex(currentVertex);
					currentVertex = null;
				}),
				new MenuItem("Delete polygon", (sender, e) => 
				{
					DeletePolygon(currentPolygon);
					currentVertex = null;
				}),
				new MenuItem("Close polygon", (sender, e) => 
				{
					CloseDrawnPolygon();
					currentVertex = null;
				}),
				new MenuItem("Select/Unselect for merging", (sender, e) =>
				{
					MergePolygons(currentPolygon);
					currentVertex = null;
				})
			});

			InitializeComponent();
			SetStyle(ControlStyles.UserPaint |					// Style used for
				ControlStyles.AllPaintingInWmPaint |			// improving painting
				ControlStyles.OptimizedDoubleBuffer, true);		// on the control
		}

		/* Method for deleting specific polygon from Canvas */
		public void DeletePolygon(Polygon polygon)
		{
			if (polygon == polygons.Last())				// new polygon for drawing
				polygons.Add(new Polygon(this));
			polygons.Remove(polygon);
		}

		/* Method for closing drawn polygon and creating new, empty polygon */
		public void CloseDrawnPolygon()
		{
			DrawnPolygon.ClosePolygon();
			polygons.Add(new Polygon(this));
		}

		public Vertex FindVertexByCoordinates(int X, int Y, List<Polygon> polygons)
		{
			foreach (Polygon polygon in polygons)
			{
				foreach (Vertex vertex in polygon.Vertices)
				{
					int x = X - vertex.X, y = Y - vertex.Y;
					if (x * x + y * y < Vertex.RADIUS * Vertex.RADIUS)
						return vertex;
				}
			}
			return null;
		}

		public void MergePolygons(Polygon mergingWindow)
		{
			if(mergingSubject == null)
			{
				mergingSubject = mergingWindow;
			}
			else if(mergingSubject == mergingWindow)
			{
				mergingSubject = null;
			}
			else
			{
				Polygon union = PolygonMerger.Union(this, mergingWindow, mergingSubject);
				if(union != null)
				{
					polygons.Remove(mergingWindow);
					polygons.Remove(mergingSubject);
					polygons.Insert(0, union);
				}
				mergingSubject = null;
			}
		}

		/* Event handler - creating new vertex for current polygon on mouse click */
		private void Canvas_MouseDown(object sender, MouseEventArgs e)
		{
			currentVertex = FindVertexByCoordinates(e.X, e.Y, polygons);
			switch(e.Button)
			{
				case MouseButtons.Left:
					if (currentVertex == null)
					{
						currentVertex = DrawnPolygon.AddVertex(e.X, e.Y);
					}
					break;
				case MouseButtons.Right:
					if (currentVertex != null)
					{
						vertexContextMenu.Show(this, e.Location);
					}
					break;
			}
		}

		/* Event handler - adjusting new vertex for current position on mouse move */
		private void Canvas_MouseMove(object sender, MouseEventArgs e)
		{
			if(currentVertex != null)
			{
				switch (e.Button)
				{
					case MouseButtons.Left:
						currentPolygon.MoveVertex(currentVertex, e.X - currentVertex.X, e.Y - currentVertex.Y);
						break;
					case MouseButtons.Middle:
						currentPolygon.MovePolygon(e.X - currentVertex.X, e.Y - currentVertex.Y);
						break;
				}
			}
		}

		/* Event handler - releasing new vertex on mouse up */
		private void Canvas_MouseUp(object sender, MouseEventArgs e)
		{
			currentVertex = null;
		}

		/* Handler painting same edges (with DrawEdge method) parallelly */
		private void Canvas_Paint(object sender, PaintEventArgs e)
		{
			renderer.Invalidate();
			e.Graphics.DrawImageUnscaledAndClipped(renderer.Bitmap, ClientRectangle);
		}
	}
}
