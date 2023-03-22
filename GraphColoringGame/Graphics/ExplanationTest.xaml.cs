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

namespace GraphColoringGame
{
    /// <summary>
    /// Interaction logic for ExplanationPage.xaml
    /// </summary>
    public partial class ExplanationTest : Page
    {
        private List<Label> labels = new();
        public ExplanationTest()
        {
            InitializeComponent();
            addLabel("Level", 0, VerticalAlignment.Bottom);
            addLabel("NUMBER OF COLORS", 1, VerticalAlignment.Top);
            addLabel("Winning Strategy:", 2, VerticalAlignment.Bottom);
            addLabel("Bob", 3, VerticalAlignment.Top);
        }

        private void addLabel(string text, int row, VerticalAlignment vertical) 
        {
            var label = new Label();
            label.Content = text;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = vertical;
            labels.Add(label);
            Grid.SetRow(label, row);
            ExplanationOpen.Children.Add(label);
           
        }
        private void addTextBlock(string text, int row, VerticalAlignment vertical)
        {
            var textBlock = new TextBlock();
        }
    }
}
