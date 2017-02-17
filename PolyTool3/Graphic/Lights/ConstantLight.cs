using PolyTool3.Graphic.Structures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyTool3.Graphic.Lights
{
	class ConstantLight : ILight
	{
		private double r, g, b;
		public Color Color { get; set; }

		public ConstantLight(Color _color)
		{
			Color = _color;
		}

		public Vector VectorToLight(double x, double y, double z)
		{
			return new Vector(0, 0, 1);
		}

		public double R => Color.R / 255.0;
		public double G => Color.G / 255.0;
		public double B => Color.B / 255.0;

		public int X
		{
			get { return 0; }
			set { }
		}
		public int Y
		{
			get { return 0; }
			set { }
		}
		public int Radius
		{
			get { return 0; }
			set { }
		}
		public int Height
		{
			get { return 0; }
			set { }
		}
		public int Angle
		{
			get { return 0; }
			set { }
		}
		
	}
}
