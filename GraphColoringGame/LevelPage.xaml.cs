using System;
using System.Collections.Generic;
using System.Drawing;
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
        private Graph _graph;
        private GraphGrid _graphGrid;
        private Graphs.Color _selectedColor = Graphs.Color.Red;
        private Dictionary<string,Button> buttons = new Dictionary<string,Button>();
        private Dictionary<string,Coord> coords = new Dictionary<string, Coord>();

        public LevelPage(Graph graph)
        {
            InitializeComponent();
            _graph = graph;
            _graphGrid = new GraphGrid(30);
            for (int i = 0; i < _graph.width; i++) graphGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = _graphGrid.gridLength });
            for (int i = 0; i < _graph.height; i++) graphGrid.RowDefinitions.Add(new RowDefinition() { Height = _graphGrid.gridLength });
            foreach (var set in graph.connections) addVertex(set, graph.xMin, graph.yMin);
        }

        private void addVertex((Coord coord,IEnumerable<Direction> directions) e, int xMin, int yMin)
        {
            var button = new Button() { Uid = toUid(e.coord), Style = FindResource("RoundButton") as Style, Height = _graphGrid.vertexSize, Width = _graphGrid.vertexSize };
            button.Click += Vertex_Click;
            var x = e.coord.Item1 - xMin;
            var y = e.coord.Item2 - yMin;
            
            // Add connecting lines to graph
            foreach (var dir in e.directions)
            {
                var line = _graphGrid.getLine(dir);
                Grid.SetColumn(line, x);
                Grid.SetRow(line, y);
                graphGrid.Children.Add(line);
            }
            
            // Add vertex to graph
            Grid.SetColumn(button, e.coord.Item1-xMin);
            Grid.SetRow(button, e.coord.Item2-yMin);
            graphGrid.Children.Add(button);

            buttons.Add(button.Uid, button);
            coords.Add(button.Uid, e.coord);
        }

        /*
         * toUid - create vertex uid from coordinates.
         */
        private string toUid(Coord coord) => $"{coord.Item1},{coord.Item2}";

        private void Vertex_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            b.Background = _selectedColor.asBrush();
            b.IsEnabled = false;
        }
    }
}
