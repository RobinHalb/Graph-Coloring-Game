﻿using GraphColoringGame.Bob;
using GraphColoringGame.Graphs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

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

        private IBob bob;

        private Player? _turn = Player.Alice;
        private Run? _winningName;

        public GraphPage(Graph graph, Run? winningName = null)
        {
            InitializeComponent();
            _winningName = winningName;
            var gridLength = 40;
            _graph = graph;
            var gridBuilder = new GraphGridBuilder(GraphGrid, gridLength, _graph.width, _graph.height, _graph.xMin, _graph.yMin);
            _colorPicker = new ColorPickerPage(_graph.colors);

            foreach (var (coord, dirs) in graph.connections)
            {
                var button = new Button() { Uid = toUid(coord), Style = FindResource("RoundButton") as Style };
                button.Background = _graph.getVertexColor(coord).asBrush();
                if (_graph.getVertexColor(coord) == Graphs.Color.None)
                {
                    button.Click += Vertex_Click;
                } else
                {
                    button.IsEnabled = false;
                }
                
                gridBuilder.addVertex(coord, button, dirs);
                buttons.Add(coord, button);
                coords.Add(button.Uid, coord);
            }

            ColorPickerFrame.Content = _colorPicker;
            if (graph.colors.Count == 3) bob = new Bob3();
            else if (graph.colors.Count == 4) bob = new Bob4();
            else bob = new Bob2();
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

        /*
         * confirmColor - opens a Messagebox to confirm coloring and returns result.
         */
        private MessageBoxResult confirmColor() => MessageBox.Show($"Do you want to color this vertex {selectedColor}?", "Color Vertex", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.OK);

        /*
         * bobPlay - finds and plays Bob's move.
         */
        private async void bobPlay()
        {
            await Task.Delay(1000);
            var move = bob.play(_graph);
            if (move != null)
            {
                (Coord coord, Graphs.Color color) = move.Value;
                colorVertex(coord, color);
                if (bob.hasWinning && _winningName != null) _winningName.Text = Player.Bob.ToString();
                endTurn();
            }
        }

        /*
         * colorVertex - colors the given vertex with the given color and disables the button for the vertex.
         */
        private void colorVertex(Coord coord, Graphs.Color color)
        {
            _graph.colorVertex(coord, color);
            var b = buttons[coord];
            b.Background = _graph.getVertexColor(coord).asBrush();
            b.IsEnabled = false;
        }
        
        /*
         * endTurn - if the game on the graph is done, ends the game. Otherwise, updates the turn and calls for Bob's move if relevant.
         */
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

        /*
         * endGame - highlights any uncolorable vertices and announces the winner.
         */
        private void endGame()
        {
            foreach (var vertex in _graph.dangerousVertices)
            {
                if (vertex.isUncolorable && buttons.TryGetValue(vertex.coord, out var b)) b.BorderThickness = new Thickness(3);
            }
            foreach (var b in buttons.Values) b.IsEnabled = false;
            var messageBoxText = $"Player {_graph.winner} has won!";
            var caption = "Game Ended";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
        }
    }
}
