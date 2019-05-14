using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileCreator.Models;

namespace FileCreator
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome, this program will create number of folders, and in every folder number of files that contains theyr own pathes");
			Creator cr = Creator.Parse();
			cr.CreateDirectory();
			Console.ReadKey();
		}
	}
}
