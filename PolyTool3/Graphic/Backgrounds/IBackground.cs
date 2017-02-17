using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyTool3.Graphic.Backgrounds
{
	interface IBackground
	{
		double R(int x, int y);
		double G(int x, int y);
		double B(int x, int y);
	}
}
