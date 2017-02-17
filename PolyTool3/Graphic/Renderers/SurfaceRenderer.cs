using PolyTool3.Graphic.Lights;
using PolyTool3.Graphic.Structures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolyTool3.Graphic.Backgrounds;
using System.Windows.Forms;
using PolyTool3.Graphic.Surfaces;

namespace PolyTool3.Graphic.Renderers
{
	class SurfaceRenderer
	{
		private static int RGB2Int(int r, int g, int b)
		{
			return ((255 << 24) | (r << 16) | (g << 8) | b);
		}

		public IBackground Background { get; set; }
		public ILight Light { get; set; }
		public ISurface Function { get; set; }
		public DirectBitmap BumpMap { get; set; }

		public SurfaceRenderer(IBackground _background, ILight _light, ISurface _function, DirectBitmap _bumpMap = null)
		{
			Background = _background;
			Light = _light;
			Function = _function;
			BumpMap = _bumpMap;
		}

		public int RenderPixel(int X, int Y)
		{
			if (Background == null)
			{
				return 0;
			}
			double r = Background.R(X, Y) * 255;
			double g = Background.G(X, Y) * 255;
			double b = Background.B(X, Y) * 255;

			if(Light != null)
			{
				double cos = 0;
				Vector lightVector = Light.VectorToLight(X, Y, Function[X, Y]);
				Vector normalVector = BumpMap != null ? BumpedVector(X, Y) : Function.GradientVector(X, Y);
				if(lightVector.Z > 0)
				{
					cos = lightVector * normalVector;
				}

				r *= Light.R * cos;
				g *= Light.G * cos;
				b *= Light.B * cos;
			}

			return RGB2Int((int)r, (int)g, (int)b);
		}

		private Vector BumpedVector(int X, int Y)
		{
			double H = BumpMap.R(X, Y);
			double dHX = BumpMap.R(X + 1, Y) - H;
			double dHY = BumpMap.R(X, Y + 1) - H;

			Vector normalVector = Function.GradientVector(X, Y);
			return new Vector(normalVector.X + dHX, normalVector.Y + dHY, normalVector.Z + dHX * normalVector.X + dHY * normalVector.Y);
		}
	}
}
