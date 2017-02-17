using PolyTool3.Graphic.Backgrounds;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PolyTool3.Graphic.Structures
{
	class DirectBitmap : IDisposable, IBackground
	{
		public static DirectBitmap FromBitmap(Bitmap bitmap)
		{
			DirectBitmap directBitmap = new DirectBitmap(bitmap.Width, bitmap.Height);
			Graphics graphics = Graphics.FromImage(directBitmap.Bitmap);
			graphics.DrawImage(bitmap, Point.Empty);
			graphics.Dispose();
			return directBitmap;
		}

		public Bitmap Bitmap { get; private set; }
		public Int32[] Bits { get; private set; }
		public bool Disposed { get; private set; }
		public int Height { get; private set; }
		public int Width { get; private set; }

		protected GCHandle BitsHandle { get; private set; }

		public DirectBitmap(int width, int height)
		{
			Width = width;
			Height = height;
			Bits = new Int32[width * height];
			BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
			Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
		}

		public Int32 this[int x, int y]
		{
			get
			{
				x %= this.Width;
				y %= this.Height;
				return Bits[y * this.Width + x];
			}
			set
			{
				x %= this.Width;
				y %= this.Height;
				Bits[y * this.Width + x] = value;
			}
		}

		public double R(int x, int y) => ((this[x, y] >> 16) & 255) / (double) 255;

		public double G(int x, int y) => ((this[x, y] >> 8) & 255) / (double) 255;

		public double B(int x, int y) => (this[x, y] & 255) / (double) 255;

		public void Dispose()
		{
			if (Disposed) return;
			Disposed = true;
			Bitmap.Dispose();
			BitsHandle.Free();
		}
	}
}
