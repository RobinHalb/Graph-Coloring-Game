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
     *              0
     *              |
     *  a - 0 - 0 - 0 - 0 - b
     *          |   |
     *      0 - 0   0
     *        /   \
     *      0       c
    */
    public class Level15Explanation : LevelExplanation
    {
            private Coord[] coords;

        public Level15Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
            new Coord(3,0), //coords[0]
            // Row 2
            new Coord(0, 1), //1
            new Coord(1, 1), //2
            new Coord(2, 1), //3
            new Coord(3, 1), //4
            new Coord(4,1), //5
            new Coord(5,1), //6
            // Row 3
            new Coord(1,2), //7
            new Coord(2,2), //8
            new Coord(3,2), //9
            // Row 4
            new Coord(1,3), //10
            new Coord(3,3), //11
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
            var text = "In the 4-coloring game, Alice always has a winning strategy for a trunk with three or less colored leaves.";
            var vertices = newVertices();
            vertices[coords[1]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[11]].color = Color.Green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "Such a trunk will always have some vertex (shown green), with which it can be split into trunks with two or less colored leaves.";
            var vertices = newVertices();
            vertices[coords[1]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[11]].color = Color.Green;
            vertices[coords[3]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3()
        {
            var text = "Once Alice has colored this vertex, three trunks have been created with two colored leaves each.";
            var vertices = newVertices();
            vertices[coords[1]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[11]].color = Color.Green;
            vertices[coords[3]].color = Color.Red;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step4()
        {
            var text = "Bob will then play his move in a trunk.";
            var vertices = newVertices();
            vertices[coords[1]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[11]].color = Color.Green;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;


            vertices[coords[1]].opacity = greyout;
            vertices[coords[2]].opacity = greyout;
            vertices[coords[7]].opacity = greyout;
            vertices[coords[8]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;
            vertices[coords[11]].opacity = greyout;


            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step5()
        {
            var text = "If after Bob's turn the trunk has three colored leaves, this trunk will also have a vertex (shown green), with which it can be split.";
            var vertices = newVertices();
            vertices[coords[1]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[11]].color = Color.Green;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[4]].outline = green;

            vertices[coords[1]].opacity = greyout;
            vertices[coords[2]].opacity = greyout;
            vertices[coords[7]].opacity = greyout;
            vertices[coords[8]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;
            vertices[coords[11]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
        public ExplanationStep step6()
        {
            var text = "Alice will color this vertex.";
            var vertices = newVertices();
            vertices[coords[1]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[11]].color = Color.Green;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[4]].color = Color.Yellow;

            vertices[coords[1]].opacity = greyout;
            vertices[coords[2]].opacity = greyout;
            vertices[coords[7]].opacity = greyout;
            vertices[coords[8]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;
            vertices[coords[11]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step7()
        {
            var text = "Any dangerous vertex (shown green) which Bob reduces to having only one legal color, will also create a trunk with three colored leaves.";
            var vertices = newVertices();
            vertices[coords[1]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[11]].color = Color.Green;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[4]].color = Color.Yellow;
            vertices[coords[10]].color = Color.Yellow;
            vertices[coords[8]].outline = green;

            vertices[coords[0]].opacity = greyout;
            vertices[coords[1]].opacity = greyout;
            vertices[coords[2]].opacity = greyout;
            vertices[coords[4]].opacity = greyout;
            vertices[coords[5]].opacity = greyout;
            vertices[coords[6]].opacity = greyout;
            vertices[coords[9]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step8()
        {
            var text = "Alice will then color the dangerous vertex to destroy the trunk.";
            var vertices = newVertices();
            vertices[coords[1]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[11]].color = Color.Green;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[4]].color = Color.Yellow;
            vertices[coords[10]].color = Color.Yellow;
            vertices[coords[8]].color = Color.Blue;

            vertices[coords[0]].opacity = greyout;
            vertices[coords[1]].opacity = greyout;
            vertices[coords[2]].opacity = greyout;
            vertices[coords[4]].opacity = greyout;
            vertices[coords[5]].opacity = greyout;
            vertices[coords[6]].opacity = greyout;
            vertices[coords[9]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step9()
        {
            var text = "If there is no trunk with three colored leaves after Bob's turn, Alice can color any vertex, so long as it does not create such a trunk.";
            var vertices = newVertices();
            vertices[coords[1]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[11]].color = Color.Green;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[4]].color = Color.Yellow;
            vertices[coords[10]].color = Color.Yellow;
            vertices[coords[8]].color = Color.Blue;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
