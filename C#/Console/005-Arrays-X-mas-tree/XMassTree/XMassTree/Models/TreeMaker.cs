using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMassTree.Models
{
	public static class TreeMaker
	{
		static  private int MaxWidth = 0;

		static public Tree CreateTree(int trunkWidth)
		{
			MaxWidth = 0;
			List<string> tree = new List<string>();
			tree.Add("**");
			tree.Add("****");
			for (int i = 1; i <= trunkWidth / 2; i++)
			{
				tree.AddRange(CreateBranch(i * 2));
			}

			for (int i = 0; i < (trunkWidth +1); i++)
			{
				tree.Add(CreateTrunk(trunkWidth));
			}

			return new Tree(){DownTrunkHeight = trunkWidth,MaxWidth = MaxWidth, XMassTree = tree};
		}

		static public List<string> CreateBranch(int trunkWidth)
		{
			List<string> list = new List<string>();
			int height = 6 + ((trunkWidth / 2 - 1) * 2);
			for (int i = 0; i < height; i++)
			{
				int width = trunkWidth + i * 2;
				list.Add(CreateLine(trunkWidth, width));
			}
			return list;
		}


		#region Line Creation

		static private string CreateLine(int trunkWidth, int width)
		{
			string s = "";
			//only trunk
			if (trunkWidth == width)
				return CreateTrunk(width);

			//only one leaf
			if ((trunkWidth + 2) == width)
			{
				s += "*";
				s += CreateTrunk(trunkWidth);
				s += "*";
				return s;
			}

			s += "*/";
			int leafWidth = ((width - (trunkWidth + 2)) / 2) - 1;
			s += CreateLeaf(true, leafWidth);
			s += CreateTrunk(trunkWidth);
			s += CreateLeaf(false, leafWidth);
			s += @"\*";
			MaxWidth = s.Length;
			return s;
		}

		static private string CreateLeaf(bool startDirection, int leafWidth)
		{
			string s = "";
			leafWidth++;
			for (int i = 0; i < leafWidth; i++)
			{
				if (startDirection)
				{
					s += "/";
					startDirection = false;
				}
				else
				{
					s += @"\";
					startDirection = true;
				}
			}

			return s;
		}

		static private string CreateTrunk(int width)
		{
			string s = "";
			for (int i = 0; i < width; i++)
			{
				s += "I";
			}

			return s;
		}


		#endregion

	}
}
