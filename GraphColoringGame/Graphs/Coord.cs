using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Graphs
{
    public class Coord : Tuple<int, int>
    {

        public Coord(int x, int y) : base(x, y) { }

        public Coord neighbour(Direction dir) => dir switch
        {
            Direction.Left => new Coord(Item1 - 1, Item2),
            Direction.Right => new Coord(Item1 + 1, Item2),
            Direction.Up => new Coord(Item1, Item2 - 1),
            Direction.Down => new Coord(Item1, Item2 + 1),
            Direction.UpLeft => new Coord(Item1 - 1, Item2 - 1),
            Direction.UpRight => new Coord(Item1 + 1, Item2 - 1),
            Direction.DownLeft => new Coord(Item1 - 1, Item2 + 1),
            Direction.DownRight => new Coord(Item1 + 1, Item2 + 1),
            _ => this
        };

        public bool direction(Coord coord, out Direction dir)
        {
            dir = Direction.Left;
            if (coord.Item1 == Item1)
            {
                if (coord.Item2 == Item2 + 1) dir = Direction.Down;
                else if (coord.Item2 == Item2 - 1) dir = Direction.Up;
                else return false;
            }
            else if (coord.Item1 == Item1 - 1)
            {
                if (coord.Item2 == Item2) dir = Direction.Left;
                else if (coord.Item2 == Item2 - 1) dir = Direction.UpLeft;
                else if (coord.Item2 == Item2 + 1) dir = Direction.DownLeft;
                else return false;
            }
            else if (coord.Item1 == Item1 + 1)
            {
                if (coord.Item2 == Item2) dir = Direction.Right;
                else if (coord.Item2 == Item2 - 1) dir = Direction.UpRight;
                else if (coord.Item2 == Item2 + 1) dir = Direction.DownRight;
                else return false;
            }
            else return false;
            return true;
        }
    }
}
