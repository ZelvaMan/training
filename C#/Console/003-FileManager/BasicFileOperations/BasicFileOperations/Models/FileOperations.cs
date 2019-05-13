﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BasicFileOperations.Models
{
	public static class FileOperations
	{

		/// <summary>
		/// return info of all files in directory
		/// </summary>
		/// <param name="FullInfo">if true returnt <see cref="FileSummaryList"/>, else only full paths </param>
		/// <returns></returns>
		public static List<string> GetAllFilesinfo(bool FullInfo, string path)
		{
			//paths to all files in directories
			string[] directories = Directory.GetFiles(path, ".", SearchOption.AllDirectories);
			List<string> FileInfos = new List<string>();
			foreach(string file in directories)
			{ 
				FileInfos.Add(FullInfo ? GetFullFileInfo(file).ToString() : GetFileInfo(path));
			}
			return FileInfos;
		}

		#region private metods
		/// <summary>
		/// return name, extension, size and create date
		/// </summary>
		/// <param name="path">path to file</param>
		/// <returns>name extension size create date</returns>
		private static FileSummaryList GetFullFileInfo(string path)
		{
			FileInfo file = new FileInfo(path);
			return new FileSummaryList() { CreateDate = file.CreationTime, Extensoion = file.Extension, Name = file.Name, size = file.Length / 1000 };
		}
		/// <summary>
		/// return full path
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		private static string GetFileInfo(string path)
		{
			return Path.GetFileName(path);
		}
		#endregion
	}
}
