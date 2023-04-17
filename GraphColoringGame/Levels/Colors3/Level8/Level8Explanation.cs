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
     *      0   0   0
     *      |   |   |
     *  0 - 0 - 0 - 0 - 0
     *      |   |   |
     *      0   0   0
     */
    public class Level8Explanation : LevelExplanation
    {

        private Coord[] coords;


        public Level8Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
            new Coord(1,0), // coords[0]
            new Coord(2, 0), // 1
            new Coord(3, 0), //2
            new Coord(0, 1),//3
            new Coord(1,1),//4
            new Coord(2, 1),//5
            new Coord(3, 1),//6
            new Coord(4, 1),//7
            new Coord(1,2), // 8
            new Coord(2,2), // 9
            new Coord(3,2), // 10
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
            var text = "In this scenerio, Bob has a winning strategy from the get go. If Alice chooses to color a vertex, Bob can color a vertex at distance 3 away with the same color.";
            var vertices = newVertices();

            vertices[coords[4]].outline = green;
            vertices[coords[2]].outline = purple;
            vertices[coords[10]].outline = purple;
            vertices[coords[7]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "Now Alice can respond by coloring either of the remaining two dangerous vertices with an available color";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[4]].color = Color.Red;
            vertices[coords[6]].outline = green;
            vertices[coords[5]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3() 
        {
            var text = "Bob can now respond by coloring one of the neighbors of the other dangerous vertex with the only avaliable color for the uncolored dangerous vertex to win.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[4]].color = Color.Red;
            vertices[coords[6]].color = Color.Green;
            vertices[coords[1]].outline = purple;
            vertices[coords[9]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step4() 
        {
            var text = "Now the dangerous vertex is uncolorable and Bob has won.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[4]].color = Color.Red;
            vertices[coords[6]].color = Color.Green;
            vertices[coords[1]].color = Color.Blue;
            vertices[coords[5]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }

        public ExplanationStep step5() 
        {
            var text = "Notice this will also happen, if Alice chosed to color the other dangerous vertex. Here, Bob will simply color one of the neighbors to the other dangerous vertex to win as this will make the dangerous vertex uncolorable.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[4]].color = Color.Red;
            vertices[coords[5]].color = Color.Green;
            vertices[coords[7]].outline = purple;
            vertices[coords[10]].outline = purple;
            vertices[coords[6]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }
    }
}
