using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Logic
{
	public interface ILogic
	{
		void SelectButton(Menu menu);
		void SelectTile(Match match);
	}
}
