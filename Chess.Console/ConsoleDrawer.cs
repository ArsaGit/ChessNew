namespace Chess.Console
{
	using System;
	using Chess.Logic;

	public class ConsoleDrawer : IDrawer
	{
		private const int boardWidth = 8;
		private const int boardHeight = 8;
		private int indent = 3;

		private int cellWidth = 3;
		private int cellHeight = 1;


		public void Draw(Menu menu)
		{
			Console.Clear();
			string[] buttons = menu.GetButtons();

			Console.WriteLine("Chess\n");

			for (int i = 0; i < buttons.Length; i++)
			{
				if (menu.isCurrentButton(i))
				{
					Console.ForegroundColor = menu.GetSelectedColor();
				}
				else
				{
					Console.ForegroundColor = menu.GetDefaultTextColor();
				}
				Console.WriteLine(buttons[i]);
			}

			menu.ResetColor();
		}

		public void DrawNewGame()
		{
			
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
			Figure[,] board = match.GetBoard();
			DrawBorders();
			DrawFigures(board);
			DrawBoardNotation(match);
			Console.SetCursorPosition(indent, indent + 16);			//это тут из-за того,
			Console.Write("└");										//что почему-то не прогружается самая нижняя граница
			Console.SetCursorPosition(indent + 1, indent + 16);		//
			Console.Write("─");
		}	 

		private void DrawBorders()
		{
			Console.SetCursorPosition(indent, indent);

			int maxX = boardWidth * cellWidth + boardWidth + 1;
			int maxY = boardHeight * cellHeight + boardHeight + 1;

			for (int y = 0; y < maxY; y++)
			{
				bool isFirstRow = y == 0;
				bool isLastRow = y == (maxY - 1);
				bool isBorderHorizontal = y % (cellHeight + 1) == 0;

				for (int x = 0; x < maxX; x++)
				{
					Console.SetCursorPosition(indent + x, indent + y);

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

		private void DrawFigures(Figure[,] board)
		{
			int xStep = cellWidth + 1;
			int yStep = cellHeight + 1;

			for (int row = 0; row < 8; row++)
				for (int column = 0; column < 8; column++)
				{
					int x = indent + xStep * column + 1;
					int y = indent + yStep * row + 1;

					Console.SetCursorPosition(x, y);
					if (board[row, column] is Figure)
						Console.Write(board[row, column].ToChar());
					else
						Console.Write(' ');
				}
		}

		private void DrawBoardNotation(Match match)
		{
			int xStep = cellWidth + 1;
			int yStep = cellHeight + 1;
			char[,] boardNotation = match.GetBoardNotation();

			for (int i = 0; i < 8; i++)
			{
				Console.SetCursorPosition(indent + i * xStep + 1, indent - 1);
				Console.Write(boardNotation[0, i]);
				Console.SetCursorPosition(indent - 1, indent + i * yStep + 1);
				Console.Write(boardNotation[1, i]);
			}
		}
	}
}
