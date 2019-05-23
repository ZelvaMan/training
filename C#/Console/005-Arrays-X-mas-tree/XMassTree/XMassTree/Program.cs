using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMassTree.Models;

namespace XMassTree
{
	class Program
	{
		static void Main(string[] args)
		{
			var drawer = new Models.TreeDrawer();
			drawer.run();
			Console.ReadKey();
		}
	}
}
