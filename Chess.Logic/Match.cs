
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
		private Player player1;
		//private Player player2;

		enum FigureType
		{
			Pawn = 'P', Bishop = 'B', Knight = 'N',
			Rook = 'R', Queen = 'Q', King = 'K'
		}

		private Figure[,] board;
		private char[,] boardNotation;

		public Match(IDrawer drawer, Player player1)
		{
			this.drawer = drawer;
			this.player1 = player1;
			//this.player2 = player2;

			board = new Figure[,] {
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
		}

		public void Run()
		{

		}

		private void MakeTurn()
		{

		}

		//private string GetCoordinates()
		//{
		//	string coordinate;

		//	do
		//	{
		//		coordinate = Console.ReadLine();
		//		coordinate = StrOptimization(coordinate);
		//	} while (!IsCoordinateCorrect(coordinate));

		//	return coordinate;
		//}

		//private bool IsCoordinateCorrect(string coordinate)
		//{
		//	return 
		//}

		private string StrOptimization(string str)
		{
			return str.Trim().ToUpper();
		}

		public void Draw()
		{
			drawer.Draw(this);
		}

		public Figure[,] GetBoard()
		{
			return board;
		}

		public char[,] GetBoardNotation()
		{
			return boardNotation;
		}
	}
}
