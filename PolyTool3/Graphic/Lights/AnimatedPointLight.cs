using PolyTool3.Graphic.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PolyTool3.Graphic.Lights
{
	class AnimatedPointLight : ILight
	{
		private int x, y, angle;

		public int X { get; set; }
		public int Y { get; set; }
		public int Radius { get; set; }
		public int Height { get; set; }
		public Color Color { get; set; }

		public double R => Color.R / 255.0;
		public double G => Color.G / 255.0;
		public double B => Color.B / 255.0;

		public AnimatedPointLight(int _X, int _Y, int _Height, int _Radius, Color _Color)
		{
			X = _X;
			Y = _Y;
			Height = _Height;
			Radius = _Radius;
			Color = _Color;
		}

		public Vector VectorToLight(double _x, double _y, double _height)
		{
			return new Vector(x - _x, y - _y, Height - _height);
		}

		public int Angle
		{
			get
			{
				return angle;
			}

			set
			{
				angle = value % 360;
				x = (int)(X + Radius * Math.Sin(angle * Math.PI / 180));
				y = (int)(Y + Radius * Math.Cos(angle * Math.PI / 180));
			}
		}
	}
}
