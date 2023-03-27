using GraphColoringGame.Explanations;
using GraphColoringGame.Graphics;
using GraphColoringGame.Levels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GraphColoringGame
{
    /// <summary>
    /// Interaction logic for LevelPage.xaml
    /// </summary>
    public partial class LevelPage : Page
    {
        private Level _level;
        private GraphPage _graphPage;

        public LevelPage(Level level)
        {
            InitializeComponent();
            _level = level;
            setGraphFrame();
            ExplanationFrame.Content = new ExplanationTextPage(level.explanation, ExplanationGraphFrame, _level.level);
        }

        private void setGraphFrame()
        {
            _graphPage = new GraphPage(_level.graph);
            GraphFrame.Content = _graphPage;
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow)?.openLevelSelect();
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            _level.reset();
            setGraphFrame();
        }
    }
}
