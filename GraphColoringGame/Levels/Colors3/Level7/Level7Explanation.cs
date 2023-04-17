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
            new Coord(0,1), // coords[0]
            new Coord(1, 1), // 1
            new Coord(2, 1), //2
            new Coord(3, 1),//3
            new Coord(1, 0),//4
            new Coord(2, 0),//5
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
            step5(),
            step6(),
            step7(),
            step8(),
            step9(),
            step10(),
        };

        public ExplanationStep step1()
        {
            var text = "In this scenerio Bob have a winning strategy. If Alice colors one of the two green highlighted vertices with an available color (not Red), then Bob has a winnning move. Notice that these are two dangerous vertices";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[1]].outline = green;
            vertices[coords[2]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "If Alice chooses the first vertex, then Bob can color one of the neighbors to the other dangerous vertex with the third color, green, to make the second dangerous vertex uncolorable."; 
            var vertices = newVertices();


            vertices[coords[0]].color = Color.Red;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[1]].color = Color.Blue;
            vertices[coords[5]].outline = purple;
            vertices[coords[7]].outline = purple;
            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3()
        {
            var text = "The same thing happens if Alice colors the other dangerous vertex"; // CHECK FOR ERROR
            var vertices = newVertices();


            vertices[coords[0]].color = Color.Red;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[2]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);


        }

        public ExplanationStep step4() 
        {
            var text = "If Alice chooses to color this vertex instead, say Blue."; // CHECK FOR ERROR
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[7]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }
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

        public ExplanationStep step6() 
        {
            var text = "If Alice chooses to color the vertex Red instead."; // CHECK FOR ERROR
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[7]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }

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
        public ExplanationStep step8()
        {
            var text = "His two winning moves are to color either of the outlined vertices blue.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].color = Color.Green;
            vertices[coords[6]].outline = purple;
            vertices[coords[2]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }

        public ExplanationStep step9() 
        {
            var text = "If Alice responds by coloring this vertex blue..";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].color = Color.Green;
            vertices[coords[1]].outline = green;
            
            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }

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

    }
}
