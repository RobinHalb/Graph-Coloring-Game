using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows.Media;

namespace GraphColoringGame.Levels
{
    public class Level2Explanation : LevelExplanation
    {
        //TODO: MAKE EXPLANATION PAGE
        private Coord[] coords;

        public Level2Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
                new Coord(0,0), // coords[0]
                new Coord(1, 0), // 1
                new Coord(2, 0), //2
                new Coord(3, 0),//3
            };
        }

        public List<ExplanationStep> GetExplanation() => new List<ExplanationStep>()
        {
                step1(),
                step2(),
                step3(),
                step4(),
        };

        public ExplanationStep step1()
        {
            var text = "In this level, Alice cannot win with only two colors as there are two dangerours vertices marked with green";
            var vertices = newVertices();
            vertices[coords[1]].outline = green;
            vertices[coords[2]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "If Alice colors one of the dangerous vertices red, Bob can simply color the vertex at distance 2 away blue to win as Alice cannot counterplay both dangerous " +
                "vertices in one round";
            var vertices = newVertices();
            vertices[coords[1]].color = Graphs.Color.Red;
            vertices[coords[3]].outline = purple;


            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3() 
        {
            var text = "After Bob has colored the vertex blue, there is no avaliable color for the marked vertex and Alice losses.";
            var vertices = newVertices();
            vertices[coords[1]].color = Graphs.Color.Red;
            vertices[coords[3]].color = Graphs.Color.Blue;
            vertices[coords[2]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step4() 
        {
            var text = "this also happens if Alice colors the other dangerous vertex instead";
            var vertices = newVertices();
            vertices[coords[2]].color = Graphs.Color.Red;
            vertices[coords[0]].color = Graphs.Color.Blue;
            vertices[coords[1]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
