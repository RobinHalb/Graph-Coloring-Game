using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GraphColoringGame.Levels.Level1Content
{
    /*
     *  0 - 0 - 0 
     */
    class Level1Explanation : LevelExplanation
    {
        private Coord[] coords;

        public Level1Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
                new Coord(0, 0),
                new Coord(1, 0),
                new Coord(2, 0)
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
            var text = "To ensure victory for this graph, Alice must color the middle vertex, as shown with green outline.";
            var vertices = newVertices();

            vertices[coords[1]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "This vertex has two legal colors: red and blue, and two uncolored neighbors, as shown with purple outlines." +
                "\n\nA vertex which has equally as many or more uncolored neighbors as available colors is called a dangerous vertex.";
            var vertices = newVertices();

            vertices[coords[0]].outline = purple;
            vertices[coords[1]].outline = green;
            vertices[coords[2]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
        /*
        public ExplanationStep step3()
        {
            var text = "Bob can only win if the graph contains at least one dangerous vertex, as he must be able to create a neighbour of each color to make a vertex uncolorable.";
            var vertices = newVertices();
            // Set colors
            vertices[coords[1]].outline = green;
            vertices[coords[0]].color = Graphs.Color.Red;
            vertices[coords[2]].color = Graphs.Color.Blue;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
        */
        public ExplanationStep step3()
        {
            var text = "If Alice colors one of the outer vertices red, the middle vertex remains dangerous, as it will have one available color: blue, and one uncolored neighbor.";
            var vertices = newVertices();

            vertices[coords[0]].color = Graphs.Color.Red;
            vertices[coords[1]].outline = green;
            vertices[coords[2]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step4()
        {
            var text = "Once a dangerous vertex has only one available color, Bob can win by coloring any neighbor with that color.";
            var vertices = newVertices();
            
            vertices[coords[0]].color = Graphs.Color.Red;
            vertices[coords[1]].outline = green;
            vertices[coords[2]].color = Graphs.Color.Blue;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step5()
        {
            var text = "If Alice instead colors the dangerous vertex red, Bob will be forced to color either of the two outer vertices blue, after which Alice can win.";
            var vertices = newVertices();
            
            vertices[coords[0]].outline = purple;
            vertices[coords[1]].color = Graphs.Color.Red;
            vertices[coords[2]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
