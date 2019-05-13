using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFileOperations.Models
{
	public struct FileSummaryList
	{
		public string Name;
		public string Extensoion;
		public long size;
		public DateTime CreateDate;

		public override string ToString()
		{
			return $"{Name}{Extensoion}  size:{size}kB    created{CreateDate.ToShortDateString()}";
		}
	}
}
