using GraphColoringGame.Graphs;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GraphColoringGame
{
    /// <summary>
    /// Interaction logic for LevelPage.xaml
    /// </summary>
    public partial class GraphPage : Page
    {
        private Graph _graph;
        private ColorPickerPage _colorPicker;
        private Graphs.Color selectedColor => _colorPicker.selectedColor;

        private Dictionary<string,Button> buttons = new Dictionary<string,Button>();
        private Dictionary<string,Coord> coords = new Dictionary<string, Coord>();

        public GraphPage(Graph graph)
        {
            InitializeComponent();
            var gridLength = 40;
            _graph = graph;
            var gridBuilder = new GraphGridBuilder(GraphGrid, gridLength, _graph.width, _graph.height, _graph.xMin, _graph.yMin);
            _colorPicker = new ColorPickerPage(_graph.colors);

            foreach (var (coord, dirs) in graph.connections)
            {
                var button = new Button() { Uid = toUid(coord), Style = FindResource("RoundButton") as Style };
                button.Background = _graph.getVertexColor(coord).asBrush();
                button.Click += Vertex_Click;
                gridBuilder.addVertex(coord, button, dirs);
                buttons.Add(button.Uid, button);
                coords.Add(button.Uid, coord);
            }

            ColorPickerFrame.Content = _colorPicker;
        }

        /*
         * toUid - create vertex uid from coordinates.
         */
        private string toUid(Coord coord) => $"{coord.Item1},{coord.Item2}";

        private void Vertex_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            var coord = coords[b.Uid];
            if (_graph.canColor(coord, selectedColor))
            {
                var result = openMessageBox(b);
                // If user pressed OK, color the vertex
                if (result == MessageBoxResult.OK)
                {
                    _graph.colorVertex(coord, selectedColor);
                    b.Background = _graph.getVertexColor(coord).asBrush();
                    b.IsEnabled = false;
                }
            }
        }

        // Opens a Messagebox, and returns the result of the messageBox (OK or Cancel)
        private MessageBoxResult openMessageBox(Button btn)
        {
            var messageBoxText = $"Do you want to color this vertex {selectedColor}?";
            var caption = "Color Vertex";
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxImage icon = MessageBoxImage.Question;
            var result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
            return result;
        }
    }
}
