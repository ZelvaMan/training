﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoredMatrix.Models
{
	public class MatrixRender
	{
		private int columns, rows;

		private MatrixGenerator generator;

		private const int PadCharacters = 2;
		private const string Divider = " | ";
		private int[,] matrix;

		public MatrixRender()
		{
			columns = ParseNumber("Enter Number of columns", 50, 1);
			rows = ParseNumber("Enter Number of rows", 50, 1);
			generator = new MatrixGenerator(columns, rows);
		}
		public void Start()
		{
			//create a new generator
			matrix = generator.Generete();
			//set default divide number
			int divideNumber = 2;
			Console.BackgroundColor = ConsoleColor.White;
			while (true)
			{
				//draw a matrix 
				Draw(matrix, divideNumber);
				//get new divide number
				divideNumber = ParseNumber("Enter Number ", 20, 2);

			}
		}

		#region Parsing
		/// <summary>
		/// parse number from console, ask user with 
		/// </summary>
		/// <param name="startMessage">ask user for number with this</param>
		/// <param name="max">maximum  number</param>
		/// <param name="min">minimum number</param>
		/// <returns></returns>
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
		/// <summary>
		/// draw a matrix
		/// </summary>
		/// <param name="matrix">2 dimension array</param>
		/// <param name="divideNumber">number from 2 to 200, with it it makes colors</param>
		public void Draw(int[,] matrix, int divideNumber)
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
			//get margin
			int widthMargin = (width - columns) / 2;
			int heightMargin = (height - rows) / 2;

			for (int col = 0; col < columns; col++)
			{
				for (int row = 0; row < rows; row++)
				{
					int number = matrix[col, row];
					Console.SetCursorPosition( widthMargin + (col * (PadCharacters + Divider.Length)),  heightMargin + row);
					Console.ForegroundColor = getColor(divideNumber, number);
					string numberstr = number.ToString().PadLeft(PadCharacters, '0');
					if(col != 0)
						Console.Write(Divider + numberstr);
					else
						Console.Write(numberstr.PadLeft(PadCharacters + Divider.Length , ' '));

					}
			}
			//reset cursor location under matrix
			Console.SetCursorPosition(0, matrix.GetLength(1) + heightMargin);
			Console.ForegroundColor = ConsoleColor.DarkGray;
		}
		/// <summary>
		/// get color based on divide number
		/// </summary>
		/// <param name="divideNumber"></param>
		/// <param name="number"></param>
		/// <returns></returns>
		private ConsoleColor getColor(int divideNumber, int number)
		{
			//get how many color can be in 20/divide number
			int numbersOfColors = 20 / divideNumber;
			int i = int.Parse(Math.Floor(number / (float)divideNumber).ToString());
			var v = (ConsoleColor)i;
			return v;
		}

		#endregion
	}
}
