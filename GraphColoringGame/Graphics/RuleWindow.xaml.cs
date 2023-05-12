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

namespace GraphColoringGame
{
    /// <summary>
    /// Interaction logic for RuleWindow.xaml
    /// </summary>
    public partial class RuleWindow : Window
    {

        private Thickness imageMargin = new Thickness(0,-15,0,-20);
        private int imageWidth = 250;
        private int imageHeight = 200;
        public RuleWindow()
        {
            
            this.Owner = App.Current.MainWindow;
            InitializeComponent();
            addUncoloredImage();
            addUncolorableVImage();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void addUncoloredImage() 
        {
            var uncoloredBitImage = addBitImage(200, @"..\Images\Rules\example_uncolor_vertices.png");
            addImageAttributes(ImageUncoloredVertex, uncoloredBitImage);
        }

        private void addUncolorableVImage() 
        {
            var uncolorableVBitImage = addBitImage(200, @"..\Images\Rules\rules_uncolorable_vertex.png");
            addImageAttributes(ImageRulesLostGame, uncolorableVBitImage);
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

        private void addImageAttributes(Image img, BitmapImage bitImage) 
        {
            img.Margin = imageMargin;
            img.Width = imageWidth;
            img.Height = imageHeight;
            img.Source = bitImage;

        }
    }
}
