using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jaycon;
using Jaycon.Models;
using Jaycon.Providers;
using Json.Providers;
using Newtonsoft.Json;

namespace Json
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
