using GraphColoringGame.Graphs;
using GraphColoringGame.Levels;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int l = 1;
        public MainWindow()
        {
            InitializeComponent();
            var graphPage = new LevelPage(new Level1Graph().createGraph());
            var colorPicker = new ColorPicker(new List<Graphs.Color>() {Graphs.Color.Red, Graphs.Color.Blue });
            GraphFrame.Content = colorPicker;
        }

        public void changeLevel()
        {
            LevelPage graphPage;
            switch (l)
            {
                case 1:
                    l = 2;
                    graphPage = new LevelPage(new Level2Graph().createGraph());
                    break;
                case 2:
                    l = 3;
                    graphPage = new LevelPage(new Level3Graph().createGraph());
                    break;
                default:
                    l = 1;
                    graphPage = new LevelPage(new Level1Graph().createGraph());
                    break;
            }
            GraphFrame.Content = graphPage;
        }
    }
}
