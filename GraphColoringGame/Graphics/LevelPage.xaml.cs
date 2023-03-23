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
        private GraphPage _graphPage;

        public LevelPage(ILevel level)
        {
            InitializeComponent();
            _graphPage = new GraphPage(level.graph);
            GraphFrame.Content = _graphPage;
            ExplanationFrame.Content = new ExplanationTextPage(level.explanation, ExplanationGraphFrame);

            /*
            foreach (ExplanationStep step in level.explanation)
            {
                _explanationGraphs.Add(new ExplanationGraphPage(step));
            }
            */
            //GraphFrame.Content = _explanationGraphs[0];
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow)?.openLevelSelect();
        }
    }
}
