using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCreator.Models
{
	class FileCreator
	{
		public string Path_ { get; private set; }
		public int FoldersCount { get; set; }
		public int FilesInFolders { get; set; }

		public FileCreator(string path)
		{
			Path_ = path;
		}

		public void CreateDirectory()
		{
			CreateFolders(Path_, FoldersCount);
		}

		private void CreateFolders(string path, int count)
		{
			for (int i = 0; i < count; i++)
			{
				string FolderPath = Path.Combine(path, CreateFolderName(i));
				if (!Directory.Exists(FolderPath))
					Directory.CreateDirectory(FolderPath);
				CreateFiles(FolderPath, FilesInFolders);

			}

		}

		private void CreateFiles(string path, int count)
		{
			for (int i = 0; i < count; i++)
			{
				string FilePath = Path.Combine(path, CreateFileName(i));
				CreateFile(FilePath);
			}
		}

		private void CreateFile(string path)
		{
			using (StreamWriter sw = new StreamWriter(path))
			{
				sw.WriteLine(path);
			}
			Console.WriteLine(path);
		}
		/// <summary>
		/// create folder name alphabet
		/// 1-A, 2-B, atd.
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		private string CreateFolderName(int number)
		{
			char ch = (char)(65 + number);
			return ch.ToString();
		}

		private string CreateFileName(int number)
		{
			string s = number.ToString();

			return s.PadLeft(3, '0') + ".txt";
		}

	}
}
