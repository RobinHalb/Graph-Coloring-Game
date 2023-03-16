using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        private List<Graphs.Color> _colors;
        private int _widthHeight;
        private Graphs.Color _currentSelectColor = Graphs.Color.None;
        public ColorPicker(List<Graphs.Color> colors)
        {
            InitializeComponent();
            _colors = colors;
            _widthHeight = 40;
            for (int i = 0; i < _colors.Count(); i++) addColorButton(_colors[i], i);
            addColumns(2, new GridLength(pixels: 40));
            addRows(1, new GridLength(pixels: 40));


        }

        public Graphs.Color getCurrentColor() 
        {
            return _currentSelectColor;
        }
        private void addColumns(int cols, GridLength size)
        {
            for (int i = 0; i < cols; i++) ColorPickerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = size });
        }
        private void addRows(int rows, GridLength size)
        {
            for (int i = 0; i < rows; i++) ColorPickerGrid.RowDefinitions.Add(new RowDefinition() { Height = size });
        }

        // adds a Button to the ColorPicker with color corresponding to the Color enum from Graphs
        private void addColorButton(Graphs.Color color, int index)
        {
            var Cbutton = new CButton(color) { Uid = $"{color}_btn", Height = _widthHeight, Width = 50 };

            colorButton(Cbutton, color);
            Cbutton.Margin = new Thickness(0,0,3,0);
            Cbutton.Click += RedColor_Click;
            Grid.SetColumn(Cbutton, index);
            ColorPickerGrid.Children.Add(Cbutton);

        }

        private void colorButton(CButton cb, Graphs.Color color)
        {
            switch (color)
            {
                case Graphs.Color.Red:
                    cb.Background = new SolidColorBrush(Colors.Red);
                    break;
                case Graphs.Color.Blue:
                    cb.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case Graphs.Color.Green:
                    cb.Background = new SolidColorBrush(Colors.Green);
                    break;
                case Graphs.Color.Yellow:
                    cb.Background = new SolidColorBrush(Colors.Yellow);
                    break;
            }

        }
        private void RedColor_Click(object sender, RoutedEventArgs e)
        {
            // Change color emun
            var cB = sender as CButton;
            _currentSelectColor = cB.ColorV;
        }
    }
    class CButton : Button
    {
        public Graphs.Color ColorV;

        public CButton(Graphs.Color color)
        {
            ColorV = color;
        }
    }
}