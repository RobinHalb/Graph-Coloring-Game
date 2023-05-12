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
     * Graph showing Alice can use her 4 color winning strategy to win on any tree. 
     * 
     *          0   0
     *          | /
     *      0   0 - 0   
     *      |   |
     *  0 - 0 - 0 - 0 - 0
     *      |   |   
     *      0   0 - 0
     *      |   | \
     *      0   0   0
     */
    public class Level16Explanation : LevelExplanation
    {
        private Coord[] coords;

        public Level16Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
                new Coord(2,0), // coords[0]
                new Coord(3,0), // 1
                // Row 2
                new Coord(1,1), // 2
                new Coord(2,1), // 3
                new Coord(3,1), // 4
                // Row 3
                new Coord(0,2), // 5
                new Coord(1,2), // 6
                new Coord(2,2), // 7
                new Coord(3,2), // 8
                new Coord(4,2), // 9
                // Row 4
                new Coord(1,3), // 10
                new Coord(2,3), // 11
                new Coord(3,3), // 12
                // Row 5
                new Coord(1,4), // 13
                new Coord(2,4), // 14
                new Coord(3,4), // 15
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
        };

        public ExplanationStep step1()
        {
            var text = "Using the strategy from level 15, Alice can win the 4-coloring game on any tree.";
            var vertices = newVertices();

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "She may start out by coloring any vertex she wishes. \n\nAs only one vertex is colored, this only creates trunks with a single colored leaf.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3()
        {
            var text = "Once Bob has colored a vertex, a trunk with two colored leaves has been created.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step4()
        {
            var text = "Alice must now play a vertex, which does not create a trunk with three colored leaves. \n\nThis can be any vertex in a trunk with only one colored leaf, or a vertex which splits a trunk that already has two colored leaves.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[13]].color = Color.Red;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step5()
        {
            var text = "On Bob's second turn, he may create a trunk with three colored leaves.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[13]].color = Color.Red;
            vertices[coords[1]].color = Color.Green;

            vertices[coords[2]].opacity = greyout;
            vertices[coords[5]].opacity = greyout;
            vertices[coords[6]].opacity = greyout;
            vertices[coords[8]].opacity = greyout;
            vertices[coords[9]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;
            vertices[coords[11]].opacity = greyout;
            vertices[coords[12]].opacity = greyout;
            vertices[coords[13]].opacity = greyout;
            vertices[coords[14]].opacity = greyout;
            vertices[coords[15]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step6()
        {
            var text = "Now, Alice will follow the strategy from level 15, to split the trunk.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[13]].color = Color.Red;
            vertices[coords[1]].color = Color.Green;
            vertices[coords[3]].color = Color.Yellow;

            vertices[coords[2]].opacity = greyout;
            vertices[coords[5]].opacity = greyout;
            vertices[coords[6]].opacity = greyout;
            vertices[coords[8]].opacity = greyout;
            vertices[coords[9]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;
            vertices[coords[11]].opacity = greyout;
            vertices[coords[12]].opacity = greyout;
            vertices[coords[13]].opacity = greyout;
            vertices[coords[14]].opacity = greyout;
            vertices[coords[15]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step7()
        {
            var text = "Because Alice immediately destroys any trunk with three colored leaves, such a trunk will only ever exist on Alice's turn.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[13]].color = Color.Red;
            vertices[coords[1]].color = Color.Green;
            vertices[coords[3]].color = Color.Yellow;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step8()
        {
            var text = "While Alice uses this strategy, a dangerous vertex will never have more than three colored neighbors. \n\nTherefore, Alice will always have this winning strategy in the 4-coloring game, so long as the graph is a tree.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[13]].color = Color.Red;
            vertices[coords[1]].color = Color.Green;
            vertices[coords[3]].color = Color.Yellow;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
