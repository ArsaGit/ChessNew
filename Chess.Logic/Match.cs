
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

		enum FigureType
		{
			Pawn = 'P', Bishop = 'B', Knight = 'N',
			Rook = 'R', Queen = 'Q', King = 'K'
		}

		public Figure[,] Board { get; set; }
		private readonly char[,] boardNotation;

		private int[] currentTileNumber;
		public int[] CurrentTileNumber 
		{
			get
			{
				return currentTileNumber;
			}
			set
			{
				if (value[1] < 0) currentTileNumber[1] = Board.GetLength(1) - 1;
				else if (value[1] > 8) currentTileNumber[1] = 0;
				else currentTileNumber = value;

				if (value[0] < 0) currentTileNumber[0] = Board.GetLength(0) - 1;
				else if (value[0] > 8) currentTileNumber[0] = 0;
				else currentTileNumber = value;
			}
		}

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
			CurrentTileNumber = new int[] { 0, 0 };
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
			int[] coord1, coord2;
			do
			{
				Draw();
				SelectTile();
			} while (IsSelecting);

			coord1 = (int[])CurrentTileNumber.Clone();

			do
			{
				Draw();
				SelectTile();
			} while (IsSelecting);

			coord2 = (int[])CurrentTileNumber.Clone();

			MoveFigure(coord1, coord2);
		}

		private void MoveFigure(int[] coord1, int[] coord2)
		{
			Board[coord2[0], coord2[1]] = (Figure)Board[coord1[0], coord1[1]].Clone();
			Board[coord1[0], coord1[1]] = null;
		}

		public void Draw()
		{
			drawer.Draw(this);
		}

		public char[,] GetBoardNotation()
		{
			return boardNotation;
		}

		public bool IsSelectedFigure(int[] coords)
		{
			return CompareArrays(CurrentTileNumber, coords);
		}

		private void SelectTile()
		{
			logic.SelectTile(this);
		}

		private static bool CompareArrays<T>(T[] array1, T[] array2)
		{
			bool result = true;
			if (array1.Length != array2.Length) return false;
			else
			{
				for(int i = 0; i < array1.Length; i++)
				{
					if (!array1[i].Equals(array2[i])) result = false;
				}
			}
			return result;
		}

		private bool IsFigure(int[] coord)
		{
			return Board[coord[0], coord[1]] is Figure;
		}
	}
}
