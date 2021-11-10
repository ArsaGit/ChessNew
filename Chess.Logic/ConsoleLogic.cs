using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Logic
{
	public class ConsoleLogic : ILogic
	{
		public void SelectButton(Menu menu)
		{
			ConsoleKeyInfo chInput = Console.ReadKey();

			switch (chInput.Key)
			{
				case ConsoleKey.UpArrow:
				case ConsoleKey.W:
					menu.CurrentButtonNumber--;
					break;
				case ConsoleKey.DownArrow:
				case ConsoleKey.S:
					menu.CurrentButtonNumber++;
					break;
				case ConsoleKey.Enter:
					menu.IsRunning = false;
					break;
			}
		}

		public void SelectTile(Match match)
		{
			ConsoleKeyInfo chInput = Console.ReadKey();
			match.IsSelecting = true;

			switch (chInput.Key)
			{
				case ConsoleKey.UpArrow:
				case ConsoleKey.W:
					match.CurrentTileNumber[0]--;
					break;
				case ConsoleKey.DownArrow:
				case ConsoleKey.S:
					match.CurrentTileNumber[0]++;
					break;
				case ConsoleKey.LeftArrow:
				case ConsoleKey.A:
					match.CurrentTileNumber[1]--;
					break;
				case ConsoleKey.RightArrow:
				case ConsoleKey.D:
					match.CurrentTileNumber[1]++;
					break;
				case ConsoleKey.Enter:
					match.IsSelecting = false;
					break;
				case ConsoleKey.Escape:
					match.IsRunning = false;
					break;
			}
		}
	}
}
