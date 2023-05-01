using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
//using System.Windows.Media;

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
            step6(),
            step7(),
            step8(),
            step9(),
            step10(),
        };

        public ExplanationStep step1()
        {
            var text = "You play as Alice. \n\nAlice's goal in the graph coloring game is to color the entire graph, so that no neighboring vertices have the same color. \n\nYour opponent, Bob, will try to make this impossible.";
            var vertices = newVertices();

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "In this level, you play using only two colors - this is called the 2-coloring game. \n\nWhen playing, you can choose between colors in the bottom left corner.";
            var vertices = newVertices();

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3()
        {
            var text = "In any graph coloring game there exists a winning strategy, which, if followed, ensures victory. \n\nEither Bob has a sure way to make the graph uncolorable, or Alice has a sure way to prevent Bob from doing so. \n\nIn this level, Alice has a winning strategy.";
            var vertices = newVertices();

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step4()
        {
            var text = "Alice's winning strategy for this graph is to color the middle vertex, as shown with green outline.";
            var vertices = newVertices();

            vertices[coords[1]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step5()
        {
            var text = "This vertex has two legal colors: red and blue, and two uncolored neighbors, as shown with purple outlines. \n\nA vertex like the middle one, which has at least as many uncolored neighbors as available colors is called a dangerous vertex.";
            var vertices = newVertices();

            vertices[coords[0]].outline = purple;
            vertices[coords[1]].outline = green;
            vertices[coords[2]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step6()
        {
            var text = "If Alice colors the dangerous vertex, the other two vertices will both have only one legal color left.";
            var vertices = newVertices();

            vertices[coords[1]].color = Color.Red;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step7()
        {
            var text = "Bob will be forced to color one of them with the remaining color. \n\nAlice can then color the last vertex to win.";
            var vertices = newVertices();

            vertices[coords[1]].color = Color.Red;
            vertices[coords[0]].color = Color.Blue;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step8()
        {
            var text = "Having a winning strategy however, only works as long as the strategy is followed.";
            var vertices = newVertices();

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step9()
        {
            var text = "If Alice instead colors one of the outer vertices, the middle vertex remains dangerous, as it will have one available color and one uncolored neighbor.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step10()
        {
            var text = "Once a dangerous vertex has only one available color, Bob can win by coloring any neighbor with that color. \n\nBecause the middle vertex no longer has any legal colors, the graph cannot be fully colored, and Bob has won.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[2]].color = Color.Blue;
            vertices[coords[1]].outline = black;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        /*
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

        public ExplanationStep step3()
        {
            var text = "If Alice colors one of the outer vertices red, the middle vertex remains dangerous, as it will have one available color: blue, and one uncolored neighbor.";
            var vertices = newVertices();

            vertices[coords[0]].color = Color.Red;
            vertices[coords[1]].outline = green;
            vertices[coords[2]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step4()
        {
            var text = "Once a dangerous vertex has only one available color, Bob can win by coloring any neighbor with that color.";
            var vertices = newVertices();
            
            vertices[coords[0]].color = Color.Red;
            vertices[coords[1]].outline = green;
            vertices[coords[2]].color = Color.Blue;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step5()
        {
            var text = "If Alice instead colors the dangerous vertex red, Bob will be forced to color either of the two outer vertices blue, after which Alice can win.";
            var vertices = newVertices();
            
            vertices[coords[0]].outline = purple;
            vertices[coords[1]].color = Color.Red;
            vertices[coords[2]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
        */
    }
}
