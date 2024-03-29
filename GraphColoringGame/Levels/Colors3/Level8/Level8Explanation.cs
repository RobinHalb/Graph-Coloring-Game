﻿using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    /* 
     * Partial color graph showing Alice can win on a subgraph with 7 vertices when the dangerous vertices have a colored neighbor each.
     * The dangerous vertices are not neighbors.
     * a: Red colored vertex
     * b: Blue colored vertex
     *      
     *      0       0
     *      |       |
     *  a - 0 - 0 - 0 - b
     */
    public class Level8Explanation : LevelExplanation
    {
        private Coord[] coords;

        public Level8Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
            new Coord(1,0), //coords[0]
            new Coord(3, 0), //1
            // Row 2
            new Coord(0, 1), //2
            new Coord(1, 1), //3
            new Coord(2, 1), //4
            new Coord(3, 1), //5
            new Coord(4, 1), //6
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
            var text = "This level demonstrates the fourth and final case, where Alice can win the 3-coloring game on a trunk of seven or less vertices with at most two colored vertices. \n\nIn this case, the two dangerous vertices (shown green) are not adjacent, and each has exactly one colored neighbor.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[3]].outline = green;
            vertices[coords[5]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "To win, Alice can color either of the dangerous vertices.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[3]].color = Color.Green;
            vertices[coords[5]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3() 
        {
            var text = "The remaining dangerous vertex, will now still have only one colored neighbor. \n\nBob can therefore add only one more colored neighbor, before Alice colors the vertex to win.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[3]].color = Color.Green;
            vertices[coords[5]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
