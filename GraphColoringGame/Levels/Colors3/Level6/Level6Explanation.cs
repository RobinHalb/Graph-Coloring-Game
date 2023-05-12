using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    /*
     * Partial colored graph with 7 vertices showing Alice can win when one of two dangerous vertices has two colored neighbors.
     * a: Red colored vertex
     * b: Blue colored vertex
     * 
     *      0   0
     *      |   |
     *  a - 0 - 0
     *      |   |
     *      b   0
     */
    public class Level6Explanation : LevelExplanation
    {

        private Coord[] coords;

        public Level6Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
                new Coord(1,0), //coords[0]
                new Coord(2, 0), //1
                // Row 2
                new Coord(0, 1), //2
                new Coord(1, 1), //3
                new Coord(2, 1), //4
                // Row 3
                new Coord(1,2), //5
                new Coord(2,2), //6
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
            var text = "This level demonstrates the second case, where Alice can win the 3-coloring game on a trunk of seven or less vertices with at most two colored vertices. \n\nIn this case, one of the dangerous vertices (shown green), has exactly two colored neighbors.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Blue;
            vertices[coords[2]].color = Color.Red;
            vertices[coords[3]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "If Alice colors said dangerous vertex, the remaining dangerous vertex (shown purple) can now have only one colored neighbor.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Blue;
            vertices[coords[2]].color = Color.Red;
            vertices[coords[3]].color = Color.Green;
            vertices[coords[4]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3()
        {
            var text = "Bob can only color a second neighbor, before Alice colors the dangerous vertex, winning the subgraph.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Blue;
            vertices[coords[2]].color = Color.Red;
            vertices[coords[3]].color = Color.Green;
            vertices[coords[4]].outline = purple;
            vertices[coords[1]].color = Color.Red;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
