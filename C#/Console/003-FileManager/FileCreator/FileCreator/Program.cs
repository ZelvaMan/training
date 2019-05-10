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
			Models.FileCreator creator = new Models.FileCreator(@"C:\Zkouska") {FoldersCount = 5, FilesInFolders = 5};
			creator.CreateDirectory();
			Console.ReadKey();

		}
	}
}
