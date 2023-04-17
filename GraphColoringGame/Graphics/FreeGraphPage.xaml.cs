using GraphColoringGame.FreePlay;
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
    /// Interaction logic for FreeGraphPage.xaml
    /// </summary>
    public partial class FreeGraphPage : Page
    {
        private IFreePlay _freePlay; 
        private Player _alice = Player.Alice;
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
