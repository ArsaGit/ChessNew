namespace Chess.Console
{
	using System;
	using Chess.Logic;

	public class ConsoleDrawer : IDrawer
	{
		private const int boardWidth = 8;
		private const int boardHeight = 8;

		private readonly int topIndent = 5;
		private readonly int leftIndent = 10;

		private readonly int cellWidth = 3;
		private readonly int cellHeight = 1;

		private const ConsoleColor SelectedColor = ConsoleColor.Green;
		private const ConsoleColor DefaultTextColor = ConsoleColor.White;

		private readonly string[] buttons = {"New game",
							"Continue",
							"Rating",
							"Exit"};

		public void Draw(Menu menu)
		{
			Console.Clear();

			Console.WriteLine("Chess\n");

			for (int i = 0; i < buttons.Length; i++)
			{
				if (menu.IsCurrentButton(i))
				{
					Console.ForegroundColor = SelectedColor;
				}
				else
				{
					Console.ForegroundColor = DefaultTextColor;
				}
				Console.WriteLine(buttons[i]);
			}
			Console.ResetColor();
		}

		public void DrawContinueGame()
		{
			Console.WriteLine("Тут однажды будет Continue Game");
		}

		public void DrawRating()
		{
			Console.WriteLine("Тут однажды будет Rating");
		}

		public void DrawExit()
		{
			Console.WriteLine("Тут однажды будет Exit");
		}

		public void Draw(Match match)
		{
			Console.Clear();
			DrawBorders();
			DrawFigures(match);
			DrawBoardNotation(match);
			Console.CursorVisible = false;
		}	 

		private void DrawBorders()
		{
			Console.SetCursorPosition(leftIndent, topIndent);

			int maxX = boardWidth * cellWidth + boardWidth + 1;
			int maxY = boardHeight * cellHeight + boardHeight + 1;

			for (int y = 0; y < maxY; y++)
			{
				bool isFirstRow = y == 0;
				bool isLastRow = y == (maxY - 1);
				bool isBorderHorizontal = y % (cellHeight + 1) == 0;

				for (int x = 0; x < maxX; x++)
				{
					Console.SetCursorPosition(leftIndent + x, topIndent + y);

					bool isFirstColumn = x == 0;
					bool isLastColumn = x == (maxX - 1);
					bool isBorderVertical = x % (cellWidth + 1) == 0;
					bool isBorderCross = isBorderHorizontal && isBorderVertical;

					if (isBorderCross)
					{
						if (isFirstColumn && isFirstRow)
							Console.Write("┌");
						else if (isFirstRow && !isFirstColumn && !isLastColumn)
							Console.Write("┬");
						else if (isFirstRow && isLastColumn)
							Console.Write("┐");
						else if (isFirstColumn && !isFirstRow && !isLastRow)
							Console.Write("├");
						else if (!isFirstRow && !isLastRow && !isFirstColumn && !isLastColumn)
							Console.Write("┼");
						else if (isLastColumn && !isFirstRow && !isLastRow)
							Console.Write("┤");
						else if (isLastRow && isFirstColumn)
							Console.Write("└");
						else if (isLastRow && !isFirstColumn && !isLastColumn)
							Console.Write("┴");
						else if (isLastColumn && isLastRow)
							Console.Write("┘");
					}
					else
					{
						if (isBorderVertical) Console.Write("│");
						else if (isBorderHorizontal) Console.Write("─");
						else Console.Write(" ");
					}

					Console.ResetColor();
				}
			}
		}

		private void DrawFigures(Match match)
		{
			int xStep = cellWidth + 1;
			int yStep = cellHeight + 1;

			for (int row = 0; row < 8; row++)
			{
				for (int column = 0; column < 8; column++)
				{
					int x = leftIndent + xStep * column + 1;
					int y = topIndent + yStep * row + 1;

					Console.SetCursorPosition(x, y);

					char symbol;

					if(match.Board[row, column] is Figure)
					{
						symbol = match.Board[row, column].ToChar();
					}
					else
					{
						symbol = ' ';
					}

					if (match.IsSelectedFigure(new int[] { row, column }))
					{
						ColorTile(symbol);
					}

					Console.Write(symbol);

					Console.ResetColor();
				}
			}
		}

		private void DrawBoardNotation(Match match)
		{
			int xStep = cellWidth + 1;
			int yStep = cellHeight + 1;
			char[,] boardNotation = match.GetBoardNotation();

			for (int i = 0; i < 8; i++)
			{
				Console.SetCursorPosition(leftIndent + i * xStep + 1, topIndent - 1);
				Console.Write(boardNotation[0, i]);
				Console.SetCursorPosition(leftIndent - 1, topIndent + i * yStep + 1);
				Console.Write(boardNotation[1, i]);
			}
		}

		private static void ColorTile(char symbol)
		{
			if(symbol.Equals(' '))
			{
				Console.BackgroundColor = SelectedColor;
			}
			else
			{
				Console.ForegroundColor = SelectedColor;
			}
		}
	}
}
