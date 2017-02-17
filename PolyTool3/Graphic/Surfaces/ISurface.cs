using PolyTool3.Graphic.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyTool3.Graphic.Surfaces
{
	interface ISurface
	{
		Vector GradientVector(int x, int y);
		double this[int x, int y] { get; }
	}
}
