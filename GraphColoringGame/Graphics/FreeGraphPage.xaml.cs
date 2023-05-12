using GraphColoringGame.FreePlay;
using System.Windows;
using System.Windows.Controls;

namespace GraphColoringGame.Graphics
{
    /// <summary>
    /// Interaction logic for FreeGraphPage.xaml
    /// </summary>
    public partial class FreeGraphPage : Page
    {
        private IFreePlay _freePlay; 
        public FreeGraphPage(IFreePlay freePlay)
        {
            
            _freePlay = freePlay;
            InitializeComponent();
            GraphPageFrame.Content = new GraphPage(_freePlay.createGraph());
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            GraphPageFrame.Content = new GraphPage(_freePlay.createGraph());
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow)?.openLevelSelect();
        }
    }
}
