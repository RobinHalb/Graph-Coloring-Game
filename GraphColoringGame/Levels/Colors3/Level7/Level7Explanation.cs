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
     *      0   0
     *      |   |
     *  0 - 0 - 0 - 0
     *      |   |
     *      0   0
     * */
    public class Level7Explanation : LevelExplanation
    {
        private Coord[] coords;
        public Level7Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
            new Coord(1,0), // coords[0]
            new Coord(2, 0), // 1
            new Coord(0, 1), //2
            new Coord(1, 1),//3
            new Coord(2, 1),//4
            new Coord(3, 1),//5
            new Coord(1,2),
            new Coord(2,2)
            };
        }

        public List<ExplanationStep> GetExplanation() => new List<ExplanationStep>()
        {
            step1(),
            step2(),
            step3(),
            step4(),
            //step5(),
            step6(),
            //step7(),
            step8(),
            step9(),
            //step10(),
        };

        public ExplanationStep step1()
        {
            // In this graph Bob has a winning strategy. If Alice colors one of the two dangerous vertcies (marked green) with an avaiable color, then Bob has a winning move.
            var text = "In this subgraph with 8 vertices Bob has a winning strategy. If Alice colors one of the two dangerous vertcies (shown green) with an available color, then Bob has a winning move.";
            //var text = "In this scenerio Bob have a winning strategy. If Alice colors one of the two green highlighted vertices with an available color (not Red), then Bob has a winnning move. Notice that these are two dangerous vertices";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[5]].color = Color.Red;
            vertices[coords[3]].outline = green;
            vertices[coords[4]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            // If Alice colors the first vertex, Bob can color one of the nightbors to the other vertex (marked purple) with a thrid color to make the dangerous vertex uncolorable.
            var text = "If Alice colors the first vertex, Bob can color one of the neighbors to the other vertex (shown purple) with a third color to make the dangerous vertex (shown green) uncolorable.";
            //var text = "If Alice chooses the first vertex, then Bob can color one of the neighbors to the other dangerous vertex with the third color, green, to make the second dangerous vertex uncolorable."; 
            var vertices = newVertices();


            vertices[coords[2]].color = Color.Red;
            vertices[coords[5]].color = Color.Red;
            vertices[coords[3]].color = Color.Blue;
            vertices[coords[1]].outline = purple;
            vertices[coords[7]].outline = purple;
            vertices[coords[4]].outline = green;
            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3()
        {
            // If Alice chooses the second vertex instead, Bob can color one of the neghbors to the first dangerous vertex with a third color to make it uncolorable.
            var text = "If Alice colors the second vertex instead, Bob can color one of the neighbors to the first dangerous vertex (shown purple) with a third color to make it uncolorable.";
            //var text = "The same thing happens if Alice colors the other dangerous vertex"; // CHECK FOR ERROR
            var vertices = newVertices();


            vertices[coords[2]].color = Color.Red;
            vertices[coords[5]].color = Color.Red;
            vertices[coords[4]].outline = green;
            vertices[coords[0]].outline = purple;
            vertices[coords[6]].outline = purple;
            

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);


        }

        public ExplanationStep step4() 
        {
            // If Alice colors this vertex (marked green) with a different color than Red, then the dangerous vertex (marked purple )
            var text = "If Alice colors this vertex (shown green) with a different color than Red, then the dangerous vertex (shown purple) only has one legal color avaliable. Bob can color one of its neighbors in the the remaining color to win.";
            //var text = "If Alice chooses to color this vertex instead, say Blue."; // CHECK FOR ERROR
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[5]].color = Color.Red;
            vertices[coords[7]].outline = green;
            vertices[coords[4]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }
        /*
        public ExplanationStep step5()
        {
            var text = "Now Blue is not a legal color for this dangerous vertex (green outlined), then Bob can now color its neighbor, the other dangerous vertex, green to make the first dangerous vertex uncolorable. "; // CHECK FOR ERROR
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[7]].color = Color.Blue;
            vertices[coords[2]].outline = green;
            vertices[coords[1]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);


        }
        */
        public ExplanationStep step6() 
        {
            var text = "If Alice colors the vertex Red instead, Bob can color this vertex (shown purple) a different color to reach two winning moves.";
            //var text = "If Alice chooses to color the vertex Red instead."; // CHECK FOR ERROR
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[5]].color = Color.Red;
            vertices[coords[7]].color = Color.Red;
            vertices[coords[0]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }
        /*
        public ExplanationStep step7() 
        {
            var text = "Bob can color this vertex green. Now he has two winning moves.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }
        */
        public ExplanationStep step8()
        {
            var text = "His two winning moves are to color either of the outlined vertices a third color on his next turn.";
            //var text = "His two winning moves are to color either of the outlined vertices blue.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[5]].color = Color.Red;
            vertices[coords[7]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[6]].outline = purple;
            vertices[coords[4]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }

        public ExplanationStep step9() 
        {
            var text = "If Alice responds by coloring this vertex (shown green) the third color, Bob can win by coloring the neighbor of the other dangerous vertex (shown purple) with an avaliable to make the dangerous vertex uncolorable.";
            //var text = "If Alice responds by coloring this vertex blue..";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[5]].color = Color.Red;
            vertices[coords[7]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;
            vertices[coords[3]].outline = green;
            vertices[coords[1]].outline = purple;
            
            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }
        /*
        public ExplanationStep step10()
        {
            var text = "then Bob can still win by coloring this vertex green to win as the dangerous vertex below it is now uncolorable.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].color = Color.Green;
            vertices[coords[1]].color = Color.Blue;
            vertices[coords[5]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }
        */

    }
}
