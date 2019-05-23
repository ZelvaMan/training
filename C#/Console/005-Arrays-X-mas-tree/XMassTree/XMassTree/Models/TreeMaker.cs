using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMassTree.Models
{
	static class TreeMaker
	{

		static public List<string> CreateTree(int trunkWidth)
		{
			List<string> tree = new List<string>();
			tree.Add("**");
			tree.Add("****");
			for (int i = 1; i <= trunkWidth / 2; i++)
			{
				tree.AddRange(CreateBranch(i * 2));
			}

			for (int i = 0; i < 6; i++)
			{
				tree.Add(CreateTrunk(trunkWidth));
			}

			return tree;
		}

		static public List<string> CreateBranch(int trunkWidth)
		{
			List<string> list = new List<string>();
			int height = 5 + ((trunkWidth / 2 - 1) * 2);
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
				s += CreateTrunk(width);
				s += "*";
				return s;
			}

			s += "*/";
			int leafWidth = ((width - (trunkWidth + 2)) / 2) - 1;
			s += CreateLeaf(true, leafWidth);
			s += CreateTrunk(trunkWidth);
			s += CreateLeaf(false, leafWidth);
			s += @"\*";
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
