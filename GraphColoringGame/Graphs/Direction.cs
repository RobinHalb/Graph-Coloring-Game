using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Graphs
{
    public enum Direction : int
    {
        Left = 0,
        Right = 1,
        Up = 2,
        Down = 3,
        UpLeft = 4,
        UpRight = 5,
        DownLeft = 6,
        DownRight = 7,
    }

    public static class DirectionExtension
    {
        public static Direction Opposite(this Direction dir)
        {
            switch (dir)
            {
                case Direction.Left: return Direction.Right;
                case Direction.Right: return Direction.Left;
                case Direction.Up: return Direction.Down;
                case Direction.Down: return Direction.Up;
                case Direction.UpLeft: return Direction.DownRight;
                case Direction.UpRight: return Direction.DownLeft;
                case Direction.DownLeft: return Direction.UpRight;
                case Direction.DownRight: return Direction.UpLeft;
                default: return dir;
            }
        }

        public static Coord MoveCoord(this Direction dir, Coord coords)
        {
            switch (dir)
            {
                case Direction.Left: return new Coord(coords.Item1 - 1, coords.Item2);
                case Direction.Right: return new Coord(coords.Item1 + 1, coords.Item2);
                case Direction.Up: return new Coord(coords.Item1, coords.Item2 - 1);
                case Direction.Down: return new Coord(coords.Item1, coords.Item2 + 1);
                case Direction.UpLeft: return new Coord(coords.Item1 - 1, coords.Item2 - 1);
                case Direction.UpRight: return new Coord(coords.Item1 + 1, coords.Item2 - 1);
                case Direction.DownLeft: return new Coord(coords.Item1 - 1, coords.Item2 + 1);
                case Direction.DownRight: return new Coord(coords.Item1 + 1, coords.Item2 + 1);
                default: return coords;
            }
        }
    }
}
