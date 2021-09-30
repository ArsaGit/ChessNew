using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Logic
{
	public interface IDrawer
	{
		//void Draw(Game game);
		void Draw(Menu menu);
		void DrawNewGame();
		void DrawContinueGame();
		void DrawRating();
		void DrawExit();
		void Draw(Match match);
	}
}
