using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level9Explanation : LevelExplanation
    {
        /// <summary>
        /// Modified 4 leg graph:
        /// 0 - 0
        ///     |
        ///     0   0   0   0   0
        ///     |   |   |   |   |
        ///     0 - 0 - 0 - 0 - 0 - 0
        ///         |   |   |   |
        ///         0   0   0   0
        ///     
        /// </summary>
        private Coord[] coords;

        public Level9Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
            new Coord(0, 0), //1
            new Coord(1, 0), //2
            new Coord(1, 1), //3
            new Coord(2,2), // 4
            new Coord(3, 1), // 5
            new Coord(4, 1), //6
            new Coord(5,1),//7
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
        };


        public ExplanationStep step1()
        {
            var text = "This Level from the proof";
            var vertices = newVertices();

            vertices[coords[2]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

    }
}
