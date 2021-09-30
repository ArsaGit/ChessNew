using Chess.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Logic
{
	public class Menu
	{
		private readonly IDrawer drawer;
		private readonly string[] buttons = {"New game",
							"Continue",
							"Rating",
							"Exit"};

		private int currentButtonNumber = 0;

		private bool isRunning = true;

		private const ConsoleColor SelectedColor = ConsoleColor.Green;
		private const ConsoleColor DefaultTextColor = ConsoleColor.White;

		public Menu(IDrawer drawer)
		{
			this.drawer = drawer;
		}

		public void SelectButton()
		{
			ConsoleKeyInfo chInput = Console.ReadKey();

			switch (chInput.Key)
			{
				case ConsoleKey.UpArrow:
				case ConsoleKey.W:
					currentButtonNumber--;
					break;
				case ConsoleKey.DownArrow:
				case ConsoleKey.S:
					currentButtonNumber++;
					break;
				case ConsoleKey.Enter:
					isRunning = false;
					break;
			}

			if (currentButtonNumber < 0) currentButtonNumber = 3;
			if (currentButtonNumber > 3) currentButtonNumber = 0;
		}

		public void ResetColor()
		{
			Console.ForegroundColor = DefaultTextColor;
		}

		public bool IsRunning()
		{
			return isRunning;
		}

		public void Draw()
		{
			drawer.Draw(this);
		}

		public string[] GetButtons()
		{
			return buttons;
		}

		public int GetNumberOfCurrentButton()
		{
			return currentButtonNumber;
		}

		public ConsoleColor GetSelectedColor()
		{
			return SelectedColor;
		}
		public ConsoleColor GetDefaultTextColor()
		{
			return DefaultTextColor;
		}

		public bool isCurrentButton(int i)
		{
			return currentButtonNumber == i;
		}
	}
}
