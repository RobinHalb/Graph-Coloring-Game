using GraphColoringGame.Levels;
using System.Windows;
using System.Windows.Controls;

namespace GraphColoringGame.Graphics
{
    /// <summary>
    /// Interaction logic for LevelSelectPage.xaml
    /// </summary>
    public partial class LevelSelectPage : Page
    {
        public LevelSelectPage()
        {
            InitializeComponent();
            var levels = 16;
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
                button.Click += Level_Click;
                Grid.SetColumn(button, x);
                Grid.SetRow(button, y);
                LevelGrid.Children.Add(button);

                if (x == cols - 1) y++;
                x = (x + 1) % cols;
            }
        }

        private void Level_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            Level level = b.Uid switch
            {
                "1" => new Level1(),
                "2" => new Level2(),
                "3" => new Level3(),
                "4" => new Level4(),
                "5" => new Level5(),
                "6" => new Level6(),
                "7" => new Level7(),
                "8" => new Level8(),
                "9" => new Level9(),
                "10" => new Level10(),
                "11" => new Level11(),
                "12" => new Level12(),
                "13" => new Level13(),
                "14" => new Level14(),
                "15" => new Level15(),
                "16" => new Level16(),
                _ => new Level1()
            };
            (Application.Current.MainWindow as MainWindow)?.openLevel(level);
        }

        private void Rule_Click(object sender, RoutedEventArgs e)
        {
            var ruleWindow = new RuleWindow();
            ruleWindow.Show();
        }
    }
}
