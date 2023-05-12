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
     */
    public class Level12Explanation : LevelExplanation
    {
        private Coord[] coords;

        public Level12Explanation(Graph graph) : base(graph)
        {
          coords = new Coord[] {
            new Coord(1, 0), //coords[0]
            new Coord(2, 0), //1
            new Coord(3, 0), //2
            new Coord(4, 0), //3
            // Row 2
            new Coord(0, 1), //4
            new Coord(1, 1), //5
            new Coord(2, 1), //6
            new Coord(3, 1), //7
            new Coord(4, 1), //8
            new Coord(5, 1), //9
            // Row 3
            new Coord(1, 2), //10
            new Coord(2, 2), //11
            new Coord(3, 2), //12
            new Coord(4, 2), //13
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
            var text = "In this graph on 14 vertices Alice cannot win the 3-coloring game. \n\nThis is the smallest graph which requires four colors for Alice to have a winning strategy.";
            var vertices = newVertices();

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "No matter which vertex Alice colors, there will exist some vertex at distance three away (shown purple).";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;
            vertices[coords[2]].outline = purple;
            vertices[coords[8]].outline = purple;
            vertices[coords[12]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3() 
        {
            var text = "Bob can color such a vertex to create the subgraph shown, which he can win as demonstrated in level 9. \n\nAs Bob only needs to make a single vertex uncolorable to win, he can disregard anything outside of the subgraph.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;
            vertices[coords[8]].color = Color.Red;

            //greyout
            vertices[coords[0]].opacity = greyout;
            vertices[coords[3]].opacity = greyout;
            vertices[coords[9]].opacity = greyout;
            vertices[coords[13]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;
            vertices[coords[4]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
