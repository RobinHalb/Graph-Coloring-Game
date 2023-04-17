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
        };

        public ExplanationStep step1()
        {
            var text = "When playing using two colors, Alice can only win if there are no more than three vertices connected in a line. (shown green)";
            var vertices = newVertices();

            vertices[coords[0]].outline = green;
            vertices[coords[1]].outline = green;
            vertices[coords[2]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2() 
        {
            var text = "When only three vertices are in a line, the graph can have only one dangerous vertex, which Alice can win by coloring, since Bob needs a dangerous vertex to win.";
            var vertices = newVertices();

            vertices[coords[0]].outline = green;
            vertices[coords[1]].color = Graphs.Color.Red;
            vertices[coords[2]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
