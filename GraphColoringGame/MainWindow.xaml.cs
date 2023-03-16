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
        private LevelSelectPage _levelSelectPage;
        public MainWindow()
        {
            InitializeComponent();
            _levelSelectPage = new LevelSelectPage();
            MainFrame.Content = _levelSelectPage;
        }

        public void openLevel(ILevel level)
        {
            MainFrame.Content = new LevelPage(level);
        }

        public void openLevelSelect()
        {
            MainFrame.Content = _levelSelectPage;
        }
    }
}
