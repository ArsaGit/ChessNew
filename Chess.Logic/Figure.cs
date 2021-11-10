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

		public abstract bool IsMoveCorrect();

		public char ToChar()
		{
			return OneLetter;
		}

		public object Clone()
		{
			return MemberwiseClone();
		}
	}

	public class Pawn : Figure
	{
		public override char OneLetter => 'P';
		public override string Name => "Пешка";

		public override bool IsMoveCorrect()
		{
			throw new NotImplementedException();
		}
	}

	public class Bishop : Figure
	{
		public override char OneLetter => 'B';
		public override string Name => "Слон";

		public override bool IsMoveCorrect()
		{
			throw new NotImplementedException();
		}
	}

	public class Knight : Figure
	{
		public override char OneLetter => 'N';
		public override string Name => "Конь";

		public override bool IsMoveCorrect()
		{
			throw new NotImplementedException();
		}
	}

	public class Rook : Figure
	{
		public override char OneLetter => 'R';
		public override string Name => "Ладья";

		public override bool IsMoveCorrect()
		{
			throw new NotImplementedException();
		}
	}

	public class Queen : Figure
	{
		public override char OneLetter => 'Q';
		public override string Name => "Королева";

		public override bool IsMoveCorrect()
		{
			throw new NotImplementedException();
		}
	}

	public class King : Figure
	{
		public override char OneLetter => 'K';
		public override string Name => "Король";

		public override bool IsMoveCorrect()
		{
			throw new NotImplementedException();
		}
	}
}
