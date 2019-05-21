using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMassTree.Models
{
	class TreeMaker
	{
		private int trunk;

		public TreeMaker(int trunkStrong)
		{
			trunk = trunkStrong;
		}

		public List<string> DrawBranch(int trunkStrong, int MaxWidth)
		{
			int height = 5 + trunkStrong - 2;

		}
		

		public string GetLine(int trunkStrong, int width)
		{
			string s = "";
			if (trunkStrong == width)
			{
				int Widthplus = width + 1;
				for (int i = 0; i < Widthplus; i++)
				{
					s += "I";
				}

				return s;
			}

			if ((trunkStrong + 2) == width)
			{
				int Widthplus = width + 1;
				s += "*";
				for (int i = 0; i < Widthplus; i++)
				{
					s += "I";
				}
				s += "*";
				return s;
			}

			s += "*/";

			return s;
		}
	}
}
