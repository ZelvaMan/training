using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFileOperations.Models;

namespace BasicFileOperations
{
	class Program
	{
		static void Main(string[] args)
		{
			Menu m = new Menu();
			m.Launch();
			Console.ReadKey();
		}
	}
}
