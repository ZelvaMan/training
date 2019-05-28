using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jaycon.Providers;
using Json.Providers;

namespace abc
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("Please enter a directory");
				return;
			}

			Console.WriteLine(FileProvider.GetFiles(args[0]).Count);
			Console.WriteLine(JSONProvider.ToJSON(FileProvider.GetFiles(args[0])));
			Console.ReadKey();
		}
	}
}
