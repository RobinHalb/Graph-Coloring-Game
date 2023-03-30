using GraphColoringGame.Graphs;
using GraphColoringGame.Play;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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

        private Dictionary<Coord,Button> buttons = new Dictionary<Coord,Button>();
        private Dictionary<string,Coord> coords = new Dictionary<string, Coord>();

        private IBob bob = new Bob2();

        private Player? _turn = Player.Alice;
        

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
                buttons.Add(coord, button);
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
            if (_turn != Player.Alice) return;
            var b = sender as Button;
            var coord = coords[b.Uid];
            if (_graph.canColor(coord, selectedColor))
            {
                if (confirmColor() == MessageBoxResult.OK)
                {
                    colorVertex(coord, selectedColor);
                    endTurn();
                }
            }
        }

        // Opens a Messagebox, and returns the result of the messageBox (OK or Cancel)
        private MessageBoxResult confirmColor() => MessageBox.Show($"Do you want to color this vertex {selectedColor}?", "Color Vertex", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.OK);

        private async void bobPlay()
        {
            await Task.Delay(1000);
            var move = bob.play(_graph);
            if (move != null)
            {
                (Coord coord, Color color) = move.Value;
                colorVertex(coord, color);
                endTurn();
            }
        }

        private void colorVertex(Coord coord, Color color)
        {
            _graph.colorVertex(coord, color);
            var b = buttons[coord];
            b.Background = _graph.getVertexColor(coord).asBrush();
            b.IsEnabled = false;
        }
        
        private void endTurn()
        {
            if (_graph.isDone)
            {
                _turn = null;
                TurnLabel.Content = "None";
                endGame();
            }
            else if (_turn == Player.Alice)
            {
                _turn = Player.Bob;
                TurnLabel.Content = _turn.ToString();
                bobPlay();
            }
            else if (_turn == Player.Bob)
            {
                _turn = Player.Alice;
                TurnLabel.Content = _turn.ToString();
            }
        }

        private void endGame()
        {
            foreach (var b in buttons.Values) b.IsEnabled = false;
            var messageBoxText = $"Player {_graph.winner} has won!";
            var caption = "Game Ended";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
        }
    }
}
