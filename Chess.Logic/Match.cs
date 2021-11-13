
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Logic
{
	public class Match
	{
		private readonly IDrawer drawer;
		private readonly ILogic logic;
		private Player player1;
		//private Player player2;

		public Figure[,] Board { get; set; }
		private readonly char[,] boardNotation;

		public int CurrentRow { get; set; }
		public int CurrentColumn { get; set; }

		public int MinRow { get; private set; }
		public int MinColumn { get; private set; }
		public int MaxRow { get; private set; }
		public int MaxColumn { get; private set; }

		public bool IsSelecting { get; set; }
		public bool IsRunning { get; set; }

		public Match(IDrawer drawer, ILogic logic, Player player1)
		{
			this.drawer = drawer;
			this.logic = logic;
			this.player1 = player1;
			//this.player2 = player2;

			Board = new Figure[,] {
				{ null, null, null, null, null, null, null, null},
				{ null, null, null, null, null, null, null, null},
				{ null, null, null, null, null, null, null, null},
				{ null, null, null, null, null, null, null, null},
				{ null, null, null, null, null, null, null, null},
				{ null, null, null, null, null, null, null, null},
				{ new Pawn(), new Pawn(), new Pawn(), new Pawn(), new Pawn(), new Pawn(), new Pawn(), new Pawn()},
				{ new Rook(), new Knight(), new Bishop(), new Queen(), new King(), new Bishop(), new Knight(), new Rook()}
			};

			boardNotation = new char[,] {
				{'A','B','C','D','E','F','G','H'},
				{'8','7','6','5','4','3','2','1'}
			};

			IsSelecting = true;
			IsRunning = true;

			CurrentRow = 0;
			CurrentColumn = 0;

			MinRow = 0;
			MinColumn = 0;
			MaxRow = Board.GetLength(0) - 1;
			MaxColumn = Board.GetLength(1) - 1;
		}

		public void Run()
		{
			do
			{
				MakeTurn();
			} while (IsRunning);
		}

		private void MakeTurn()
		{
			(int, int) pos1, pos2;

			do
			{
				SelectTile();
				pos1 = (CurrentRow, CurrentColumn);
			} while (!IsFigure(pos1));

			SelectTile();
			pos2 = (CurrentRow, CurrentColumn);

			MoveFigure(pos1, pos2);
		}

		private void MoveFigure((int , int) pos1, (int, int) pos2)
		{
			Figure figure = (Figure)Board[pos1.Item1, pos1.Item2].Clone();
			if (figure.IsMoveCorrect(pos1, pos2))
			{
				Board[pos2.Item1, pos2.Item2] = figure;
				Board[pos1.Item1, pos1.Item2] = null;
			}
		}

		public void Draw()
		{
			drawer.Draw(this);
		}

		public char[,] GetBoardNotation()
		{
			return boardNotation;
		}

		public bool IsSelectedTile(int row, int column)
		{
			return (CurrentRow == row && CurrentColumn == column);
		}

		private void SelectTile()
		{
			do
			{
				Draw();
				logic.SelectTile(this);
				CurrentRow = KeepInBounds(CurrentRow, MinRow, MaxRow);
				CurrentColumn = KeepInBounds(CurrentColumn, MinColumn, MaxColumn);
			} while (IsSelecting);
		}

		private bool IsFigure((int y, int x) pos)
		{
			return Board[pos.y, pos.x] is Figure;
		}

		private static int KeepInBounds(int value, int min, int max)
		{
			if (value < min) value = max;
			else if (value > max) value = min;
			else return value;
			return value;
		}
	}
}
