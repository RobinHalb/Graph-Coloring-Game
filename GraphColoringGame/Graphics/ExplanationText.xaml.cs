using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class ExplanationText : Page
    {
        private Thickness marginTop = new Thickness(0,19,0,0);
        private int _currentStep = 1;
        private int totalSteps;
        private int colorCount;
        private int level;
        private string text;
        public ExplanationText(int totalPages, int colorCount, int level, string text)
        {
            InitializeComponent();
            DataContext = this;

            this.totalSteps = totalPages;
            this.colorCount = colorCount;
            this.level = level;
            this.text = text;


            var levelLabel = addLabel($"Level {level}", 0, VerticalAlignment.Top, marginTop);
            levelLabel.FontSize = 14;
            levelLabel.FontWeight = FontWeights.Bold;

            var numbColorLabel = addLabel($"{colorCount} colors", 1, VerticalAlignment.Top);
            var TextBlock = addStratTextBlock("Bob");
            var MainTextBlock = addMainTextBlock(text);
            MainTextBlock.Margin = marginTop;
            setStepLabel();
        }

        private Label addLabel(string text, int row, VerticalAlignment vertical, Thickness margin = new Thickness(), int column = 0) 
        {
            var label = new Label();
            label.Content = text;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = vertical;
            label.Margin = margin;
            addToGrid(label, row, column);
            return label;
           
        }

        private TextBlock addStratTextBlock(string winning)
        {
            var textBlock = new TextBlock();
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.Inlines.Add(new Run("Winning Strategy:"));
            textBlock.Inlines.Add(new LineBreak());
            textBlock.Inlines.Add(new Bold(new Run($"{winning}")));
            addToGrid(textBlock, 2);
            return textBlock;
        }

        private TextBlock addMainTextBlock(string text) 
        {
            var textBlock = new TextBlock() { Text = text };
            textBlock.TextAlignment = TextAlignment.Center;
            addToGrid(textBlock, 4);
            return textBlock;
        }

        // Add UIElement to Grid
        private void addToGrid(UIElement element, int row, int column = 0)
        {
            Grid.SetRow(element, row);
            Grid.SetColumn(element, column);
            ExplanationOpen.Children.Add(element);
        }

        // Go back
        private void Button_Click_CloseExplanation(object sender, RoutedEventArgs e)
        {
            Page page = new ExplanationPage();
            NavigationService.Navigate(page);
        }

        // next, prev step
        private void changeStep(object sender, RoutedEventArgs e) 
        {
          var btn = sender as Button;
            if (btn.Name == "prevStep") 
            {
                if (_currentStep != 1) { _currentStep--; }
            }
            if (btn.Name == "nextStep") 
            {
                if(_currentStep != totalSteps) { _currentStep++; }
            }
            setStepLabel();
        }

        // update label
        private void setStepLabel() 
        {
            stepsLabel.Content = _currentStep.ToString() + "/" + totalSteps.ToString();
        }
    }
}
