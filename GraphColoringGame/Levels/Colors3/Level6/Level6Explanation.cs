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
     * This graph is supposed to show the Player the subcase in case 3 with dangerous vertices where x and y are not adjacent.
     * 
     *      
     *      0       0
     *      |       |
     *  0 - 0 - 0 - 0 - 0
     */
    public class Level6Explanation : LevelExplanation
    {
        private Coord[] coords;

        public Level6Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
            new Coord(1,0), // coords[0]
            new Coord(3, 0), // 1
            new Coord(0, 1),//2
            new Coord(1, 1),//3
            new Coord(2, 1),//4
            new Coord(3, 1), //5
            new Coord(4, 1), //6
          };
        }

        public List<ExplanationStep> GetExplanation() => new List<ExplanationStep>()
        {
                step1(),
                step2(),
        };

        public ExplanationStep step1()
        {
            var text = "In a trunk of 7 vertices, where two dangerous vertices (shown purple) are not adjacent to each other and each has one colored neighbor, Alice may color any dangerous vertex with an available color.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[3]].outline = purple;
            vertices[coords[5]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2() 
        {
            var text = "The remaining dangerous vertex (shown purple), will now still have only one colored neighbor. \n\nBob can therefore add only one more colored neighbor, before Alice colors the vertex to win.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[6]].color = Color.Blue;
            vertices[coords[3]].color = Color.Blue;
            vertices[coords[5]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
