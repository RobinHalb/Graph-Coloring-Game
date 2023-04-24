using GraphColoringGame.Explanations;
using System;
using System.Collections.Generic;
using GraphColoringGame.Graphs;

namespace GraphColoringGame.Levels
{
    /*
     * This graph will explain the three different cases with dangerous vertices on a subgraph with at most 7 vertices.
     * Another graph will have to be constructed to illutrate a subcase in case 3 where the dangerous vertices are not neighbors.
     * 
     *      0   0
     *      |   |
     *  0 - 0 - 0
     *      |   |
     *      a   0
     * 
     */
    public class Level5Explanation : LevelExplanation
    {
        private Coord[] coords;

        public Level5Explanation(Graph graph) : base(graph)
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
                step3(),
        };

        public ExplanationStep step1()
        {
            var text = "In a subgraph of 7 vertices or less, there can be at most 2 dangerous vertices (shown green), and Alice can win the game on the subgraph."; 
           // var text = "In this scenerio, you will learn more about dangerous vertices and how to play around them with 3 colors. \n " +
           //     "Let's imagine this is a subgraph of a bigger graph, and Bob has played first in this subgraph. There are different cases that Alice can respond to while having a winning strategy:";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;
            vertices[coords[3]].outline = green;
            vertices[coords[4]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2() 
        {
            var text = "In this case, one of the dangerous vertices has no colored neighbours (shown purple).\n\nAlice may then color the other dangerous vertex (shown green), whether it has colored neighbours or not.";
            // In this case, one of the dangerous vertices has no colored neighbours (shown purple). Alice may then color the other dangerous vertex (shown green), whether it has colored neighbours or not.
            //var text = "Case 1: There is a dangerous vertex that has no colored neighbors after Bob's first turn in the subgraph: \n " +
            //    "In this case, Alice can color the other vertex dangerous vertex (marked green) with an avaliable color to reach a winning position.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;
            vertices[coords[4]].outline = purple;
            vertices[coords[3]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3() 
        {
            // Now, there is only one dangerous vertex remaining, which Alice can color to prevent Bob from winning. 
            var text = "Now, there is only one dangerous vertex remaining, which Alice can color after Bob's turn to prevent Bob from winning.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;
            vertices[coords[4]].outline = green;
            vertices[coords[3]].color = Color.Blue;
            

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
