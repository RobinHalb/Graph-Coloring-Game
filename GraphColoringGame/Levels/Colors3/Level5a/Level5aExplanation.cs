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
     *      b   0
     * 
     */
    public class Level5aExplanation : LevelExplanation
    {

        private Coord[] coords;

        public Level5aExplanation(Graph graph) : base(graph)
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
        };


        public ExplanationStep step1()
        {
            // In this subgraph similar to Level5, one of the dangerous vertecies has two colored neighbors (marked purple). Alice can reach a winning position by coloring this vertex.
            // In a subgraph of 7 vertices, where one dangerous vertex has two colored neighbours (shown green), Alice may win the subgraph by coloring this vertex.
            var text = "In a subgraph of 7 vertices, where one dangerous vertex has two colored neighbors (shown green), Alice may color this vertex.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Blue;
            vertices[coords[2]].color = Color.Red;
            vertices[coords[3]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "The remaining dangerous vertex (shown purple) can now have only one colored neighbor. \n\nBob can therefore only color a second neighbor, before Alice colors the dangerous vertex, winning the subgraph.";
            //var text = "Alice can reach a winning strategy by coloring this vertex. Since the other dangerous vertex can have at most one colored neighbor.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Blue;
            vertices[coords[2]].color = Color.Red;
            vertices[coords[3]].color = Color.Green;
            vertices[coords[4]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
