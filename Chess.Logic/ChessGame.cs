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
		private readonly Menu menu;

		public ChessGame(IDrawer drawer)
		{
			this.drawer = drawer;
			menu = new Menu(drawer);
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
			} while (menu.IsRunning());
		}

		private void ActivateButton()
		{
			Console.Clear();
			int key = menu.GetNumberOfCurrentButton();

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
			Match match = new Match(drawer, player1);
			match.Draw();
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
