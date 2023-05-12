using System.Windows.Media;

namespace GraphColoringGame.Graphs
{
    /*
     * The colors which can be used on the game to color vertices.
     */
    public enum Color
    {
        None,
        Red,
        Blue,
        Green,
        Yellow
    }

    public static class ColorExtensions
    {
        /*
         * asBrush - convert the Color to a SolidColorBrush.
         */
        public static SolidColorBrush asBrush(this Color color) => color switch
        {
            Color.Red => new SolidColorBrush { Color = Colors.Red },
            Color.Blue => new SolidColorBrush { Color = Colors.Blue },
            Color.Green => new SolidColorBrush { Color = Colors.Green },
            Color.Yellow => new SolidColorBrush { Color = Colors.Yellow },
            _ => new SolidColorBrush { Color = Colors.White },
        };

        /*
         * asBrush - convert a string to the corresponding Color.
         */
        public static Color ConvertToColor(string color) => color switch
        {
            "Red" => Color.Red,
            "Blue" => Color.Blue,
            "Green" => Color.Green,
            "Yellow" => Color.Yellow,
            _ => Color.None
        };
    } 
}
