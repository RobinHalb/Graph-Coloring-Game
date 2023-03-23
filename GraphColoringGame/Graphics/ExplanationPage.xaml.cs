using GraphColoringGame.Levels;
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
    public partial class ExplanationPage : Page
    {
        private ILevel _level;
        public ExplanationPage(ILevel level)
        {
            InitializeComponent();
            _level = level;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var explanationpages = new ExplanationText(4,2,3, "TESTING STUFF");
            //var explanationpages = new ExplanationTextPage(_level.explanation, ExplanationGraphFrame);
            //NavigationService.Navigate(explanationpages);
            //ExplanationFrame.Source = new Uri("ExplanationTest.xaml", UriKind.Relative);
            //(Application.Current.MainWindow as MainWindow)?.changeLevel();
            //(Parent as MainWindow)?.changeLevel();
        }
    }
}
