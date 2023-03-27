using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
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

namespace GraphColoringGame.Graphics
{
    /// <summary>
    /// Interaction logic for ExplanationGraphPage.xaml
    /// </summary>
    public partial class ExplanationGraphPage : Page
    {
        private ExplanationStep _step;
        private ColorPickerPage _colorPicker;
        private Thickness _outlineThickness = new Thickness(3);

        public ExplanationGraphPage(ExplanationStep step)
        {
            InitializeComponent();
            var gridLength = 40;
            _step = step;
            var gridBuilder = new GraphGridBuilder(GraphGrid, gridLength, _step.width, _step.height, _step.xMin, _step.yMin);
            _colorPicker = new ColorPickerPage(_step.colors, false);

            foreach (var (coord, vertex) in step.vertices)
            {
                var button = new Button() { Uid = toUid(coord), Style = FindResource("RoundButton") as Style };
                button.IsEnabled = false;
                button.Background = vertex.color.asBrush();
                if (vertex.outline != null)
                {
                    button.BorderThickness = _outlineThickness;
                    button.BorderBrush = new SolidColorBrush() { Color = (System.Windows.Media.Color) vertex.outline };
                }
                gridBuilder.addVertex(coord, button, vertex.directions);
            }

            ColorPickerFrame.Content = _colorPicker;
        }

        /*
         * toUid - create vertex uid from coordinates.
         */
        private string toUid(Coord coord) => $"{coord.Item1},{coord.Item2}";
    }
}
