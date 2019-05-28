using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Jaycon.Models
{
	class DirectoryJSON
	{
		public bool IsFolder { get; private set; }
		public string Title { get; private set; }
		public List<DirectoryJSON> Childrens { get; private set; }
		public string Extension { get; private set; }
		public long Size { get; private set; }


		public DirectoryJSON(FileSystemInfo directory)
		{
			Title = directory.Name;
			if (directory.Attributes == FileAttributes.Directory)
			{
				IsFolder = true;
				Childrens = new List<DirectoryJSON>();
				foreach (var VARIABLE in (directory as DirectoryInfo).GetFileSystemInfos())
				{
					Childrens.Add(new DirectoryJSON(VARIABLE));
				}
			}
			else
			{
				IsFolder = false;
				Extension = directory.Extension;
				if (directory is FileInfo)
					Size = (directory as FileInfo).Length;
			}
		}
	}
}
