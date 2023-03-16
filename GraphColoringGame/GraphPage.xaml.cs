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
        private Graphs.Color _selectedColor = Graphs.Color.Red;
        private Dictionary<string,Button> buttons = new Dictionary<string,Button>();
        private Dictionary<string,Coord> coords = new Dictionary<string, Coord>();

        public GraphPage(Graph graph)
        {
            InitializeComponent();
            _graph = graph;
            _graphGrid = new GraphGrid(40);

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

        /* Adds colorPicker to the ColorPicker grid in GraphPage - bottom-left of the screen */
        private void addColorPicker(List<Graphs.Color> colors)
        {
            var width = new GridLength(50);
            var height = new GridLength(40);
            var margin = new Thickness(15, 0, 0, 5);
            ColorPicker.RowDefinitions.Add(new RowDefinition() { Height = height });
            for (int i = 0; i < colors.Count; i++)
            {
                ColorPicker.ColumnDefinitions.Add(new ColumnDefinition() { Width = width });

                var button = new Button() { Uid = $"{colors[i]}", Margin = margin };
                Grid.SetRow(button, 0);
                Grid.SetColumn(button, i);
                colorButton(button);
                button.Click += colorPicker_Click;
                ColorPicker.Children.Add(button);
            }
        }
        // adds the appropriate color to the ColorPicker btns
        private void colorButton(Button btn)
        {
            var uid = btn.Uid.ToString();
            btn.Background = Graphs.ColorExtensions.ConvertToColor(uid).asBrush();
        }
        private void colorPicker_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            _selectedColor = Graphs.ColorExtensions.ConvertToColor(btn.Uid.ToString());
        }

        /*
         * toUid - create vertex uid from coordinates.
         */
        private string toUid(Coord coord) => $"{coord.Item1},{coord.Item2}";

        private void Vertex_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            var coord = coords[b.Uid];
            if (_graph.colorVertex(coord, _selectedColor))
            {
                var result = openMessageBox(b);
                // If user pressed OK, color the vertex
                if (result == MessageBoxResult.OK)
                {
                    b.Background = _graph.getVertexColor(coord).asBrush();
                    b.IsEnabled = false;
                }
            }
        }

        // Opens a Messagebox, and returns the result of the messageBox (OK or Cancel)
        private MessageBoxResult openMessageBox(Button btn)
        {
            var messageBoxText = $"Do you want to color this vertex {_selectedColor}?";
            var caption = "Color Vertex";
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxImage icon = MessageBoxImage.Question;
            var result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
            return result;
        }
    }
}
