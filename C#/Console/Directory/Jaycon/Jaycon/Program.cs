using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jaycon;
using Jaycon.Models;
using Newtonsoft.Json;

namespace Json
{
	class Program
	{
		static void Main(string[] args)
		{
			DirectoryToJSON dirjson = new DirectoryToJSON();
			Console.WriteLine(dirjson.Convert(@"C:\Users\jan.rada\Documents\GitHub\training\C#\Console"));
			Console.ReadKey();
		}
	}
}
