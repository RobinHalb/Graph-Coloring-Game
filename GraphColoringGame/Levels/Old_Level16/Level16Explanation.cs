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
     *      0   0   0   0
     *      |   |   |   |
     *  0 - 0 - 0 - 0 - 0 - 0
     *      |   |   |   |
     *      0   0   0   0
     *
     */
    public class Level16aExplanation : LevelExplanation
    {
        private Coord[] coords;

        public Level16aExplanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
            new Coord(1,0), // coords[0]
            new Coord(2, 0), // 1
            new Coord(3, 0), //2
            new Coord(4, 0),//3
            new Coord(0, 1),//4
            new Coord(1, 1),//5
            new Coord(2, 1),//6
            new Coord(3, 1),//7
            new Coord(4,1), // 8
            new Coord(5,1),// 9
            new Coord(1,2), //10
            new Coord(2,2), //11
            new Coord(3, 2), //12
            new Coord(4, 2), //13
          };
        }

        public List<ExplanationStep> GetExplanation() => new List<ExplanationStep>()
        {
                step1(),
                step2(),
                step3(),
                step4()
        };

        public ExplanationStep step1()
        {
            var text = "This is the same level as level 11, however, this time it is with 4 colors meaning Alice can win by spliting the graph into trunks. \n\n Alice may color one of the dangerous vertices (shown green) to split the graph into different trunks.";
            var vertices = newVertices();

            vertices[coords[5]].outline = green;
            vertices[coords[6]].outline = green;
            vertices[coords[7]].outline = green;
            vertices[coords[8]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "Alice can on her next turn color a vertex in the same trunk as Bob if there is an uncolored vertex in it. There are current 4 trunks. \n\n The two smallest are the colored vertex' neighbors above and below it (shown green and purple). The colored vertex are included in all the current trunks.";
            var vertices = newVertices();

            vertices[coords[6]].color = Color.Red;
            vertices[coords[1]].outline = green;
            vertices[coords[11]].outline = purple;
            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3()
        {
            var text = "Alice can on her next turn color a vertex in the same trunk as Bob if there is an uncolored vertex in it. There are current 4 trunks. \n\n The other two trunks are to the left and right of the vertex (shown green and purple). The colored vertex are included in all the current trunks. ";
            var vertices = newVertices();

            vertices[coords[6]].color = Color.Red;
            vertices[coords[0]].outline = green;
            vertices[coords[4]].outline = green;
            vertices[coords[5]].outline = green;
            vertices[coords[10]].outline = green;
            vertices[coords[2]].outline = purple;
            vertices[coords[3]].outline = purple;
            vertices[coords[7]].outline = purple;
            vertices[coords[8]].outline = purple;
            vertices[coords[9]].outline = purple;
            vertices[coords[12]].outline = purple;
            vertices[coords[13]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step4()
        {
            var text = "Alice can on her next turn color a vertex in the same trunk as Bob if there is an uncolored vertex in it.";
            var vertices = newVertices();

            vertices[coords[6]].color = Color.Red;
            vertices[coords[9]].color = Color.Red;

            vertices[coords[0]].opacity = greyout;
            vertices[coords[1]].opacity = greyout;
            vertices[coords[4]].opacity = greyout;
            vertices[coords[5]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;
            vertices[coords[11]].opacity = greyout;


            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
