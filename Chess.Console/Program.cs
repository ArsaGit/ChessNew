using System;
using Chess.Logic;

namespace Chess.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			ChessGame chess = new ChessGame(new ConsoleDrawer());
			chess.Run();
		}
	}
}
