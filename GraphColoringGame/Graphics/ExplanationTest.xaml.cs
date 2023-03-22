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
        public ExplanationTest()
        {
            InitializeComponent();
            addLabel("Hello World", 0);
            addLabel("HELLO", 1);
        }

        private void addLabel(string text, int row) 
        {
            var label = new Label();
            label.Content = text;
            Grid.SetRow(label, row);
            ExplanationOpen.Children.Add(label);
        }

    }
}
