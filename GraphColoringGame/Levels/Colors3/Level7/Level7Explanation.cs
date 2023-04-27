using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System.Collections.Generic;

namespace GraphColoringGame.Levels
{
    /*
     *      0   0
     *      |   |
     *  a - 0 - 0 - a
     *      |   |
     *      0   0
     * */
    public class Level7Explanation : LevelExplanation
    {
        private Coord[] coords;
        public Level7Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
            new Coord(1, 0), // coords[0]
            new Coord(2, 0), // 1
            new Coord(0, 1), //2
            new Coord(1, 1),//3
            new Coord(2, 1),//4
            new Coord(3, 1),//5
            new Coord(1, 2),
            new Coord(2, 2)
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
            var text = "In this subgraph on 8 vertices, Bob has a winning strategy when played using 3 colors. \n\nThis graph contains two dangerous vertices (shown green).";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[5]].color = Color.Red;
            vertices[coords[3]].outline = green;
            vertices[coords[4]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "If Alice colors one of them, Bob can color a neighbor (shown purple) of the remaining dangerous vertex with a third color to make the dangerous vertex uncolorable.";
            var vertices = newVertices();


            vertices[coords[2]].color = Color.Red;
            vertices[coords[5]].color = Color.Red;
            vertices[coords[3]].color = Color.Blue;
            vertices[coords[1]].outline = purple;
            vertices[coords[7]].outline = purple;
            vertices[coords[4]].outline = green;
            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3() 
        {
            var text = "If Alice colors a leaf with a color other than Red, then the neighboring dangerous vertex (shown green) has only one legal color available. \n\nBob can color one of its neighbors (shown purple) in the the remaining color to win.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[5]].color = Color.Red;
            vertices[coords[7]].color = Color.Blue;
            vertices[coords[1]].outline = purple;
            vertices[coords[3]].outline = purple;
            vertices[coords[4]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
        
        public ExplanationStep step4() 
        {
            var text = "If Alice colors the leaf with red, Bob can color a neighbor (shown purple) of the other dangerous vertex (shown green) with a different color.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[5]].color = Color.Red;
            vertices[coords[7]].color = Color.Red;
            vertices[coords[3]].outline = green;
            vertices[coords[0]].outline = purple;
            vertices[coords[6]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }

        public ExplanationStep step5()
        {
            var text = "One of the dangerous vertices (shown green) now has only one legal color left. \n\nIf Alice does not color this dangerous vertex, Bob can win by coloring either of the neighboring vertices (shown purple).";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[5]].color = Color.Red;
            vertices[coords[7]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[3]].outline = green;
            vertices[coords[6]].outline = purple;
            vertices[coords[4]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }

        public ExplanationStep step6() 
        {
            var text = "If Alice instead does color the dangerous vertex with the remaining color, Bob can win by coloring the last neighbor (shown purple) of the other dangerous vertex.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[5]].color = Color.Red;
            vertices[coords[7]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[3]].color = Color.Green;
            vertices[coords[1]].outline = purple;
            
            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }
    }
}
