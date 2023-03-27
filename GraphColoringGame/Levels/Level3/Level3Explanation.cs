using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GraphColoringGame.Levels
{
    public class Level3Explanation : LevelExplanation
    //TODO: MAKE EXPLANATION PAGE
    {
        private Coord[] coords;

        public Level3Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[]{
            new Coord(0,1), // coords[0]
            new Coord(1, 1), // 1
            new Coord(2, 1), //2
            new Coord(3, 1),//3
            new Coord(2, 0),//4
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
            var text = "In this Level, Alice cannot win with just two colors. \n Let's say Alice colors the green outlined vertex Red";
            var vertices = newVertices();

            vertices[coords[1]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2() 
        {
            var text = "Then Bob can color a vertex blue at distance 2 away from the vertex Alice has colored."; // REWORD THIS
            var vertices = newVertices();

            vertices[coords[1]].color = Graphs.Color.Red;
            vertices[coords[3]].outline = purple;
            vertices[coords[4]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3()
        {
            var text = "Now Alice cannot color the green vertex as there is no legal color avaliable, since only the colors red and blue are avaliable"; // CHECK FOR ERROR
            var vertices = newVertices();

            vertices[coords[1]].color = Graphs.Color.Red;
            vertices[coords[3]].color = Graphs.Color.Red;
            vertices[coords[4]].color = Graphs.Color.Red;
            vertices[coords[2]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);


        }
    }
}
