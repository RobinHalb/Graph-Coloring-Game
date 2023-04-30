using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System.Collections.Generic;

namespace GraphColoringGame.Levels
{
    /*
     *      0   0       a
     *      |   |       |
     *  a - 0 - 0 - b - 0
     *      |   |       |
     *      0   0       0
     * */
    public class Level10Explanation : LevelExplanation
    {
        private Coord[] coords;
        public Level10Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
                new Coord(1,0), // coords[0]
                new Coord(2, 0), // 1
                new Coord(4, 0), // 2
                new Coord(0, 1), //3
                new Coord(1, 1),//4
                new Coord(2, 1),//5
                new Coord(3, 1),//6
                new Coord(4, 1),//7
                new Coord(1, 2),//8
                new Coord(2, 2),//9
                new Coord(4, 2),//10
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
            var text = "In this subgraph on 11 vertices, Bob has a winning strategy for the 3-coloring game. \n\nThis graph contains three dangerous vertices (shown green).";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[4]].outline = green;
            vertices[coords[5]].outline = green;
            vertices[coords[7]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "One of these dangerous vertices has only one available color remaining (shown purple).";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[4]].outline = green;
            vertices[coords[5]].outline = green;
            vertices[coords[7]].outline = purple;
            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3()
        {
            var text = "If Alice does not color this vertex or make it non-dangerous, Bob can win on his turn.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[10]].color = Color.Green;
            vertices[coords[7]].outline = black;
            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step4()
        {
            var text = "Now suppose Alice does color said vertex.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[7]].color = Color.Green;
            
            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step5() 
        {
            var text = "Bob will choose a dangerous vertex (shown green) and color a leaf with the color used by the vertex at distance two away. \n\nThe dangerous vertex now has one legal color.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[7]].color = Color.Green;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[4]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step6()
        {
            var text = "If Alice does not color this vertex, Bob can win on his turn.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[7]].color = Color.Green;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[8]].color = Color.Green;
            vertices[coords[4]].outline = black;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step7()
        {
            var text = "If Alice colors the vertex, the remaining dangerous vertex (shown purple) has only one color available.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[7]].color = Color.Green;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[4]].color = Color.Green;
            vertices[coords[5]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step8() 
        {
            var text = "Bob can now use  this vertex to win.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[7]].color = Color.Green;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[4]].color = Color.Green;
            vertices[coords[9]].color = Color.Red;
            vertices[coords[5]].outline = black;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }
        /*
        public ExplanationStep step7()
        {
            var text = "Bob can then color a neighbor of the other dangerous vertex (shown green) with the same color.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[7]].color = Color.Blue;
            vertices[coords[3]].outline = green;
            vertices[coords[0]].color = Color.Blue;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }

        public ExplanationStep step8()
        {
            var text = "The dangerous vertex now has only one legal color left. \n\nIf Alice does not color this dangerous vertex, Bob can win by coloring either of the neighboring vertices (shown purple).";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[7]].color = Color.Blue;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[3]].outline = green;
            vertices[coords[6]].outline = purple;
            vertices[coords[4]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }

        public ExplanationStep step9() 
        {
            var text = "If Alice does color the dangerous vertex with the remaining color, Bob can win by coloring the last neighbor (shown purple) of the other dangerous vertex.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[7]].color = Color.Blue;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[3]].color = Color.Green;
            vertices[coords[1]].outline = purple;
            
            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
        */
    }
}
