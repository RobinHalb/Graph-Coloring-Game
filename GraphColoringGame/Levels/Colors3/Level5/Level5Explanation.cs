using GraphColoringGame.Explanations;
using System;
using System.Collections.Generic;
using GraphColoringGame.Graphs;
using System.Windows.Automation;

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
     *      0   0
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
                step4(),
                step5(),
                step6(),
                step7(),
                step8(),
                step9(),
        };

        public ExplanationStep step1()
        {
            var text = "In this scenerio, you will learn more about dangerous vertices and how to play around them with 3 colors. \n " +
                "Let's imagine this is a subgraph of a bigger graph, and Bob has played first in this subgraph. There are different cases that Alice can respond to while having a winning strategy:";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Blue;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2() 
        {
            var text = "Case 1: There is a dangerous vertex that has no colored neighbors after Bob's first turn in the subgraph: \n " +
                "In this case, Alice can color the other vertex dangerous vertex (marked green) with an avaliable color to reach a winning position.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Blue;
            vertices[coords[4]].outline = purple;
            vertices[coords[3]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3() 
        {
            var text = "Now Alice can color the other dangerous vertex to win as Bob cannot prevent any vertices to be uncolorable.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Blue;
            vertices[coords[4]].outline = green;
            vertices[coords[3]].color = Color.Red;
            

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step4() 
        {
        var text = "Now let's imagine that Alice played first in the subgraph and then Bob, making one of the dangerous vertices have two colored neighbors after Bob's first turn in the subgraph.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Blue;
            vertices[coords[2]].color = Color.Red;
            vertices[coords[3]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step5() 
        {
            var text = "Alice can reach a winning strategy by coloring this vertex. Since the other dangerous vertex can have at most one colored neighbor.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Blue;
            vertices[coords[2]].color = Color.Red;
            vertices[coords[3]].outline = green;
            vertices[coords[4]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step6() 
        {
            var text = "Another scenario could be if Alice played first in the subgraph and Bob played afterwards, making both dangerous vertices have exactly one colored neighbor.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Blue;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[3]].outline = purple;
            vertices[coords[4]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step7() 
        {
            var text = "As there are seven vertices in this subgraph, then one of the two dangerous vertices has three neighbors in total. This vertex has a neighbor that is not adjacent to any other colored vertex.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Blue;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[4]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step8() 
        {
            var text = "To reach a winning position, Alice has to color an uncolored neighbor of the dangerous vertex and may not have any colored neighbors already.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Blue;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[1]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step9() 
        {
            var text = "This will make the dangerous vertex safe, and the other dangerous vertex only has one colored neighbor, so Alice has reached a winning position as Bob cannot prevent any vertex from being colored.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Blue;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[3]].outline = purple;
            vertices[coords[1]].color = Color.Blue;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
