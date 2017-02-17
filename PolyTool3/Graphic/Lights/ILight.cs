using PolyTool3.Graphic.Structures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyTool3.Graphic.Lights
{
	interface ILight
	{
		double R { get; }
		double G { get; }
		double B { get; }
		int X { get; set; }
		int Y { get; set; }
		int Radius { get; set; }
		int Height { get; set; }
		int Angle { get; set; }
		Color Color { get; set; }
		Vector VectorToLight(double x, double y, double z);
	}
}
