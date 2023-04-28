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
     *  0 - 0
     *      |
     *      0   0   0   0   0
     *      |   |   |   |   |
     *      0 - 0 - 0 - 0 - 0 - 0
     *          |   |   |   |
     *          0   0   0   0
     */
    public class Level12Explanation : LevelExplanation
    {
        private Coord[] coords;

        public Level12Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
            new Coord(0, 0), //0
            new Coord(1, 0), //1
            new Coord(1, 1), //2
            new Coord(2,1), // 3
            new Coord(3, 1), // 4
            new Coord(4, 1), //5
            new Coord(5,1),//6
            new Coord(1,2), //7
            new Coord(2, 2),//8
            new Coord(3, 2),//9
            new Coord(4, 2),//10
            new Coord(5, 2),//11
            new Coord(6,2), // 12
            new Coord(2,3),// 13
            new Coord(3,3), //14
            new Coord(4,3), //15
            new Coord (5,3), //16
          };

        }


        public List<ExplanationStep> GetExplanation() => new List<ExplanationStep>()
        {
                step1(),
                step2(),
                step3(),
                step4(),
                step5(),
        };


        public ExplanationStep step1()
        {
            var text = "This level is a modification of the previous level. Alice cannot win in this graph with only 3 colors. \n\n If she colors any of the vertices at the side (shown green), Bob can play in middle of the graph near the dangerous vertices (shown purple) trying to make a vertex uncolorable.";
            var vertices = newVertices();

            vertices[coords[0]].outline = green;
            vertices[coords[1]].outline = green;
            vertices[coords[2]].outline = green;
            vertices[coords[7]].outline = green;
            vertices[coords[8]].outline = purple;
            vertices[coords[9]].outline = purple;
            vertices[coords[10]].outline = purple;
            vertices[coords[11]].outline = purple;


            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "Bob's objective is to make a subgraph similar to Level 9 appear in the graph, possiblities of this shown purple.";
            var vertices = newVertices();


            vertices[coords[2]].color = Color.Red;
            vertices[coords[3]].outline = purple;
            vertices[coords[4]].outline = purple;
            vertices[coords[7]].outline = purple;
            vertices[coords[10]].outline = purple;
            vertices[coords[13]].outline = purple;
            vertices[coords[14]].outline = purple;



            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }

        public ExplanationStep step3()
        {
            var text = "Bob's objective is to a subgraph similar to Level 9 appear in the graph, where Alice cannot win.";
            var vertices = newVertices();


            vertices[coords[2]].color = Color.Red;
            vertices[coords[4]].outline = purple;
            vertices[coords[5]].outline = purple;
            vertices[coords[8]].outline = purple;
            vertices[coords[11]].outline = purple;
            vertices[coords[14]].outline = purple;
            vertices[coords[15]].outline = purple;



            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }

        public ExplanationStep step4()
        {
            var text = "Bob's objective is to a subgraph similar to Level 9 appear in the graph, where Alice cannot win.";
            var vertices = newVertices();


            vertices[coords[2]].color = Color.Red;
            vertices[coords[5]].outline = purple;
            vertices[coords[6]].outline = purple;
            vertices[coords[9]].outline = purple;
            vertices[coords[12]].outline = purple;
            vertices[coords[15]].outline = purple;
            vertices[coords[16]].outline = purple;



            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }

        public ExplanationStep step5()
        {
            var text = "When such a subgraph has been reach, the level plays out similar to Level 9 with addtional leaves.";
            var vertices = newVertices();


            vertices[coords[2]].color = Color.Red;
            vertices[coords[5]].outline = purple;
            vertices[coords[6]].outline = purple;
            vertices[coords[9]].outline = purple;
            vertices[coords[12]].outline = purple;
            vertices[coords[15]].outline = purple;
            vertices[coords[16]].outline = purple;



            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }

    }
}
