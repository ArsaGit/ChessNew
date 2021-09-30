using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Logic
{
	public class Player
	{
		private int score;

		public string Name { get; }
		public int Score
		{
			get { return score; }
			set
			{
				if (value >= 0) score = value;
				else throw new Exception("ERROR: Negative score");
			}
		}

		public Player(string name)
		{
			Name = name;
			score = 0;
		}
	}
}
