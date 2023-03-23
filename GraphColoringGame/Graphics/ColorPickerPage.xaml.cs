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

namespace GraphColoringGame
{
    /// <summary>
    /// Interaction logic for ColorPickerPage.xaml
    /// </summary>
    public partial class ColorPickerPage : Page
    {
        private Button _selected = new Button();
        public Graphs.Color selectedColor => Graphs.ColorExtensions.ConvertToColor(_selected.Uid);
        private Thickness _borderSelected = new Thickness(5);
        private Thickness _borderDefault = new Thickness(0);

        public ColorPickerPage(List<Graphs.Color> colors)
        {
            InitializeComponent();
            var width = new GridLength(50);
            var height = 40.0;
            var margin = new Thickness(15, 0, 0, 5);

            for (int i = 0; i < colors.Count; i++)
            {
                ColorPickerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = width });

                var button = new Button() { Uid = $"{colors[i]}", Style = FindResource("NoHoverButton") as Style, Margin = margin, Height = height };
                Grid.SetColumn(button, i);
                button.Background = colors[i].asBrush();
                button.BorderBrush = new SolidColorBrush(Colors.Black);
                button.Click += colorPicker_Click;
                ColorPickerGrid.Children.Add(button);
                if (i == 0) _selected = button;
            }
            _selected.BorderThickness = _borderSelected;
        }

        private void colorPicker_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                _selected.BorderThickness = _borderDefault;
                btn.BorderThickness = _borderSelected;
                _selected = btn;
            }
        }
    }
}
