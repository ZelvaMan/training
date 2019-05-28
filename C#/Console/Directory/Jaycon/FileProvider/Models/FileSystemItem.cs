using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Jaycon.Models
{
	public class FileSystemItem
	{
		public bool IsFolder { get;  set; }
		public string Title { get;  set; }
		public string Path { get;  set; }
		public string Extension { get;  set; }
		public long Size { get;  set; }

	}
}
