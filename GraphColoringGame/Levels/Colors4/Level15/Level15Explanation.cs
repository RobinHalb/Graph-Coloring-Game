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
    public class Level15Explanation : LevelExplanation
    {
        private Coord[] coords;

        public Level15Explanation(Graph graph) : base(graph)
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
               // step2(),
               // step3(),
        };

        public ExplanationStep step1()
        {
            var text = "This is the same level as level 8, however, this time it is with 4 colors meaning Alice can win.";
            var vertices = newVertices();

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
