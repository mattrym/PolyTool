using PolyTool3.Graphic.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyTool3.Graphic.Renderers
{
	class SurfacePreprocessor
	{
		private static int RGB2Int(int r, int g, int b)
		{
			return (int)((255 << 24) | (r << 16) | (g << 8) | b);
		}

		private int cacheWidth;
		private int cacheHeight;
		private SurfaceRenderer renderer;
		
		public int?[,] ColorCache { get; }
		public Vector[,] VectorCache { get; }

		public SurfacePreprocessor(SurfaceRenderer _renderer)
		{
			renderer = _renderer;
			cacheWidth = SurfaceRenderer.CACHE_WIDTH;
			cacheHeight = SurfaceRenderer.CACHE_HEIGHT;
			ColorCache = new int?[cacheWidth, cacheHeight];
			VectorCache = new Vector[cacheWidth, cacheHeight];
		}

		public void Preprocess()
		{
			if(renderer.Background != null)
			{
				if(renderer.Light != null)
				{
					PreprocessBackgroundWithLightColor();
				}
				else
				{
					PreprocessBackgroundOnly();
				}
			}
			if(renderer.Function != null)
			{
				if(renderer.BumpMap != null)
				{
					PreprocessBumpedVectors();
				}
				else
				{
					PreprocessNormalVectors();
				}
			}
		}

		public void Flush()
		{
			Array.Clear(ColorCache, 0, ColorCache.Length);
		}

		private void PreprocessBackgroundOnly()
		{
			Parallel.For(0, cacheWidth, x =>
			{
				for (int y = 0; y < cacheHeight; ++y)
				{
					ColorCache[x, y] = SurfaceRenderer.RGB2Int(
						(int)(renderer.Background.R(x, y) * 255),
						(int)(renderer.Background.G(x, y) * 255),
						(int)(renderer.Background.B(x, y) * 255)
					);
				}
			});
		}

		private void PreprocessBackgroundWithLightColor()
		{
			Parallel.For(0, cacheWidth, x =>
			{
				for (int y = 0; y < cacheHeight; ++y)
				{
					ColorCache[x, y] = SurfaceRenderer.RGB2Int(
						(int)(renderer.Background.R(x, y) * renderer.Light.R * 255),
						(int)(renderer.Background.G(x, y) * renderer.Light.G * 255),
						(int)(renderer.Background.B(x, y) * renderer.Light.B * 255)
					);
				}
			});
		}

		private void PreprocessNormalVectors()
		{
			Parallel.For(0, cacheWidth, x =>
			{
				for (int y = 0; y < cacheHeight; ++y)
				{
					VectorCache[x, y] = renderer.Function.GradientVector(x, y);
				}
			});
		}

		private void PreprocessBumpedVectors()
		{
			Parallel.For(0, cacheWidth, x =>
			{
				for (int y = 0; y < cacheHeight; ++y)
				{
					VectorCache[x, y] = renderer.BumpedVector(x, y);
				}
			});
		}
	}
}
