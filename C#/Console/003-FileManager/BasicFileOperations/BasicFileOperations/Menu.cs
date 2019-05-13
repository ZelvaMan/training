using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFileOperations.Models
{
	class Menu
	{
		public void Launch()
		{

		}
		private void FileInfos()
		{

		}

		public void WriteFileInfo(bool fullInfo, string path)
		{
			foreach(string s in FileOperations.GetAllFilesinfo(fullInfo, path)){
				Console.WriteLine(s);
			}
		}
		
		private string ParseFullInfoBool()
		{
			return null;
		}

		private string ParseDirectory()
		{
			return null;
		}
	}
}
