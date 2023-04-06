using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    /// <summary>
    /// This graph is supposed to show the Player the subcase in case 3 with dangerous vertices where x and y are not adjacent.
    /// </summary>
    public class Level5Explanation : LevelExplanation
    {
        private Coord[] coords;

        public Level5Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
            new Coord(1,0), // coords[0]
            new Coord(0, 1), // 1
            new Coord(1, 1),//2
            new Coord(2, 1),//3
            new Coord(1, 2),//4
            new Coord(2,2), //5
            new Coord(3,2), //6
          };
        }

        public List<ExplanationStep> GetExplanation() => new List<ExplanationStep>()
        {
                step1(),
                step2(),
                step3()
        };

        public ExplanationStep step1()
        {
            var text = "This scenario will show the last case with two dangerous vertices in a subgraph with at most 7 vertices.\n" +
                    "Let's imagine Alice and Bob have both played so that both dangerous vertices have one colored neighbor each.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Blue;
            vertices[coords[3]].color = Color.Blue;
            vertices[coords[2]].outline = purple;
            vertices[coords[5]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2() 
        {
            var text = "In this case, both of the dangerous vertices have three neighbors. Alice can choose one of the dangerous vertices and color it with a legal color to reach a winning position.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Blue;
            vertices[coords[3]].color = Color.Blue;
            vertices[coords[2]].outline = purple;
            vertices[coords[5]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3() 
        {
            var text = "Now Bob cannot prevent any vertex from being colored. If one of the dangerous vertices has more than three neighbors, Alice should color the dangerous vertex with three neighbors to reach a winning position.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Blue;
            vertices[coords[3]].color = Color.Blue;
            vertices[coords[5]].color = Color.Red;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
