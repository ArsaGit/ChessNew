using System;
using Chess.Logic;

namespace Chess.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			ChessGame chess = new(new ConsoleDrawer(), new ConsoleLogic());
			chess.Run();


		}


	}
}
