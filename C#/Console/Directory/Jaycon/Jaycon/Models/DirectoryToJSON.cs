using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jaycon.Models;
using Newtonsoft.Json;

namespace Jaycon
{
	public class DirectoryToJSON
	{
		public String Convert(string path)
		{
			return  JsonConvert.SerializeObject(new DirectoryJSON(new  DirectoryInfo(path)));
		}
	}
}
