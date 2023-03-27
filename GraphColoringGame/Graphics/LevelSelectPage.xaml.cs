using GraphColoringGame.Graphs;
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
    /// Interaction logic for LevelSelectPage.xaml
    /// </summary>
    public partial class LevelSelectPage : Page
    {
        public LevelSelectPage()
        {
            InitializeComponent();
            var levels = 31;
            var cols = 5;
            var colWidth = new GridLength(1, GridUnitType.Star);
            var rows = (levels / 5) + 1;
            var rowHeight = new GridLength(60);
            var margin = new Thickness(10);

            for (int i = 0; i < cols; i++) LevelGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = colWidth }); 
            for (int i = 0; i < rows; i++) LevelGrid.RowDefinitions.Add(new RowDefinition() { Height = rowHeight });

            // Add buttons to grid
            var x = 0;
            var y = 0;
            for (int level = 1; level <= levels; level++)
            {
                var button = new Button() { Content = $"Level {level}", Margin = margin, Uid = level.ToString() };
                button.Click += Vertex_Click;
                Grid.SetColumn(button, x);
                Grid.SetRow(button, y);
                LevelGrid.Children.Add(button);
                if (level > 6) button.IsEnabled = false;

                if (x == cols - 1) y++;
                x = (x + 1) % cols;
            }
        }

        private void Vertex_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            Level level = b.Uid switch
            {
                "1" => new Level1(),
                "2" => new Level2(),
                "3" => new Level3(),
                "4" => new Level4(),
                "5" => new TestLevel2(),
                "6" => new TestLevel(),
                _ => new Level1()
            };
            (Application.Current.MainWindow as MainWindow)?.openLevel(level);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ruleWindow = new RuleWindow();
            ruleWindow.Show();
        }
    }
}
