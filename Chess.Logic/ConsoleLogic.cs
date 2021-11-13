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
					match.CurrentRow--;
					break;
				case ConsoleKey.DownArrow:
				case ConsoleKey.S:
					match.CurrentRow++;
					break;
				case ConsoleKey.LeftArrow:
				case ConsoleKey.A:
					match.CurrentColumn--;
					break;
				case ConsoleKey.RightArrow:
				case ConsoleKey.D:
					match.CurrentColumn++;
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
