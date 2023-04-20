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
     *          0
     *          |
     *  0 - 0 - 0 - 0 
     */
    public class Level4Explanation : LevelExplanation
    {
        private Coord[] coords;

        public Level4Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[]{
            new Coord(0,1), // coords[0]
            new Coord(1, 1), // 1
            new Coord(2, 1), //2
            new Coord(3, 1),//3
            new Coord(2, 0),//4
            };
        }

        public List<ExplanationStep> GetExplanation() => new List<ExplanationStep>()
        {
            step1(),
            step2(),
            step3()
        };

        public ExplanationStep step1()
        {
            var text = "When playing using two colors on a graph where four or more vertices are connected in a line (shown green), Bob can win by playing as explained in level 2.";
            var vertices = newVertices();

            vertices[coords[0]].outline = green;
            vertices[coords[1]].outline = green;
            vertices[coords[2]].outline = green;
            vertices[coords[4]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2() 
        {
            var text = "Whichever vertex Alice colors, Bob can win by coloring a vertex at distance two (shown purple).";
            var vertices = newVertices();

            vertices[coords[4]].color = Graphs.Color.Red;
            vertices[coords[1]].outline = purple;
            vertices[coords[3]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3()
        {
            var text = "Whichever vertex Alice colors, Bob can win by coloring a vertex at distance two (shown purple).";
            var vertices = newVertices();

            vertices[coords[2]].color = Graphs.Color.Red;
            vertices[coords[0]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);


        }
    }
}
