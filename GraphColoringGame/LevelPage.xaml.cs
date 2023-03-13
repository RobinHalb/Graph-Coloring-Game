using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GraphColoringGame.Graphs;

namespace GraphColoringGame
{
    /// <summary>
    /// Interaction logic for LevelPage.xaml
    /// </summary>
    public partial class LevelPage : Page
    {
        private double _gridSize;
        private double _vertexSize => _gridSize / 2;
        public LevelPage(Graph graph)
        {
            InitializeComponent();
            _gridSize = 30;
            var size = new GridLength(_gridSize);
            addColumns(graph.width, size);
            addRows(graph.height, size);
            foreach (var set in graph.connections) addButton(set, graph.xMin, graph.yMin);
        }

        private void addColumns(int cols, GridLength size)
        {
            for (int i = 0; i < cols; i++) graphGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = size });
        }
        private void addRows(int rows, GridLength size)
        {
            for (int i = 0; i < rows; i++) graphGrid.RowDefinitions.Add(new RowDefinition() { Height = size });
        }

        private void addButton((Coord coord,IEnumerable<Direction> directions) e, int xMin, int yMin)
        {
            var button = new Button() { Uid = $"{e.coord.Item1},{e.coord.Item2}", Style = FindResource("RoundButton") as Style, Height = _vertexSize, Width = _vertexSize };
            button.Click += Button_Click;
            var x = e.coord.Item1 - xMin;
            var y = e.coord.Item2 - yMin;

            var space = (_gridSize - _vertexSize) / 2;
            var corner = (Math.Sqrt(Math.Pow(_gridSize,2.0) * 2) - _vertexSize) / 2;

            
            foreach (var dir in e.directions)
            {
                var line = new Line() { Stroke = new SolidColorBrush() { Color = Colors.Black }, StrokeThickness = 1 };
                Grid.SetColumn(line, x);
                Grid.SetRow(line, y);

                switch (dir)
                {
                    case Direction.Left:
                        line.X1 = 0;
                        line.X2 = line.X1 + space;
                        line.Y1 = _gridSize / 2;
                        line.Y2 = line.Y1;
                        break;
                    case Direction.Right:
                        line.X1 = _gridSize;
                        line.X2 = line.X1 - space;
                        line.Y1 = _gridSize / 2;
                        line.Y2 = line.Y1;
                        break;
                    case Direction.Up:
                        line.X1 = _gridSize / 2;
                        line.X2 = line.X1;
                        line.Y1 = 0;
                        line.Y2 = line.Y1 + space;
                        break;
                    case Direction.Down:
                        line.X1 = _gridSize / 2;
                        line.X2 = line.X1;
                        line.Y1 = _gridSize;
                        line.Y2 = line.Y1 - space;
                        break;
                    case Direction.UpLeft:
                        line.X1 = 0;
                        line.X2 = line.X1 + corner;
                        line.Y1 = 0;
                        line.Y2 = line.Y1 + corner;
                        break;
                    case Direction.UpRight:
                        line.X1 = _gridSize;
                        line.X2 = line.X1 - corner;
                        line.Y1 = 0;
                        line.Y2 = line.Y1 + corner;
                        break;
                    case Direction.DownLeft:
                        line.X1 = 0;
                        line.X2 = line.X1 + corner;
                        line.Y1 = _gridSize;
                        line.Y2 = line.Y1 - corner;
                        break;
                    case Direction.DownRight:
                        line.X1 = _gridSize;
                        line.X2 = line.X1 - corner;
                        line.Y1 = _gridSize;
                        line.Y2 = line.Y1 - corner;
                        break;
                }
                graphGrid.Children.Add(line);
            }
            
            Grid.SetColumn(button, e.coord.Item1-xMin);
            Grid.SetRow(button, e.coord.Item2-yMin);
            graphGrid.Children.Add(button);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            b.Background = FindResource("Color.Red") as SolidColorBrush;
            b.IsEnabled = false;
        }
    }
}
