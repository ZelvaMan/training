using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFileOperations.Models
{

	public class FileSummaryItem
	{
		private string name;
		private string extensoion;
		private long size;
		private DateTime createDate;
		private float sizeInMB;


		public string Name
		{
			get => name;
			set => name = value;
		}

		public float SizeInMb
		{
			get => sizeInMB;
		}

		public string Extensoion
		{
			get => extensoion;
			set => extensoion = value;
		}

		public long Size
		{
			get => size;
			set
			{
				size = value;
				sizeInMB = size / (1024 * 1024f);
			}
		}

		public DateTime CreateDate
		{
			get => createDate;

			set => createDate = value;
		}

		public override string ToString()
		{
			return $"{Name}  Size:{SizeInMb.ToString("0.####")}MB    created: {CreateDate.ToShortDateString()}";
		}
	}
}
