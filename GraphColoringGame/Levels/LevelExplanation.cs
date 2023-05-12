using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace GraphColoringGame.Levels
{
    /*
     * A class used to create ExplanationSteps for a level.
     * green, purple, black - the colors which may be used as outlines for vertices.
     * greyout - the opacity used for greyed out vertices.
     * connections - the list of directions containing edges for each coordinate.
     * colors - the list of colors available in the level.
     * width, height - the width and height of the graph as a grid.
     * xMin, yMin - the coordinates of the point in the graph's grid closest to (0,0).
     */
    public abstract class LevelExplanation
    {
        protected System.Windows.Media.Color green = Colors.ForestGreen;
        protected System.Windows.Media.Color purple = Colors.Purple;
        protected System.Windows.Media.Color black = Colors.Black;
        protected double greyout = 0.2;

        protected IEnumerable<(Coord, IEnumerable<Direction>)> connections;
        protected List<Graphs.Color> colors;
        protected int width, height, xMin, yMin;

        public LevelExplanation(Graph graph)
        {
            this.connections = graph.connections;
            this.colors = graph.colors.ToList();
            this.width = graph.width;
            this.height = graph.height;
            this.xMin = graph.xMin;
            this.yMin = graph.yMin;
        }

        /*
         * newVertices - returns a new dictionary of ExplanationVertex from the vertices in the graph.
         */
        protected Dictionary<Coord, ExplanationVertex> newVertices()
        {
            var vertices = new Dictionary<Coord, ExplanationVertex>();
            foreach (var (coord, dirs) in connections)
                vertices.Add(coord, new ExplanationVertex(dirs));
            return vertices;
        }
    }
}
