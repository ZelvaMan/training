using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoredMatrix.Models
{
	class MatrixGenerator
	{
		private int Columns, Rows;
		private Random r;

		public MatrixGenerator(int columns, int rows)
		{
			Columns = columns;
			Rows = rows;
			r = new Random(DateTime.Now.Millisecond);
		}
		/// <summary>
		/// generate a array contains random numbers from 0 to 20
		/// </summary>
		/// <returns></returns>
		public int[,] Generete()
		{
			//[Collumb,Row]
			int[,] matrix = new int[Columns, Rows];
			for (int col = 0; col < Columns; col++)
			{
				for (int row = 0; row < Rows; row++)
				{
					matrix[col, row] = r.Next(0, 21);
				}
			}

			return matrix;
		}
	}
}
