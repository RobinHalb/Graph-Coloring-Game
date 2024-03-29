﻿using GraphColoringGame.Levels;
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
            _explanationTextPage = new ExplanationTextPage(level.explanation, ExplanationGraphFrame, _level.level);
            ExplanationFrame.Content = _explanationTextPage;
            setGraphFrame();
        }

        /*
         * setGraphFrame - creates the GraphPage in the GraphFrame and sets the winning player in the ExplanationTextPage.
         */
        private void setGraphFrame()
        {
            _explanationTextPage.setWinning(_level.winning.ToString());
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
