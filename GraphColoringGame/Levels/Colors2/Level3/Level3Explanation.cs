using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GraphColoringGame.Levels
{
    /*
     *      0
     *      |
     *  0 - 0 - 0 
     */
    public class Level3Explanation : LevelExplanation
    {
        private Coord[] coords;

        public Level3Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[]{
            new Coord(0,1), // coords[0]
            new Coord(1, 1), // 1
            new Coord(2, 1), //2
            new Coord(1, 0),//3
            };
        }

        public List<ExplanationStep> GetExplanation() => new List<ExplanationStep>()
        {
            step1(),
            step2(),
            step3(),
        };

        public ExplanationStep step1()
        {
            var text = "This is a graph which has four vertices, but where the longest path contains only three vertices (shown green). \n\nHere, Alice has a winning strategy.";
            var vertices = newVertices();

            vertices[coords[0]].outline = green;
            vertices[coords[1]].outline = green;
            vertices[coords[2]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "In the 2-coloring game, a vertex must have at least two neighbors to be dangerous. \n\nWhen the longest path in the graph contains three vertices, the graph can have only one dangerous vertex, which must be the middle vertex of the path (shown purple).";
            var vertices = newVertices();

            vertices[coords[1]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3()
        {
            var text = "To win, Alice colors the dangerous vertex, leaving the graph with no dangerous vertices. \n\nBecause Bob needs a dangerous vertex to win, he no longer has any chance at doing so.";
            var vertices = newVertices();

            vertices[coords[1]].color = Graphs.Color.Red;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
