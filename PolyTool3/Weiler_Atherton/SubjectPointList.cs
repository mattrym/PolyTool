using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyTool3.Weiler_Atherton
{
	class SubjectPointList
	{
		public Point Head { get; private set; } = null;
		public Point Tail { get; private set; } = null;
		public int Count { get; private set; } = 0;

		public void Add(Point _crossPoint)
		{
			if (Head == null)
			{
				Head = Tail = _crossPoint;
			}
			else
			{
				Tail.SubjectNext = _crossPoint;
				Tail = Tail.SubjectNext;
			}
			Tail.SubjectNext = Head;
			Count++;
		}
	}
}
