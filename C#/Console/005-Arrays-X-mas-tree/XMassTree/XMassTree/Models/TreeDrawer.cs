

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMassTree.Models
{
	class TreeDrawer
	{
		public void run()
		{
			while (true)
			{
				Console.Clear();
				int trunkwidth = ParseNumber("Please enter trunk width", 20, 2);
				Console.Clear();
				Tree tree = TreeMaker.CreateTree(trunkwidth);
				DrawTree(tree);
				Console.ReadKey();
			}
		}

		#region Parsing
		/// <summary>
		/// parse number from console, ask user with 
		/// </summary>
		/// <param name="startMessage">ask user for number with this</param>
		/// <param name="max">maximum  number</param>
		/// <param name="min">minimum number</param>
		/// <returns></returns>
		static public int ParseNumber(string startMessage, int max, int min)
		{
			Console.WriteLine(startMessage);
			while (true)
			{
				int i = 0;
				if (int.TryParse(Console.ReadLine(), out i))
					if (i <= max && i >= min)
						if ((i % 2) == 0)
							return i;
						else
							Console.WriteLine("Please enter even number");

					else
						Console.WriteLine($"Number must be smaller then {max} nad bigger then {min}");



				else
					Console.WriteLine("Please Write a number");
			}
		}


		#endregion

		#region Drawing

		public void DrawTree(Tree XMassTree)
		{
			int MaxWidth = XMassTree.MaxWidth;
			foreach (var str in XMassTree.XMassTree)
			{
				int width = str.Length;
				int sidePadding = (MaxWidth - width) / 2;
				string s = str.PadLeft(width + sidePadding, ' ');
				s = s.PadRight(MaxWidth, ' ');
				WriteLine(s);

			}
		}

		private void WriteLine(string s)
		{
			foreach (char ch in s)
			{
				switch (ch)
				{
					case '/':
					case '\\':
						Console.ForegroundColor = ConsoleColor.DarkGreen;
						break;
					default:
						Console.ResetColor();
						break;
					case 'I':
						Console.ForegroundColor = ConsoleColor.DarkYellow;
						break;
					case '*':
						Console.ForegroundColor = ConsoleColor.Green;
						break;

				}
				Console.Write(ch);
			}
			Console.Write(Environment.NewLine);
		}
		#endregion
	}
}
