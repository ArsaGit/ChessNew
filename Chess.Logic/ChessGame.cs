using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Logic
{
	public class ChessGame
	{
		private readonly IDrawer drawer;
		private readonly ILogic logic;
		private readonly Menu menu;

		public ChessGame(IDrawer drawer, ILogic logic)
		{
			this.drawer = drawer;
			this.logic = logic;
			menu = new Menu(drawer, logic);
		}

		public void Run()
		{
			RunMenu();
			ActivateButton();
		}

		private void RunMenu()
		{
			do
			{
				menu.Draw();
				menu.SelectButton();
			} while (menu.IsRunning);
		}

		private void ActivateButton()
		{
			Console.Clear();
			int key = menu.CurrentButtonNumber;

			switch (key)
			{
				case 0:
					StartNewGame();
					break;
				case 1:
					ContinueGame();
					break;
				case 2:
					OpenRating();
					break;
				case 3:
					ExitApp();
					break;
			}
		}

		private void StartNewGame()
		{
			Console.WriteLine("Enter Player1:");
			Player player1 = CreatePlayer();
			//Console.WriteLine("Enter Player2:");
			//Player player2 = CreatePlayer();
			Match match = new(drawer, logic, player1);
			match.Run();
		}

		private Player CreatePlayer()
		{
			string name = Console.ReadLine();
			return new Player(name);
		}

		private void ContinueGame()
		{
			drawer.DrawContinueGame();
		}

		private void OpenRating()
		{
			drawer.DrawRating();
		}

		private void ExitApp()
		{
			drawer.DrawExit();
		}
	}
}
