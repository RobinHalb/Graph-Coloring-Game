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
using GraphColoringGame.FreePlay;
using GraphColoringGame.Graphs;
using GraphColoringGame.Levels;

namespace GraphColoringGame.Graphics
{
    /// <summary>
    /// Interaction logic for FreeSelectPage.xaml
    /// </summary>
    public partial class FreeSelectPage : Page
    {
        private IFreePlay[] TwoColors =
        {
            new FreePlay2Graph1(),
            new FreePlay2Graph2(),
            new FreePlay2Graph3(),
        };

        private IFreePlay[] ThreeColors =
        {
            new FreePlay3Graph1(),
            new FreePlay3Graph2(),
            new FreePlay3Graph3(),
            new FreePlay3Graph4(),
            new FreePlay3Graph5(),
            new FreePlay3Graph6(),
            new FreePlay3Graph7(),
            new FreePlay3Graph8(),
            new FreePlay3Graph9(),
            new FreePlay3Graph10(),
            new FreePlay3Graph11(),
            new FreePlay3Graph12(),
            // Partially colored
            new FreePlay3Graph1c1(),
            new FreePlay3Graph1c2(),
            new FreePlay3Graph2c1(),
            new FreePlay3Graph3c1(),
            new FreePlay3Graph3c2(),
            new FreePlay3Graph4c1(),
            new FreePlay3Graph4c2(),
            new FreePlay3Graph5c1(),
            new FreePlay3Graph5c2(),
        };

        private IFreePlay[] FourColors =
        {
            new FreePlay4Graph1(),
            new FreePlay4Graph2(),
            new FreePlay4Graph3(),
            new FreePlay4Graph4(),
        };

        public FreeSelectPage()
        {
            InitializeComponent();
        }

        private void Free2Btn_Click(object sender, RoutedEventArgs e)
        {
            var i = new Random().Next(TwoColors.Length);
            (Application.Current.MainWindow as MainWindow)?.openFreePlay(TwoColors[i]);
        }

        private void Free3Btn_Click(object sender, RoutedEventArgs e)
        {
            var i = new Random().Next(ThreeColors.Length);
            (Application.Current.MainWindow as MainWindow)?.openFreePlay(ThreeColors[i]);
        }

        private void Free4Btn_Click(object sender, RoutedEventArgs e)
        {
            var i = new Random().Next(FourColors.Length);
            (Application.Current.MainWindow as MainWindow)?.openFreePlay(FourColors[i]);
        }
    }
}
