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

        public bool Move(int newX, int newY)
        {
            if ((x != newX || y != newY)
                && CanMove(newX, newY))
            {
                x = newX;
                y = newY;
                return true;
            }
            return false;
        }
    }

    public class Knight : Piece
    {
        public Knight(int x, int y) : base(x, y) { }

        public override bool CanMove(int newX, int newY)
        {
            return (Math.Abs(x - newX) == 2 && Math.Abs(y - newY) == 1
                || Math.Abs(y - newY) == 2 && Math.Abs(x - newX) == 1);
        }
        public override string ToString()
        {
            return "Knight";
        }
    }

    public class Queen : Piece
    {
        public Queen(int x, int y) : base(x, y) { }

        public override bool CanMove(int newX, int newY)
        {
            return (x == newX || y == newY ||
                Math.Abs(x - newX) == Math.Abs(y - newY));
        }
        public override string ToString()
        {
            return "Queen";
        }
    }

    public class Rook : Piece
    {
        public Rook(int x, int y) : base(x, y) { }

        public override bool CanMove(int newX, int newY)
        {
            return (x == newX || y == newY);
        }
        public override string ToString()
        {
            return "Rook";
        }
    }

    public class King : Piece
    {
        public King(int x, int y) : base(x, y) { }

        public override bool CanMove(int newX, int newY)
        {
            return (x == newX && Math.Abs(y - newY) == 1
            || y == newY && Math.Abs(x - newX) == 1
            || Math.Abs(x - newX) == Math.Abs(y - newY)
            && Math.Abs(y - newY) == 1);
        }
        public override string ToString()
        {
            return "King";
        }
    }

    public class Bishop : Piece
    {
        public Bishop(int x, int y) : base(x, y) { }

        public override bool CanMove(int newX, int newY)
        {
            return (Math.Abs(x - newX) == Math.Abs(y - newY));
        }
        public override string ToString()
        {
            return "Bishop";
        }
    }

    public class PiecesData
    {
        public string Name;
        public Dictionary<string, int> Data;

        public override string ToString()
        {
            return Name;
        }
    }

    static public class PieceFab
    {
        public static Piece Make(PiecesData figData)
        {
            Piece piece = null;

            switch (figData.Name)
            {
                case "King":
                    piece = new King(figData.Data["X"], figData.Data["Y"]);
                    break;
                case "Knight":
                    piece = new Knight(figData.Data["X"], figData.Data["Y"]);
                    break;
                case "Rook":
                    piece = new Rook(figData.Data["X"], figData.Data["Y"]);
                    break;
                case "Bishop":
                    piece = new Bishop(figData.Data["X"], figData.Data["Y"]);
                    break;
                case "Queen":
                    piece = new Queen(figData.Data["X"], figData.Data["Y"]);
                    break;
            }

            return piece;
        }

        public static List<PiecesData> InitFiguresData()
        {
            var figuresData = new List<PiecesData>();

            figuresData.Add(new PiecesData
            {
                Name = "Circle",
                Data = new Dictionary<string, int>
                {
                    { "X", 1 },
                    { "Y", 1 },
                }
            });

            figuresData.Add(new PiecesData
            {
                Name = "Line",
                Data = new Dictionary<string, int>
                {
                    { "X", 0 },
                    { "Y", 0 },
                    { "X", 100 },
                    { "Y", 100 }
                }
            });

            figuresData.Add(new PiecesData
            {
                Name = "Rectangle",
                Data = new Dictionary<string, int>
                {
                    { "X", 0 },
                    { "Y", 0 },
                    { "Height", 100 },
                    { "Weight", 100 }
                }
            });

            return figuresData;
        }
    }
}