using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Models
{
	public class Generator
	{


		public MinMaxStructure MinMax { get; private set; }
		private Random r;


		public int RandomNumber { get; private set; }

		public int NumberOfTries { get; private set; }

		public Generator(MinMaxStructure minAndMax)
		{
			r = new Random(DateTime.Now.Millisecond);
			//load values from config file
			MinMax = minAndMax;
		}

		/// <summary>
		/// generate a random number in range loaded from config life
		/// </summary>
		public void GenerateNumber()
		{
			RandomNumber = r.Next(MinMax.Min, MinMax.Max + 1);
		}



	}
}
