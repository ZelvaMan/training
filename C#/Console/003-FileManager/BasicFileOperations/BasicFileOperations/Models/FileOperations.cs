using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BasicFileOperations.Models
{
	public static class FileOperations
	{

		#region FileInfos
		





		/// <summary>
		/// return info of all files in directory
		/// </summary>
		/// <param name="FullInfo">if true return <see cref="FileSummaryItem"/>, else only full paths </param>
		/// <returns></returns>
		public static List<string> GetAllFilesInfo(bool FullInfo, string path)
		{
			//paths to all files in directories
			try
			{
				
				string[] directories = Directory.GetFiles(path, ".", SearchOption.AllDirectories);
				List<string> fileInfos = new List<string>();
				foreach (string file in directories)
				{
					fileInfos.Add(FullInfo ? GetFullFileInfo(file).ToString() : GetFileInfo(file));
				}
				return fileInfos;
			}
			catch (Exception e)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine(e);
				Console.WriteLine("Access Denied, check your permissions");
				Console.ForegroundColor = ConsoleColor.DarkGray;
			}

			return null;

		}

		/// <summary>
		/// return name, extension, Size and create date
		/// </summary>
		/// <param name="path">path to file</param>
		/// <returns>name extension Size create date</returns>
		private static FileSummaryItem GetFullFileInfo(string path)
		{
			FileInfo file = new FileInfo(path);
			return new FileSummaryItem() { CreateDate = file.CreationTime, Extensoion = file.Extension, Name = file.Name, Size = file.Length  };
		}
		/// <summary>
		/// return full path
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		private static string GetFileInfo(string path)
		{
			return Path.GetFullPath(path);
		}
		#endregion



		public static int GetNumberFilesInDirectory(string path)
		{
			return Directory.GetFiles(path,".", SearchOption.AllDirectories).GetLength(0);
		}

		public static  string[] GetFilesInDirectory(string path)
		{
			return Directory.GetFiles(path,".",SearchOption.AllDirectories);
		}

		#region Delete



		public static void DeleteFiles(string path)
		{
			Directory.Delete(path,true);
		}

		#endregion

		#region CreateDirectory
		/// <summary>
		/// C:/aaa/bbb => C:/aaa
		/// </summary>
		/// <param name="path"></param>
		public static string DeleteLastPArtOfPath(string path)
		{
			int LastIndexLeght = path.Split('/').Last().Length + 1;
			string s =  path.Substring(0, path.Length - LastIndexLeght);
			return s;
		}

		#endregion
	}
}
