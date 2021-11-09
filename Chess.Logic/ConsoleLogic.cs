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
	}
}
