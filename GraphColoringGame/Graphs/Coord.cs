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

        public Coord neighbour(Direction dir)
        {
            switch (dir)
            {
                case Direction.Left: return new Coord(Item1 - 1, Item2);
                case Direction.Right: return new Coord(Item1 + 1, Item2);
                case Direction.Up: return new Coord(Item1, Item2 - 1);
                case Direction.Down: return new Coord(Item1, Item2 + 1);
                case Direction.UpLeft: return new Coord(Item1 - 1, Item2 - 1);
                case Direction.UpRight: return new Coord(Item1 + 1, Item2 - 1);
                case Direction.DownLeft: return new Coord(Item1 - 1, Item2 + 1);
                case Direction.DownRight: return new Coord(Item1 + 1, Item2 + 1);
                default: return this;
            }
            
        }

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
