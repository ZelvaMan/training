

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMassTree.Models
{
	class TreeDrawer
	{


		public TreeDrawer()
		{

		}
		#region Parsing
		/// <summary>
		/// parse number from console, ask user with 
		/// </summary>
		/// <param name="startMessage">ask user for number with this</param>
		/// <param name="max">maximum  number</param>
		/// <param name="min">minimum number</param>
		/// <returns></returns>
		public int ParseNumber(string startMessage, int max, int min)
		{
			Console.WriteLine(startMessage);
			while (true)
			{
				int i = 0;
				if (int.TryParse(Console.ReadLine(), out i))
					if (i <= max && i >= min)
						return i;
					else
						Console.WriteLine($"Number must be smaller then {max} nad bigger then {min}");
				else
					Console.WriteLine("Please Write a number");
			}
		}


		#endregion

		#region Drawing



		#endregion
	}
}
