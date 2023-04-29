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
     *      0   0   0
     *      |   |   |
     *  0 - 0 - 0 - 0 - 0
     *      |   |   |
     *      0   0   0
     */
    public class Level11Explanation : LevelExplanation
    {

        private Coord[] coords;


        public Level11Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
            new Coord(1, 0), // coords[0]
            new Coord(2, 0), // 1
            new Coord(3, 0), //2
            new Coord(0, 1),//3
            new Coord(1, 1),//4
            new Coord(2, 1),//5
            new Coord(3, 1),//6
            new Coord(4, 1),//7
            new Coord(1, 2), // 8
            new Coord(2, 2), // 9
            new Coord(3, 2), // 10
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
        };

        public ExplanationStep step1()
        {
            var text = "In this graph of 11 vertices, Alice has a winning strategy.";
            var vertices = newVertices();

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "To win, Alice must color the middle vertex.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3()
        {
            var text = " If Bob colors one of remaining the dangerous vertices, Alice can color the other dangerous vertex (shown green) to win.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;
            vertices[coords[4]].color = Color.Blue;
            vertices[coords[6]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step4()
        {
            var text = "Otherwise, Bob may color a neighbor to a dangerous vertex (shown green).";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[4]].outline = green;
            
            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step5()
        {
            var text = "Alice colors said dangerous vertex. \n\nWith only one dangerous vertex (shown purple) remaining, Alice can color it on her next turn to win.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[4]].color = Color.Green;
            vertices[coords[6]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step6()
        {
            var text = "If Alice instead colors a vertex other than the middle, Bob may color a vertex at distance 3 away (shown green) with the same color.";
            var vertices = newVertices();

            vertices[coords[4]].color = Color.Red;
            vertices[coords[2]].outline = green;
            vertices[coords[7]].outline = green;
            vertices[coords[10]].outline = green;


            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step7()
        {
            var text = "This creates a subgraph in which Bob has a winning strategy, as was shown in level 9.";
            var vertices = newVertices();

            vertices[coords[4]].color = Color.Red;
            vertices[coords[7]].color = Color.Red;

            vertices[coords[0]].opacity = greyout;
            vertices[coords[3]].opacity = greyout;
            vertices[coords[8]].opacity = greyout;


            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
