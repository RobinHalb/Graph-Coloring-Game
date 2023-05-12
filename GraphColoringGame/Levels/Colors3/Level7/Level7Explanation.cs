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
     * 
     *      0   0
     *      |   |
     *  a - 0 - 0
     *      |   |
     *      0   b
     * 
     */
    public class Level7Explanation : LevelExplanation
    {

        private Coord[] coords;

        public Level7Explanation(Graph graph) : base(graph)
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
                step4(),
        };


        public ExplanationStep step1()
        {
            var text = "This level demonstrates the third case, where Alice can win the 3-coloring game on a trunk of seven or less vertices with at most two colored vertices. \n\nIn this case, the two dangerous vertices (shown green) are adjacent, and each has exactly one colored neighbor.";
            var vertices = newVertices();

            vertices[coords[6]].color = Color.Blue;
            vertices[coords[2]].color = Color.Red;
            vertices[coords[3]].outline = green;
            vertices[coords[4]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
        public ExplanationStep step2()
        {
            var text = "Here, one of the dangerous vertices (shown purple), must have exactly three neighbors in total. \n\nOne of these neighbors (shown green) must be uncolored and not dangerous.";
            var vertices = newVertices();

            vertices[coords[6]].color = Color.Blue;
            vertices[coords[2]].color = Color.Red;
            vertices[coords[4]].outline = purple;
            vertices[coords[1]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3()
        {
            var text = "By coloring this neighbor with the same color as the previously colored neighbor, the dangerous vertex will have two available colors and only one uncolored neighbor, making it no longer dangerous.";
            var vertices = newVertices();

            vertices[coords[6]].color = Color.Blue;
            vertices[coords[2]].color = Color.Red;
            vertices[coords[4]].outline = purple;
            vertices[coords[1]].color = Color.Blue;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step4()
        {
            var text = "The remaining dangerous vertex (shown green), will now still have only one colored neighbor. \n\nBob can therefore add only one more colored neighbor, before Alice colors the dangerous vertex to win.";
            var vertices = newVertices();

            vertices[coords[6]].color = Color.Blue;
            vertices[coords[2]].color = Color.Red;
            vertices[coords[1]].color = Color.Blue;
            vertices[coords[3]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
