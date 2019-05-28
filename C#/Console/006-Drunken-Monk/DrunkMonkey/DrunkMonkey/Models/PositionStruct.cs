using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkMonkey.Models
{
	public struct  PositionStruct
	{
		public int Width;
		public int Height;

		public PositionStruct(int height, int width)
		{
			Width = width;
			Height = height;
		}
	}
}
