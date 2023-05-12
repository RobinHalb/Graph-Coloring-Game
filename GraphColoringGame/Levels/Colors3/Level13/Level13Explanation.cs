using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GraphColoringGame.Levels
{
    /*
     *      0   0   0   0   0
     *      |   |   |   |   |
     *      0 - 0 - 0 - 0 - 0 - 0
     *          |   |   |   |
     *          0   0   0   0
     */
    public class Level13Explanation : LevelExplanation
    {
        private Coord[] coords;

        public Level13Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
                new Coord(0, 0), // 0
                new Coord(1, 0), // 1
                new Coord(2, 0), // 2
                new Coord(3, 0), //3
                new Coord(4, 0), //4
                // Row 2
                new Coord(0, 1), //5
                new Coord(1, 1), //6
                new Coord(2, 1), //7
                new Coord(3, 1), //8
                new Coord(4, 1), // 9
                new Coord(5, 1), // 10
                // Row 3
                new Coord(1, 2), //11
                new Coord(2, 2), //12
                new Coord(3, 2), //13
                new Coord(4, 2), //14
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
                step10(),
                step11(),
                step12(),
                step13(),
                step14(),
                step15(),
                step16(),
                step17(),
        };


        public ExplanationStep step1()
        {
            var text = "This graph on 15 vertices contains the graph from level 12 as a subgraph (shown green). \n\nAlice cannot win the 3-coloring game when this subgraph exists in the graph.";
            var vertices = newVertices();

            vertices[coords[1]].outline = green;
            vertices[coords[2]].outline = green;
            vertices[coords[3]].outline = green;
            vertices[coords[4]].outline = green;
            vertices[coords[5]].outline = green;
            vertices[coords[6]].outline = green;
            vertices[coords[7]].outline = green;
            vertices[coords[8]].outline = green;
            vertices[coords[9]].outline = green;
            vertices[coords[10]].outline = green;
            vertices[coords[11]].outline = green;
            vertices[coords[12]].outline = green;
            vertices[coords[13]].outline = green;
            vertices[coords[14]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "In this version, the subgraph is connected by an outer vertex of the longest path in the subgraph (shown green).";
            var vertices = newVertices();

            vertices[coords[5]].outline = green;
            vertices[coords[6]].outline = green;
            vertices[coords[7]].outline = green;
            vertices[coords[8]].outline = green;
            vertices[coords[9]].outline = green;
            vertices[coords[10]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3()
        {
            var text = "If Alice colors any vertex inside the subgraph, Bob will follow the strategy from level 12 and color a vertex in the subgraph at distance three (shown purple), to create the subgraph from level 9.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[3]].outline = purple;
            vertices[coords[9]].outline = purple;
            vertices[coords[13]].outline = purple;

            vertices[coords[0]].opacity = greyout;
            vertices[coords[1]].opacity = greyout;
            vertices[coords[4]].opacity = greyout;
            vertices[coords[5]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;
            vertices[coords[11]].opacity = greyout;
            vertices[coords[14]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }

        public ExplanationStep step4()
        {
            var text = "Otherwise, Alice must color a vertex outside the subgraph.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }

        public ExplanationStep step5()
        {
            var text = "Bob then colors one of the vertices at the ends of the longest path in the subgraph. \n\nIf one of these has a colored neighbor, that is the one he colors.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }

        public ExplanationStep step6()
        {
            var text = "If Alice colors a vertex at distance three away with the same color, a subgraph is created, which Bob can win as described in level 9.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[8]].color = Color.Blue;

            vertices[coords[0]].opacity = greyout;
            vertices[coords[3]].opacity = greyout;
            vertices[coords[9]].opacity = greyout;
            vertices[coords[13]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;
            vertices[coords[4]].opacity = greyout;
            vertices[coords[14]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step7()
        {
            var text = "Suppose Alice colors a vertex at distance three away with a different color.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[8]].color = Color.Red;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step8()
        {
            var text = "Bob can now color a vertex at distance two away to win as described in level 10.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[8]].color = Color.Red;
            vertices[coords[4]].color = Color.Blue;

            vertices[coords[0]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step9()
        {
            var text = "There are six vertices in the subgraph which are at a distance more than three (shown green).";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[3]].outline = green;
            vertices[coords[4]].outline = green;
            vertices[coords[9]].outline = green;
            vertices[coords[10]].outline = green;
            vertices[coords[13]].outline = green;
            vertices[coords[14]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step10()
        {
            var text = "Now suppose Alice colors one of these, or some other vertex outside of the subgraph.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[9]].color = Color.Blue;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step11()
        {
            var text = "Bob then colors a vertex at distance three away from his original vertex to win the created subgraph as described in level 9.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[2]].color = Color.Blue;
            vertices[coords[9]].color = Color.Blue;

            vertices[coords[0]].opacity = greyout;
            vertices[coords[3]].opacity = greyout;
            vertices[coords[9]].opacity = greyout;
            vertices[coords[13]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;
            vertices[coords[4]].opacity = greyout;
            vertices[coords[14]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step12()
        {
            var text = "There are two dangerous vertices (shown green) at distance less than two.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[6]].outline = green;
            vertices[coords[7]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step13()
        {
            var text = "If Alice colors one of these, Bob may color a vertex at distance three away (shown purple) with the same color to win as described in level 9.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].outline = purple;
            vertices[coords[10]].outline = purple;
            vertices[coords[14]].outline = purple;

            vertices[coords[0]].opacity = greyout;
            vertices[coords[1]].opacity = greyout;
            vertices[coords[2]].opacity = greyout;
            vertices[coords[5]].opacity = greyout;
            vertices[coords[6]].opacity = greyout;
            vertices[coords[11]].opacity = greyout;
            vertices[coords[12]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step14()
        {
            var text = "Lastly, Alice may color a leaf at distance two away with the same or a different color. \n\nIf she uses a different color, Bob can win on the next turn.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[1]].color = Color.Blue;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step15()
        {
            var text = "If she has used the same color, Bob must color the dangerous vertex at distance one away with a different color. \n\nThe dangerous vertex (shown green) between them now has only one legal color left.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[1]].color = Color.Blue;
            vertices[coords[7]].color = Color.Red;
            vertices[coords[6]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin); 
        }

        public ExplanationStep step16()
        {
            var text = "If Alice does not color or stop this vertex from being dangerous, Bob can win by coloring the remaining neighbor (shown purple).";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[1]].color = Color.Blue;
            vertices[coords[7]].color = Color.Red;
            vertices[coords[6]].outline = green;
            vertices[coords[11]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step17()
        {
            var text = "If Alice does color the dangerous vertex, Bob may color a vertex (shown purple) at distance three away from his last colored vertex with the same color to win as described in level 9.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[1]].color = Color.Blue;
            vertices[coords[7]].color = Color.Red;
            vertices[coords[6]].color = Color.Green;
            vertices[coords[4]].outline = purple;
            vertices[coords[10]].outline = purple;
            vertices[coords[14]].outline = purple;

            vertices[coords[0]].opacity = greyout;
            vertices[coords[1]].opacity = greyout;
            vertices[coords[2]].opacity = greyout;
            vertices[coords[5]].opacity = greyout;
            vertices[coords[6]].opacity = greyout;
            vertices[coords[11]].opacity = greyout;
            vertices[coords[12]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
