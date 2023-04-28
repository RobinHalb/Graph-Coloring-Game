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
     * This graph will explain the three different cases with dangerous vertices on a subgraph with at most 7 vertices.
     * Another graph will have to be constructed to illutrate a subcase in case 3 where the dangerous vertices are not neighbors.
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
                new Coord(1,0), // coords[0]
                new Coord(2, 0), // 1
                new Coord(0, 1),//2
                new Coord(1, 1),//3
                new Coord(2, 1),//4
                new Coord(1,2), //5
                new Coord(2,2), //6
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
            // In a subgraph of 7 vertices, where two dangerous vertices are adjacent and each has exactly one colored neighbor, one of these must have 3 neighbors in total (shown green). 
            var text = "In a trunk of at most 7 vertices, where two dangerous vertices are adjacent and each has exactly one colored neighbor, one dangerous vertex must have 3 neighbors in total (shown green).";
            var vertices = newVertices();

            vertices[coords[6]].color = Color.Blue;
            vertices[coords[2]].color = Color.Red;
            vertices[coords[4]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "One of these neighbors (shown purple) must be uncolored and not dangerous. \n\nBy coloring this neighbor with the same color as the previously colored neighbor, the dangerous vertex will have two available colors and only one uncolored neighbor, making it no longer dangerous.";
            var vertices = newVertices();

            vertices[coords[6]].color = Color.Blue;
            vertices[coords[2]].color = Color.Red;
            vertices[coords[4]].outline = green;
            vertices[coords[1]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3()
        {
            var text = "The remaining dangerous vertex (shown purple), will now still have only one colored neighbor. \n\nBob can therefore add only one more colored neighbor, before Alice colors the vertex to win.";
            var vertices = newVertices();

            vertices[coords[6]].color = Color.Blue;
            vertices[coords[2]].color = Color.Red;
            vertices[coords[1]].color = Color.Blue;
            vertices[coords[3]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
