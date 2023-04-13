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
    public class Level11Explanation : LevelExplanation
    {
        private Coord[] coords;

        public Level11Explanation(Graph graph) : base(graph)
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
            new Coord(4,1),
            new Coord(5,1),// 9
            new Coord(1,2), //10
            new Coord(2,2), //11
            new Coord(3, 3), //12
            new Coord(4, 3), //13
          };
        }

        public List<ExplanationStep> GetExplanation() => new List<ExplanationStep>()
        {
                step1(),
                step2(),
                step3(),
        };

        public ExplanationStep step1()
        {
            var text = "This is the same level as level 8, however, this time it is with 4 colors. This means that Alice can win.";
            var vertices = newVertices();

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2() 
        {
            var text = "First, let's identify the dangerous vertices. There are 4 in total next to each other.";
            var vertices = newVertices();

            vertices[coords[5]].outline = green;
            vertices[coords[6]].outline = green;
            vertices[coords[7]].outline = green;
            vertices[coords[8]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        
        }

        public ExplanationStep step3() 
        {
            var text = "Since there are 4 colors instead of 3, Alice can more easily color the dangerous vertecies one by one without too much worrying. Bob will have a hard time stopping Alice as the degree (the number of neighboring vertices) of the dangerous vertices are equal to the number of legal colors, instead of being higher than the number of legal colors";
            var vertices = newVertices();


            vertices[coords[4]].outline = purple;
            vertices[coords[5]].outline = purple;
            vertices[coords[0]].outline = purple;
            vertices[coords[10]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
