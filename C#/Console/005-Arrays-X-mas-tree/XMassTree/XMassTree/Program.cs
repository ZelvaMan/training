using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMassTree
{
	class Program
	{
		static void Main(string[] args)
		{

			var  v = new Models.TreeMaker();
			foreach (var str in v.CreateTree(6))
			{
				Console.WriteLine(str);
			}
			Console.ReadKey();
		}
	}
}
