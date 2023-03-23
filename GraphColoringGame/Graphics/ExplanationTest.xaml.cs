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
    /// The Buttons are manually placed inside the xaml file
    /// 
    /// </summary>
    /// 
    public partial class ExplanationTest : Page
    {
        private List<Label> labels = new();
        private Thickness marginTop = new Thickness(0,19,0,0);
        private int currentPage = 0;
        private int totalPages = 4;
        private int colorCount = 2;
        private int level = 3;
        public ExplanationTest()
        {
            InitializeComponent();
            var levelLabel = addLabel($"Level {level}", 0, VerticalAlignment.Top, marginTop);
            levelLabel.FontSize = 14;
            levelLabel.FontWeight = FontWeights.Bold;
            var numbColorLabel = addLabel($"{colorCount} colors", 1, VerticalAlignment.Top);
            var TextBlock = addStratTextBlock();
            Grid.SetRow(TextBlock, 2);
            ExplanationOpen.Children.Add(TextBlock);
            var oneTxtBlock = addTextBlock();
            oneTxtBlock.Margin = marginTop;
            var twoTxtBlock = addTextBox();
            Grid.SetRow(oneTxtBlock,4);
            Grid.SetRow(twoTxtBlock,4);
            ExplanationOpen.Children.Add(oneTxtBlock);
            ExplanationOpen.Children.Add(twoTxtBlock);
            var lab = addLabel($"{currentPage}/{totalPages}", 5, VerticalAlignment.Center, new Thickness(15, 0, 0, 0), 1);
           
        }

        private Label addLabel(string text, int row, VerticalAlignment vertical, Thickness margin = new Thickness(), int column = 0) 
        {
            var label = new Label();
            label.Content = text;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = vertical;
            label.Margin = margin;
            labels.Add(label);
            Grid.SetRow(label, row);
            Grid.SetColumn(label, column);
            ExplanationOpen.Children.Add(label);
            return label;
           
        }

        //private void changeFontSize

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

        private TextBlock addStratTextBlock()
        {
            var textBlock = new TextBlock();
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.Inlines.Add(new Run("Winning Strategy:"));
            textBlock.Inlines.Add(new LineBreak());
            textBlock.Inlines.Add(new Bold(new Run("Bob")));
            return textBlock;
        }

        private TextBlock addTextBlock() 
        {
            var textBlock = new TextBlock();
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.Inlines.Add(new Run("This is one textBlock"));

            return textBlock;

        }

        private TextBlock addTextBox() 
        {
            var textBlock = new TextBlock();
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.Inlines.Add(new Run("This is another textBlock"));

            return textBlock;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page page = new ExplanationPage();
            NavigationService.Navigate(page);
        }
    }
}
