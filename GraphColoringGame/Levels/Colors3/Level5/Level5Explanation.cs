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
            new Coord(1, 0), // coords[0]
            new Coord(2, 0), // 1
            new Coord(0, 1),//2
            new Coord(1, 1),//3
            new Coord(2, 1),//4
            new Coord(1, 2), //5
            new Coord(2, 2), //6
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
            var text = "The subgraph for this level is of a type called a trunk, which has two restrictions: \n\n1. Any colored vertices must be leaves, meaning they are connected only to one other vertex in the trunk. \n\n2. Only colored vertices can have neighbors that are not in the trunk.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin); 
        }

        public ExplanationStep step2()
        {
            var text = "A trunk of 7 vertices or less can contain at most 2 dangerous vertices (shown green), and Alice can win the game on the trunk, if there are no more than two colored vertices."; 
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;
            vertices[coords[3]].outline = green;
            vertices[coords[4]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3() 
        {
            var text = "In this case, one of the dangerous vertices has no colored neighbors (shown purple). \n\nAlice may then color the other dangerous vertex (shown green), whether it has colored neighbors or not.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;
            vertices[coords[4]].outline = purple;
            vertices[coords[3]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step5() 
        {
            var text = "Now, there is only one dangerous vertex remaining, which Alice can color on her next turn to win.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;
            vertices[coords[4]].outline = green;
            vertices[coords[3]].color = Color.Blue;
            

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
