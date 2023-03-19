using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GraphColoringGame.Explanation
{
    public class ExplanationVertex
    {
        public Graphs.Color color = Graphs.Color.None;
        public System.Drawing.Color? outline;
        public IEnumerable<Direction> directions;

        public ExplanationVertex(IEnumerable<Direction> directions)
        {
            this.directions = directions;
        }
    }
}
