using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCreator.Models
{
	public class Creator
	{

		public string Path_ { get; private set; }
		public int FoldersCount { get; set; }
		public int FilesInFolders { get; set; }

		public Creator()
		{

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
		/// <summary>
		/// create a folder with folder's path in it
		/// </summary>
		/// <param name="path"></param>
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

		#region parsing
		/// <summary>
		/// parse properties from console
		/// </summary>
		public static Creator Parse()
		{
			return new Creator()
				{FilesInFolders = ParseFilesCount(50), FoldersCount = ParseFoldersCount(26), Path_ = ParsePath()};
		}

		private static string ParsePath()
		{
			Console.WriteLine("Write a path");
			while (true)
			{
				string path = Console.ReadLine();
				if (Directory.Exists(path))
					return path;
				Console.WriteLine("Write a valid path");
			}
		}

		private static int ParseFoldersCount(int MaxFolders)
		{
			Console.WriteLine("Write Folders count");
			while (true)
			{
				int parsed = 0;
				if (int.TryParse(Console.ReadLine(), out parsed))
					if (parsed < MaxFolders)
						return parsed;
					else
						Console.WriteLine($"cant create more that {MaxFolders} folders");
				else
					Console.WriteLine("Write a number");


			}
		}

		private static int ParseFilesCount(int MaxFiles)
		{
			Console.WriteLine("Write Files count");
			while (true)
			{
				int parsed = 0;
				if (int.TryParse(Console.ReadLine(), out parsed))
					if (parsed < MaxFiles)
						return parsed;
					else
						Console.WriteLine($"cant create more that {MaxFiles} files");
				else
					Console.WriteLine("Write a number");


			}

		}
		#endregion


	}
}
