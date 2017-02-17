using PolyTool3.Graphic.Backgrounds;
using PolyTool3.Graphic.Lights;
using PolyTool3.Graphic.Structures;
using PolyTool3.Graphic.Surfaces;
using PolyTool3.Polygons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyTool3.Graphic.Renderers
{
	class Renderer
	{
		private static readonly IBackground DEFAULT_BACKGROUND = null;
		private static readonly ILight DEFAULT_LIGHT = null;
		private static readonly ISurface DEFAULT_FUNCTION = new Plane(0);
		private static readonly DirectBitmap DEFAULT_BUMPMAP = null;

		private List<Polygon> polygons;
		private DirectBitmap directBitmap;
		private SurfaceRenderer surfaceRenderer;
		private PolygonDrawer polygonDrawer;
		private PolygonFiller polygonFiller;

		public IBackground Background
		{
			get { return surfaceRenderer.Background; }
			set { surfaceRenderer.Background = value; }
		}
		public ILight Light
		{
			get { return surfaceRenderer.Light; }
			set { surfaceRenderer.Light = value; }
		}
		public ISurface Function
		{
			get { return surfaceRenderer.Function; }
			set { surfaceRenderer.Function = value; }
		}
		public DirectBitmap BumpMap
		{
			get { return surfaceRenderer.BumpMap; }
			set { surfaceRenderer.BumpMap = value; }
		}
		public Bitmap Bitmap
		{
			get { return directBitmap.Bitmap; }
		}

		public Renderer(List<Polygon> _polygons)
		{
			polygons = _polygons;
			directBitmap = new DirectBitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

			polygonDrawer = new PolygonDrawer(directBitmap, polygons);
			surfaceRenderer = new SurfaceRenderer(DEFAULT_BACKGROUND, DEFAULT_LIGHT, DEFAULT_FUNCTION, DEFAULT_BUMPMAP);
			polygonFiller = new PolygonFiller(directBitmap, surfaceRenderer, polygons);
		}

		public void Invalidate()
		{
			using (Graphics graphics = Graphics.FromImage(directBitmap.Bitmap))
			{
				graphics.Clear(Color.Empty);
			}
			polygonFiller.FillPolygons();
			polygonDrawer.DrawEdges();
			polygonDrawer.DrawVertices();
		}
		
	}
}
