using GraphColoringGame.Graphs;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        public ColorPickerPage(List<Graphs.Color> colors, bool enabled = true)
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
                ColorPickerGrid.Children.Add(button);

                if (enabled)
                {
                    button.Click += colorPicker_Click;
                    if (i == 0)
                    {
                        _selected = button;
                        _selected.BorderThickness = _borderSelected;
                    }
                }
                else button.IsEnabled = false;
            }
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
