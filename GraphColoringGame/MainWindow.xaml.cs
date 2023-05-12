using GraphColoringGame.FreePlay;
using GraphColoringGame.Graphics;
using GraphColoringGame.Levels;
using System.Windows;

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

        /*
         * openLevel - opens the given level in the window.
         */
        public void openLevel(Level level)
        {
            MainFrame.Content = new LevelPage(level);
        }

        /*
         * openLevelSelect - opens the LevelSelectPage in the window.
         */
        public void openLevelSelect()
        {
            MainFrame.Content = _levelSelectPage;
        }

        /*
         * openFreePlay - opens the given free play graph in the window.
         */
        public void openFreePlay(IFreePlay freePlay)
        {
            MainFrame.Content = new FreeGraphPage(freePlay);
        }
    }
}
