using System;
using System.Collections.Generic;
using System.Data.Common;
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
        private Thickness marginTop = new Thickness(0,19,0,0);
        public ExplanationTest()
        {
            InitializeComponent();
            var levelLabel = addLabel("Level", 0, VerticalAlignment.Top, marginTop);
            levelLabel.FontSize = 14;
            levelLabel.FontWeight = FontWeights.Bold;
            var numbColorLabel = addLabel("NUMBER OF COLORS", 1, VerticalAlignment.Top, marginTop);
            var TextBlock = addTextBlock();
            Grid.SetRow(TextBlock, 2);
            ExplanationOpen.Children.Add(TextBlock);
        }

        private Label addLabel(string text, int row, VerticalAlignment vertical, Thickness margin = new Thickness()) 
        {
            var label = new Label();
            label.Content = text;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = vertical;
            label.Margin = margin;
            labels.Add(label);
            Grid.SetRow(label, row);
            ExplanationOpen.Children.Add(label);
            return label;
           
        }

        private void addButton(string text, int row, int column = 0, Thickness margin = new Thickness())
        {
            var btn = new Button();
            btn.Content = text;
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Margin = margin;
            Grid.SetRow(btn, row);
            Grid.SetColumn(btn, column);
            ExplanationOpen.Children.Add(btn);

        }

        private TextBlock addTextBlock()
        {
            var textBlock = new TextBlock();
            textBlock.Inlines.Add(new Bold(new Run("Winning Strategy")));
            textBlock.Inlines.Add(new LineBreak());
            textBlock.Inlines.Add(new Run("Bob"));
            return textBlock;
        }

       /* private void addSymbolBtn(FontFamily fontFamily, string text,int row, int column, Thickness margin = new Thickness())
        {
            var btn = new Button();
            btn.FontFamily = fontFamily;
            btn.Content = text;
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Margin = margin;
            btn.Height = 30;
            btn.Width = 30;
            Grid.SetRow(btn, row);
            Grid.SetColumn(btn, column);
            ButtonGrid.Children.Add(btn);
        }
       */
    }
}
