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
		private string[] buttons = {"New game",
							"Continue",
							"Rating",
							"Exit"};

		private int currentButtonNumber = 0;
		public int CurrentButtonNumber
		{
			get
			{
				return currentButtonNumber;
			}
			set
			{
				if (value < 0) currentButtonNumber = buttons.Length - 1;
				else if (value > 3) currentButtonNumber = 0;
				else currentButtonNumber = value;
			}
		}

		public bool IsRunning { get; set; }

		public Menu(IDrawer drawer)
		{
			this.drawer = drawer;
			IsRunning = true;
		}

		public void SelectButton()
		{
			ConsoleKeyInfo chInput = Console.ReadKey();

			switch (chInput.Key)
			{
				case ConsoleKey.UpArrow:
				case ConsoleKey.W:
					CurrentButtonNumber--;
					break;
				case ConsoleKey.DownArrow:
				case ConsoleKey.S:
					CurrentButtonNumber++;
					break;
				case ConsoleKey.Enter:
					IsRunning = false;
					break;
			}
		}

		public void Draw()
		{
			drawer.Draw(this);
		}

		public string[] GetButtons()
		{
			return buttons;
		}

		public bool isCurrentButton(int i)	//тут если с большой буквы метод, то программа не собирается
		{
			return CurrentButtonNumber == i;
		}
	}
}
