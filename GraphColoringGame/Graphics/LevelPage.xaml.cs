using GraphColoringGame.Explanations;
using GraphColoringGame.Graphics;
using GraphColoringGame.Graphs;
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

        private ExplanationTextPage _explanationTextPage;

        public LevelPage(Level level)
        {
            InitializeComponent();
            _level = level;
            _explanationTextPage = new ExplanationTextPage(level.explanation, ExplanationGraphFrame, _level.level, level.winning);
            ExplanationFrame.Content = _explanationTextPage;
            setGraphFrame();
        }

        private void setGraphFrame()
        {
            _graphPage = new GraphPage(_level.graph, _explanationTextPage.WinningName);
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
