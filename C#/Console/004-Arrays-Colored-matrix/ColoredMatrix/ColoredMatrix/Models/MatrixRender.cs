using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoredMatrix.Models
{
	public class MatrixRender
	{
		private int collumbs, rows;

		private MatrixGenerator generator;
		private int[,] matrix;

		public MatrixRender()
		{
			collumbs = ParseNumber("Enter Number of collumbs", 50,1);
			rows = ParseNumber("Enter Number of rows", 50,1);
			generator = new MatrixGenerator(collumbs, rows);
		}

		public void Start()
		{
			matrix = generator.Generete();
			int divideNumber = 2;
			Console.BackgroundColor = ConsoleColor.White;
			while (true)
			{

				Draw(matrix, divideNumber);
				divideNumber = ParseNumber("Enter Number ", 20, 2);

			}
		}

		#region Parsing

		public int ParseNumber(string startMessage, int max, int min)
		{
			Console.WriteLine(startMessage);
			while (true)
			{
				int i = 0;
				if (int.TryParse(Console.ReadLine(), out i))
					if (i <= max && i >= min)
						return i;
					else
						Console.WriteLine($"Number must be smaller then {max} nad bigger then {min}");
				else
				Console.WriteLine("Please Write a number");
				

			}
		}

		#endregion

		#region drawing

		public void Draw(int[,] matrix, int DivideNumber)
		{

			Console.Clear();
			//get height and width of console
			int width, height;
			if (rows < 46)
				Console.BufferHeight = 50;
			else
				Console.BufferHeight = rows + 4;
			
			width = Console.BufferWidth;
			height = Console.BufferHeight;

			int widthMargin = (width - collumbs) / 2;
			int heightMargin = (height - rows) / 2;

			for (int col = 0; col < collumbs; col++)
			{
				for (int row = 0; row < rows; row++)
				{
					int num = matrix[col, row];
					Console.SetCursorPosition(widthMargin + row, heightMargin + col);
					Console.ForegroundColor = getColor(DivideNumber, num);
					Console.Write(num);
				}
			}
			Console.SetCursorPosition(0, matrix.GetLength(1) + heightMargin);
			Console.ForegroundColor = ConsoleColor.DarkGray;
		}
		private ConsoleColor getColor(int divideNumber, int number)
		{
			int numbersOfColors = 20 / divideNumber;
			int i = int.Parse(Math.Floor(number / (float)divideNumber).ToString());
			if (i > numbersOfColors)
			{
				int o = 0;
			}
			var v = (ConsoleColor)i;
			return v;
		}

		#endregion
	}
}
