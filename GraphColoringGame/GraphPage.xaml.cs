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
    public partial class GraphPage : Page
    {
        private Graph _graph;
        private GraphGrid _graphGrid;
        private ColorPicker _colorPicker;
        private Graphs.Color _selectedColor = Graphs.Color.None;
        private Dictionary<string,Button> buttons = new Dictionary<string,Button>();
        private Dictionary<string,Coord> coords = new Dictionary<string, Coord>();
        

        public GraphPage(Graph graph)
        {
            InitializeComponent();
            _graph = graph;
            _graphGrid = new GraphGrid(30);
            _colorPicker = new ColorPicker(_graph.colors);

            for (int i = 0; i < _graph.width; i++) graphGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = _graphGrid.gridLength });
            for (int i = 0; i < _graph.height; i++) graphGrid.RowDefinitions.Add(new RowDefinition() { Height = _graphGrid.gridLength });
            foreach (var set in graph.connections) addVertex(set, graph.xMin, graph.yMin);
            addColorPicker(_graph.colors);
        }

        private void addVertex((Coord coord,IEnumerable<Direction> directions) e, int xMin, int yMin)
        {
            var button = new Button() { Uid = toUid(e.coord), Style = FindResource("RoundButton") as Style, Height = _graphGrid.vertexSize, Width = _graphGrid.vertexSize };
            button.Background = _graph.getVertexColor(e.coord).asBrush();
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

        /*adds new row under the vertecies and inserts the colorpicker at the bottom-left of the vertices*/
        private void addColorPicker(List<Graphs.Color> colors) 
        {
            var gridy = new GridLength(15);
            graphGrid.RowDefinitions.Add(new RowDefinition() { Height = gridy });
            graphGrid.RowDefinitions.Add(new RowDefinition() { Height = gridy });
            
            Grid.SetColumn(_colorPicker, 0);
            Grid.SetRow(_colorPicker, graphGrid.RowDefinitions.Count-1);
            graphGrid.Children.Add(_colorPicker);
            
        }

        /*
         * toUid - create vertex uid from coordinates.
         */
        private string toUid(Coord coord) => $"{coord.Item1},{coord.Item2}";

        private void Vertex_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            var coord = coords[b.Uid];
            if (_selectedColor != _colorPicker.getCurrentColor()) _selectedColor = _colorPicker.getCurrentColor();

            if (_selectedColor != Graphs.Color.None)
            {
                if (_graph.colorVertex(coord, _selectedColor))
                {
                    string messageBoxText = $"Do you want to color this vertex {_selectedColor}?";
                    string caption = "Color Vertex";
                    MessageBoxButton button = MessageBoxButton.OKCancel;
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxResult result;

                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    if (result == MessageBoxResult.Yes)
                    {
                        b.Background = _graph.getVertexColor(coord).asBrush();
                        b.IsEnabled = false;
                    }
                }
            }
            else 
            {
                string messageBoxText = "No Color selected, please select a color.";
                string caption = "No Color Selected";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }
    }
}
