﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrunkMonk.Models
{
	public class GameDrawer
	{
		#region Constants

		private const char PersonChar = 'O';
		private const char PlayerChar = 'x';

		#endregion
		public int Height { private set; get; }
		public int Width { private set; get; }
		
		/// <summary>
		/// set Width and Height of Console
		/// </summary>
		/// <param name="height"></param>
		/// <param name="width"></param>
		public GameDrawer()
		{
			Height = Console.WindowHeight;
			Width = Console.WindowWidth;
			Console.BufferHeight = Height;
			Console.BufferWidth = Width;
		}

		public void Draw(int[,] Map, PositionStruct playerPositin)
		{
			Console.Clear();
			Console.CursorVisible = false;
			DrawMargin();
			DrawMap(Map);
			DrawAtPosition( playerPositin, ConsoleColor.Yellow, PlayerChar);
			
		}

		#region Drawing Methods
		/// <summary>
		/// draw a margin around screen
		/// </summary>
		private void DrawMargin()
		{
			Console.WindowHeight = Height;
			Console.BufferHeight = Height;
			Console.WindowWidth = Width + 1;
			for (int height = 0; height < Height - 1; height++)
			{

				//writing right and left lines
				Console.SetCursorPosition(0, height);
				Console.Write("|");
				Console.SetCursorPosition(Width - 1, height);
				Console.Write("|");

			}

			for (int width = 0; width < Width; width++)
			{
				Console.CursorVisible = true;
				Console.SetCursorPosition(width, 0);
				Console.Write("-");
				Console.SetCursorPosition(width, Height - 1);
				Console.Write("-");
			}
		}

		private void DrawMap(int[,] Map)
		{
			if (Map.GetLength(0) > Height || Map.GetLength(1) > Height)
				throw new Exception("Too big array");
			for (int width = 0; width < Map.GetLength(1); width++)
			{
				for (int height = 0; height < Map.GetLength(0); height++)
				{
					switch (Map[height,width])
					{
						case 0:
							break;
						case 1:
							DrawAtPosition(new PositionStruct(Height, Width),ConsoleColor.White, PersonChar );
							break;
					}
				}
			}
		}
		#endregion

		#region Helper Methods
		/// <summary>
		/// sets cursor position in gaming area
		/// </summary>
		/// <param name="left"></param>
		/// <param name="top"></param>
		private void SetCursore(int left, int top)
		{
			Console.SetCursorPosition(left + 1, top + 1);
		}

		/// <summary>
		/// draw text at position with specific color
		/// </summary>
		/// <param name="position"></param>
		/// <param name="color"></param>
		/// <param name="text"></param>
		private void DrawAtPosition(PositionStruct position, ConsoleColor color, char text)
		{
			Console.CursorVisible = false;
			var previousColor = Console.ForegroundColor;
			Console.ForegroundColor = color;
			SetCursore(position.Width, position.Height);
			Console.Write(text);
			Console.ForegroundColor = previousColor;
		}
		#endregion
	}
}
