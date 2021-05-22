using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        string figure = Console.ReadLine();

        int x1 = int.Parse(Console.ReadLine());
        int y1 = int.Parse(Console.ReadLine());
        int x2 = int.Parse(Console.ReadLine());
        int y2 = int.Parse(Console.ReadLine());

        Figure myFigure;

        switch (figure)
        {
            case "K":
                myFigure = new King(x1, y1);
                break;
            case "N":
                myFigure = new Knight(x1, y1);
                break;
            case "Q":
                myFigure = new Queen(x1, y1);
                break;
            case "R":
                myFigure = new Rook(x1, y1);
                break;
            case "B":
                myFigure = new Bishop(x1, y1);
                break;
            default:
                return;
        }

        Console.WriteLine(myFigure.Move(x2, y2) ? "Yes" : "No");
    }
}

class Figure
{
    public int x;
    public int y;

    public Figure(int x, int y)
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

class Knight : Figure
{
    public Knight(int x, int y) : base(x, y) { }

    public override bool CanMove(int x, int y)
    {
        return (Math.Abs(this.x - x) == 2 && Math.Abs(this.y - y) == 1
            || Math.Abs(this.y - y) == 2 && Math.Abs(this.x - x) == 1);
    }
}

class Queen : Figure
{
    public Queen(int x, int y) : base(x, y) { }

    public override bool CanMove(int x, int y)
    {
        return (this.x == x || this.y == y ||
            Math.Abs(this.x - x) == Math.Abs(this.y - y));
    }
}

class Rook : Figure
{
    public Rook(int x, int y) : base(x, y) { }

    public override bool CanMove(int x, int y)
    {
        return (this.x == x || this.y == y);
    }
}

class King : Figure
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

class Bishop : Figure
{
    public Bishop(int x, int y) : base(x, y) { }

    public override bool CanMove(int x, int y)
    {
        return (Math.Abs(this.x - x) == Math.Abs(this.y - y));
    }
}
