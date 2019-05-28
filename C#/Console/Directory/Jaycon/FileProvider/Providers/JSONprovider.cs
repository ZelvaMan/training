using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jaycon.Models;
using Newtonsoft.Json;
namespace Jaycon.Providers
{
	public class JSONProvider
	{
		public static string ToJSON(List<FileSystemItem> objects)
		{
			return JsonConvert.SerializeObject(objects);

		}
	}
}
