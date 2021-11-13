using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Logic
{
	public abstract class Figure : ICloneable
	{
		public abstract char OneLetter { get; }
		public abstract string Name { get; }

		//public bool isWhite;

		public abstract bool IsMoveCorrect((int y, int x) pos1, (int y, int x) pos2);

		public char ToChar()
		{
			return OneLetter;
		}

		public object Clone()
		{
			return MemberwiseClone();
		}

		public static int CalculateDelta(int n1, int n2)
		{
			return Math.Abs(n1 - n2);
		}
	}

	public class Pawn : Figure
	{
		public override char OneLetter => 'P';
		public override string Name => "Пешка";

		public override bool IsMoveCorrect((int y, int x) pos1, (int y, int x) pos2)
		{
			int deltaX = CalculateDelta(pos1.x, pos2.x);
			int deltaY = CalculateDelta(pos2.y, pos1.y);

			return (deltaX == 0 && (deltaY == 1 || deltaY == 2));
		}
	}

	public class Bishop : Figure
	{
		public override char OneLetter => 'B';
		public override string Name => "Слон";

		public override bool IsMoveCorrect((int y, int x) pos1, (int y, int x) pos2)
		{
			int deltaX = CalculateDelta(pos1.x, pos2.x);
			int deltaY = CalculateDelta(pos2.y, pos1.y);

			return (deltaX ==  deltaY && deltaX != 0 && deltaY != 0);
		}
	}

	public class Knight : Figure
	{
		public override char OneLetter => 'N';
		public override string Name => "Конь";

		public override bool IsMoveCorrect((int y, int x) pos1, (int y, int x) pos2)
		{
			int deltaX = CalculateDelta(pos1.x, pos2.x);
			int deltaY = CalculateDelta(pos2.y, pos1.y);

			return (
				(deltaX == 2 || deltaY == 2) && (deltaX == 1 || deltaY == 1)
				);
		}
	}

	public class Rook : Figure
	{
		public override char OneLetter => 'R';
		public override string Name => "Ладья";

		public override bool IsMoveCorrect((int y, int x) pos1, (int y, int x) pos2)
		{
			int deltaX = CalculateDelta(pos1.x, pos2.x);
			int deltaY = CalculateDelta(pos2.y, pos1.y);

			return (
				(deltaX == 0 || deltaY == 0) && (deltaX != 0 || deltaY != 0)
				);
		}
	}

	public class Queen : Figure
	{
		public override char OneLetter => 'Q';
		public override string Name => "Королева";

		public override bool IsMoveCorrect((int y, int x) pos1, (int y, int x) pos2)
		{
			int deltaX = CalculateDelta(pos1.x, pos2.x);
			int deltaY = CalculateDelta(pos2.y, pos1.y);

			return ((deltaX != 0 && deltaY !=0) &&
					deltaX == deltaY ||
					((deltaX == 0 || deltaY == 0) && (deltaX != 0 || deltaY != 0)));
		}
	}

	public class King : Figure
	{
		public override char OneLetter => 'K';
		public override string Name => "Король";

		public override bool IsMoveCorrect((int y, int x) pos1, (int y, int x) pos2)
		{
			int deltaX = CalculateDelta(pos1.x, pos2.x);
			int deltaY = CalculateDelta(pos2.y, pos1.y);

			return (deltaX == 1 || deltaY == 1);
		}
	}
}
