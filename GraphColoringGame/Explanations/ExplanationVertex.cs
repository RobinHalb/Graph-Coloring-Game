using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GraphColoringGame.Explanations
{
    /*
     * A representation of a vertex used in explanations.
     * color - the color of the vertex.
     * outline - the color of the vertex's outline.
     * directions - the directions in which the vertex has an edge.
     * opacity - the opacity of the vertex.
     */
    public class ExplanationVertex
    {
        public Graphs.Color color = Graphs.Color.None;
        public System.Windows.Media.Color? outline;
        public IEnumerable<Direction> directions;
        public double? opacity;

        public ExplanationVertex(IEnumerable<Direction> directions)
        {
            this.directions = directions;
        }
    }
}
