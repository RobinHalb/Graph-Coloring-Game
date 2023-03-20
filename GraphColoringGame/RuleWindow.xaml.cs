using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace GraphColoringGame
{
    /// <summary>
    /// Interaction logic for RuleWindow.xaml
    /// </summary>
    public partial class RuleWindow : Window
    {

        private Thickness imageMargin = new Thickness(0,-20,0,-20);
        private int imageWidth = 250;
        private int imageHeight = 200;
        public RuleWindow()
        {
            
            this.Owner = App.Current.MainWindow;
            InitializeComponent();
            addUncolorableImage();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void addUncolorableImage() 
        {
            var uncolorableBitImage = addBitImage(200, @"Images\Rules\example_uncolor_vertices.png");

            ImageExample1.Margin = imageMargin;
            ImageExample1.Width = imageWidth;
            ImageExample1.Height = imageHeight;
            ImageExample1.Source = uncolorableBitImage;
        }

        private BitmapImage addBitImage(int height, string path) 
        {
            var bitMapImage = new BitmapImage();
            bitMapImage.BeginInit();
            bitMapImage.UriSource = new Uri(path, UriKind.Relative);
            bitMapImage.DecodePixelHeight = 200;
            bitMapImage.EndInit();
            return bitMapImage;
        }
    }
}
