using GraphColoringGame.FreePlay;
using System;
using System.Windows;
using System.Windows.Controls;

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
            new FreePlay4Graph5(),
            // Partially colored
            new FreePlay4Graph1c1(),
            new FreePlay4Graph1c2(),
            new FreePlay4Graph1c3(),
            new FreePlay4Graph2c1(),
            new FreePlay4Graph2c2(),
            new FreePlay4Graph3c1(),
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
