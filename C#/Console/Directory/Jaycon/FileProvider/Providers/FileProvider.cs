using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Jaycon;
using Jaycon.Models;

namespace Json.Providers
{
	public static class FileProvider
	{
		public static List<FileSystemItem> GetFiles(string path)
		{
			var directoryInfo = new DirectoryInfo(path);
			var files = directoryInfo.GetFileSystemInfos(".",SearchOption.AllDirectories);
			var data = new List<FileSystemItem>();
			foreach (var file in files)
			{
				FileSystemItem item = new FileSystemItem();
				if(file.Attributes.HasFlag( FileAttributes.Directory))
				{
					item.IsFolder = true;
				}
				else
				{
					item.IsFolder = false;
					item.Size = (file as FileInfo).Length;
					item.Extension = (file as FileInfo).Extension;
				}

				item.Title = file.Name;
				item.Path = file.FullName;
				data.Add(item);

			}

			return data;
		}
	}
}