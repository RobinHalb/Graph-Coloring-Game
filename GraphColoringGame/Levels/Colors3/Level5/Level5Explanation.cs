using GraphColoringGame.Explanations;
using System;
using System.Collections.Generic;
using GraphColoringGame.Graphs;

namespace GraphColoringGame.Levels
{
    /*
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
            new Coord(2, 0), //1
            // Row 2
            new Coord(0, 1), //2
            new Coord(1, 1), //3
            new Coord(2, 1), //4
            // Row 3
            new Coord(1, 2), //5
            new Coord(2, 2), //6
          };
        }

        public List<ExplanationStep> GetExplanation() => new List<ExplanationStep>()
        {
                step1(),
                step2(),
                step3(),
                step4(),
                step5(),
                step6(),
        };

        public ExplanationStep step1()
        {
            var text = "This level introduces an additional color, moving into the 3-coloring game. \n\nThis level is played on a partially colored subgraph, meaning that some vertices are already colored, and that the subgraph could be part of a larger graph, which is not shown.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "This subgraph is of a special type called a trunk, which has two restrictions: \n\n1. Any colored vertices must be leaves, meaning they are connected only to one other vertex in the trunk. \n\n2. Only colored vertices can have neighbors that are not in the trunk.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin); 
        }

        public ExplanationStep step3()
        {
            var text = "A trunk of seven vertices or less can contain at most two dangerous vertices (shown green). \n\nAlice can win the 3-coloring game on a trunk of seven or less vertices, if there are no more than two colored vertices. \n\nThis is shown through four cases."; 
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;
            vertices[coords[3]].outline = green;
            vertices[coords[4]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step4() 
        {
            var text = "This level demonstrates the first case, where one of the dangerous vertices has no colored neighbors (shown purple).";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;
            vertices[coords[4]].outline = purple;
            vertices[coords[3]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step5() 
        {
            var text = "Alice colors the other dangerous vertex, whether it has colored neighbors or not. \n\nNow, there is only one dangerous vertex remaining, which has only one colored neighbor.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;
            vertices[coords[4]].outline = purple;
            vertices[coords[3]].color = Color.Blue;
            

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step6()
        {
            var text = "In the 3-coloring game, the dangerous vertex needs three colored neighbors of different colors for Bob to win. \n\nBecause there is just one colored neighbor, Bob can only color the second neighbor, before Alice colors the dangerous vertex to win.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;
            vertices[coords[3]].color = Color.Blue;
            vertices[coords[1]].color = Color.Green;
            vertices[coords[4]].outline = purple;


            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
