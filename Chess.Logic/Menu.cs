
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
		private readonly ILogic logic;
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

		public Menu(IDrawer drawer, ILogic logic)
		{
			this.drawer = drawer;
			this.logic = logic;
			IsRunning = true;
		}

		public void SelectButton()
		{
			logic.SelectButton(this);
		}

		public void Draw()
		{
			drawer.Draw(this);
		}

		public string[] GetButtons()
		{
			return buttons;
		}

		public bool IsCurrentButton(int i)	//я тупой
		{
			return CurrentButtonNumber == i;
		}
	}
}
