using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GraphColoringGame.Graphs
{
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
        public static SolidColorBrush asBrush(this Color color) => color switch
        {
            Color.Red => new SolidColorBrush { Color = Colors.Red },
            Color.Blue => new SolidColorBrush { Color = Colors.Blue },
            Color.Green => new SolidColorBrush { Color = Colors.Green },
            Color.Yellow => new SolidColorBrush { Color = Colors.Yellow },
            _ => new SolidColorBrush { Color = Colors.White },
        };
    } 
}
