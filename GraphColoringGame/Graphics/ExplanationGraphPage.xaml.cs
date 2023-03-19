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
        //private ColorPicker _colorPicker;
        //private GraphDrawCalc _graphDraw;
        //private Graphs.Color selectedColor => _colorPicker.selectedColor;

        private Dictionary<string, Button> buttons = new Dictionary<string, Button>();
        private Dictionary<string, Coord> coords = new Dictionary<string, Coord>();

        public ExplanationGraphPage()
        {
            InitializeComponent();
        }
    }
}
