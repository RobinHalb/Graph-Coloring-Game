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
    /*
     * 0 - 0 - 0 - 0 - 0
     */
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
        };

        public ExplanationStep step1()
        {
            var text = "When playing this graph using two colors, Bob has a winning strategy. \n\nThis means that Alice cannot win, if Bob plays correctly. \n\nNotice that this graph contains two dangerous vertices (shown green).";
            var vertices = newVertices();
            vertices[coords[1]].outline = green;
            vertices[coords[2]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "When four vertices are connected in a line, any vertex that Alice colors will have some uncolored vertex (shown purple) with a dangerous vertex (shown green) inbetween. \n\nBob may then color the purple vertex with the remaining color to win.";
            var vertices = newVertices();

            vertices[coords[0]].color = Graphs.Color.Red;
            vertices[coords[1]].outline = green;
            vertices[coords[2]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3() 
        {
            var text = "When four vertices are connected in a line, any vertex that Alice colors will have some uncolored vertex (shown purple) with a dangerous vertex (shown green) inbetween. \n\nBob may then color the purple vertex with the remaining color to win.";
            var vertices = newVertices();
            
            vertices[coords[1]].color = Graphs.Color.Red;
            vertices[coords[2]].outline = green;
            vertices[coords[3]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
