using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCreator
{
	class Program
	{
		static void Main(string[] args)
		{
			Models.FileCreator creator = new Models.FileCreator(@"C:\Zkouska");
			creator.FoldersCount = 5;
			creator.FilesInFolders = 5;
			creator.Create();
			Console.ReadKey();

		}
	}
}
