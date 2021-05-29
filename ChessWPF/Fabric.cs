using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceFabric
{

    public abstract class Piece
    {
        public int x;
        public int y;

        public Piece(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public virtual bool CanMove(int x, int y)
        {
            return true;
        }

        public bool Move(int x, int y)
        {
            if ((this.x != x || this.y != y)
                && CanMove(x, y))
            {
                this.x = x;
                this.y = y;
                return true;
            }
            return false;
        }
    }

    public class Knight : Piece
    {
        public Knight(int x, int y) : base(x, y) { }

        public override bool CanMove(int x, int y)
        {
            return (Math.Abs(this.x - x) == 2 && Math.Abs(this.y - y) == 1
                || Math.Abs(this.y - y) == 2 && Math.Abs(this.x - x) == 1);
        }
    }

    public class Queen : Piece
    {
        public Queen(int x, int y) : base(x, y) { }

        public override bool CanMove(int x, int y)
        {
            return (this.x == x || this.y == y ||
                Math.Abs(this.x - x) == Math.Abs(this.y - y));
        }
    }

    public class Rook : Piece
    {
        public Rook(int x, int y) : base(x, y) { }

        public override bool CanMove(int x, int y)
        {
            return (this.x == x || this.y == y);
        }
    }

    public class King : Piece
    {
        public King(int x, int y) : base(x, y) { }

        public override bool CanMove(int x, int y)
        {
            return (this.x == x && Math.Abs(this.y - y) == 1
            || this.y == y && Math.Abs(this.x - x) == 1
            || Math.Abs(this.x - x) == Math.Abs(this.y - y)
            && Math.Abs(this.y - y) == 1);
        }
    }

    public class Bishop : Piece
    {
        public Bishop(int x, int y) : base(x, y) { }

        public override bool CanMove(int x, int y)
        {
            return (Math.Abs(this.x - x) == Math.Abs(this.y - y));
        }
    }

    public abstract class PieceMaker
    {
        public abstract Piece Make(int x, int y);

    }

    public class BishopMaker : PieceMaker
    {
        public override Piece Make(int x, int y)
        {
            return new Bishop(x, y);
        }
    }

    public class RookMaker : PieceMaker
    {
        public override Piece Make(int x, int y)
        {
            return new Rook(x, y);
        }
    }

    public class KnightMaker : PieceMaker
    {
        public override Piece Make(int x, int y)
        {
            return new Knight(x, y);
        }
    }

    public class QueenMaker : PieceMaker
    {
        public override Piece Make(int x, int y)
        {
            return new Knight(x, y);
        }
    }

    public class KingMaker : PieceMaker
    {
        public override Piece Make(int x, int y)
        {
            return new King(x, y);
        }
    }
}