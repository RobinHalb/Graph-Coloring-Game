using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphColoringGame
{
    public class GraphGrid
    {
        public GridLength gridLength { get; private set; }
        public double squareSize { get; private set; }
        public double vertexSize { get; private set; }
        private double _middle;
        private double _sideDist;
        private double _cornerDist;
        public GraphGrid(int squareSize) 
        {
            this.squareSize = squareSize;
            vertexSize = squareSize / 2;
            _middle = squareSize / 2;
            _sideDist = (squareSize - vertexSize) / 2;
            _cornerDist = (Math.Sqrt(Math.Pow(squareSize, 2.0) * 2) - vertexSize) / 2;
            gridLength = new GridLength(squareSize);
        }

        public Line getLine(Direction dir)
        {
            var line = new Line() { Stroke = new SolidColorBrush() { Color = Colors.Black }, StrokeThickness = 1 };
            switch (dir)
            {
                case Direction.Left:
                    line.X1 = 0;
                    line.X2 = line.X1 + _sideDist;
                    line.Y1 = _middle;
                    line.Y2 = _middle;
                    break;
                case Direction.Right:
                    line.X1 = squareSize;
                    line.X2 = line.X1 - _sideDist;
                    line.Y1 = _middle;
                    line.Y2 = _middle;
                    break;
                case Direction.Up:
                    line.X1 = _middle;
                    line.X2 = _middle;
                    line.Y1 = 0;
                    line.Y2 = line.Y1 + _sideDist;
                    break;
                case Direction.Down:
                    line.X1 = _middle;
                    line.X2 = _middle;
                    line.Y1 = squareSize;
                    line.Y2 = line.Y1 - _sideDist;
                    break;
                case Direction.UpLeft:
                    line.X1 = 0;
                    line.X2 = line.X1 + _cornerDist;
                    line.Y1 = 0;
                    line.Y2 = line.Y1 + _cornerDist;
                    break;
                case Direction.UpRight:
                    line.X1 = squareSize;
                    line.X2 = line.X1 - _cornerDist;
                    line.Y1 = 0;
                    line.Y2 = line.Y1 + _cornerDist;
                    break;
                case Direction.DownLeft:
                    line.X1 = 0;
                    line.X2 = line.X1 + _cornerDist;
                    line.Y1 = squareSize;
                    line.Y2 = line.Y1 - _cornerDist;
                    break;
                case Direction.DownRight:
                    line.X1 = squareSize;
                    line.X2 = line.X1 - _cornerDist;
                    line.Y1 = squareSize;
                    line.Y2 = line.Y1 - _cornerDist;
                    break;
            }
            return line;
        }
    }
}
