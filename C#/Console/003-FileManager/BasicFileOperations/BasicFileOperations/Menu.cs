using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFileOperations.Models
{
	class Menu
	{
		public void Launch()
		{
			while (true)
			{
				WriteMenu();
				switch (Console.ReadLine())
				{
					case "4":
						Console.WriteLine("press any button to close");
						return;
						break;
					case "1":
						FileInfos();
						break;
					case "2":
						DeleteFiles();
						break;
				}

				Console.ReadKey();
				Console.ReadKey();
				Console.Clear();
			}
		}

		#region Delete Files 2#
		/// <summary>
		/// delete Directory, path is parsed from console. Before delete ask user
		/// </summary>
		public void DeleteFiles()
		{
			//parse path from console
			string path = ParsePath("Write a directory, that you want to delete");
			// get number of files in directory
			int NumOfFiles = FileOperations.GetFilesInDirectory(path).Length;
			//ask user if he realy want to delete these files
			if (!ParseBool($"Do you really want to delete {NumOfFiles} Files in {path}")) 
				return;
			//write all deleted files
			WriteFileInfo(false, path);
			//delete files
			FileOperations.DeleteFiles(path);
		}


		#endregion

		#region files Info #1

		private void FileInfos()
		{
			WriteFileInfo(ParseBool( "Do you want full info about files (T|F)"),
				ParsePath("Please Write Path to file/folder"));
		}

		public void WriteFileInfo(bool fullInfo, string path)
		{
			foreach (string s in FileOperations.GetAllFilesinfo(fullInfo, path))
			{
				Console.WriteLine(s);
			}
		}


		#endregion

		#region Parsing
		/// <summary>
		/// parse bool true=t=1   false=f=0
		/// </summary>
		/// <param name="errorMessage"></param>
		/// <returns></returns>
		private bool ParseBool( string StartedMessage)
		{
			Console.WriteLine(StartedMessage);
			while (true)
			{
				switch (Console.ReadLine().ToLower())
				{
					case "1":
					case "t":
					case "true":
					case "y":
					case "yes":
						return true;
						break;

					case "0":
					case "f":
					case "false":
					case "n":
					case "no":
						return false;
						break;
				}

				Console.WriteLine("Write True,T,1 for true or false, f , 0 for false");
			}
		}

		private string ParsePath(string StartedMessage)
		{
			Console.WriteLine(StartedMessage);
			while (true)
			{
				string path = Console.ReadLine();
				if (Directory.Exists(path) && path != null)
					return path;
				Console.WriteLine("Write a valid path");
			}
		}


		#endregion

		#region Writing


		private void WriteMenu()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Write a number for select a action");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("1: Show the files in directory");
			Console.WriteLine("2: Delete all files in directory");
			Console.WriteLine("3: Create new directory");
			Console.WriteLine("4: Exit application");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.Write("Number:");
		}

		#endregion


	}
}
