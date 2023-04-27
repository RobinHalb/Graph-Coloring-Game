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
    public class Level9Explanation : LevelExplanation
    {
        private Coord[] coords;

        public Level9Explanation(Graph graph) : base(graph)
        {
          coords = new Coord[] {
            new Coord(1, 0), // coords[0]
            new Coord(2, 0), // 1
            new Coord(3, 0), //2
            new Coord(4, 0),//3
            new Coord(0, 1),//4
            new Coord(1, 1),//5
            new Coord(2, 1),//6
            new Coord(3, 1),//7
            new Coord(4, 1),
            new Coord(5, 1),// 9
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
                //step4(),
                //step5(),
        };

        public ExplanationStep step1()
        {
            //var text = "In this level, Alice cannot win. This can easily be shown by considering the following: If Alice colors any vertex, example the outlined one...";
            var text = "When playing on trees with more than 13 vertices, Alice cannot win with only 3 colors. If Alice colors any vertex then Bob can color any vertex at distance 3 away (shown purple) with the same color to win.";
            var vertices = newVertices();

            vertices[coords[5]].outline = green;
            vertices[coords[2]].outline = purple;
            vertices[coords[8]].outline = purple;
            vertices[coords[12]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2() 
        {
            //var text = "Notice, that if Bob colors this vertex Red, the layout of the graph is a graph similar to Level 6, but with some addtional leaves.";
            var text = "This will create a trunk similar to the graph in Level 9 with some additional leaves.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;
            vertices[coords[8]].color = Color.Red;
            //vertices[coords[8]].outline = green;

            //greyout
            vertices[coords[0]].opacity = greyout;
            vertices[coords[3]].opacity = greyout;
            vertices[coords[9]].opacity = greyout;
            vertices[coords[13]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;
            vertices[coords[4]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3() 
        {
            //var text = "The level can be played out as Level 8, where Alice can color one of the dangerous vertices."; Level 9 = the current level 7.
            var text = "The level can be played out as Level 9 where Alice can color one of the dangerous vertices (shown green), and Bob can respond by coloring a neighbor of the uncolored dangerous vertex on his next turn to make it uncolorable.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;
            vertices[coords[8]].color = Color.Red;
            vertices[coords[7]].outline = green;
            vertices[coords[6]].outline = green;
            vertices[coords[1]].outline = purple;
            vertices[coords[2]].outline = purple;
            vertices[coords[11]].outline = purple;
            vertices[coords[12]].outline = purple;

            //greyout
            vertices[coords[0]].opacity = greyout;
            vertices[coords[3]].opacity = greyout;
            vertices[coords[9]].opacity = greyout;
            vertices[coords[13]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;
            vertices[coords[4]].opacity = greyout;



            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
/*
        public ExplanationStep step5() 
        {

            var text = "Bob can respond by coloring a neighbor of the uncolored dangerous vertex on his next turn to make it uncolorable.";
            var vertices = newVertices();

            vertices[coords[5]].color = Color.Red;
            vertices[coords[8]].color = Color.Red;
            vertices[coords[7]].color = Color.Blue;
            vertices[coords[6]].outline = green;
            vertices[coords[1]].outline = purple;
            vertices[coords[11]].outline = purple;

            //greyout
            vertices[coords[0]].opacity = greyout;
            vertices[coords[3]].opacity = greyout;
            vertices[coords[9]].opacity = greyout;
            vertices[coords[13]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;
            vertices[coords[4]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }
*/

        //SHOULD THIS BE SHOWN AT A DIFFERENT STARTING PONT?
        /*
        public ExplanationStep step6() 
        {
            var text = "This graph is an example of a graph that requires at least 4 colors for Alice to have a winning strategy.";

            var vertices = newVertices();


            vertices[coords[5]].color = Color.Red;
            vertices[coords[8]].color = Color.Red;
            vertices[coords[7]].color = Color.Blue;
            vertices[coords[6]].outline = green;
            vertices[coords[1]].outline = purple;
            vertices[coords[11]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }
        */

    }
}
