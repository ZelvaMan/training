using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrunkMonkey.Models;

namespace DrunkMonkey
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.SetWindowPosition(0, 0);
			var drawer = new Models.GameDrawer();
			drawer.Draw(null,new PositionStruct());
			int i = 1214465464;

			Console.SetCursorPosition(Console.WindowWidth/2, Console.WindowHeight/2);
			Console.ReadKey();
		}
	}
}
