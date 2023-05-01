using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GraphColoringGame.Levels
{
    /*
     *      0   0   0   0   0
     *      |   |   |   |   |
     *      0 - 0 - 0 - 0 - 0 
     *      |           |   |
     *      0           0   0
     */
    public class Level14Explanation : LevelExplanation
    {
        private Coord[] coords;

        public Level14Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
                new Coord(0, 0), // 0
                new Coord(1, 0), // 1
                new Coord(2, 0), // 2
                new Coord(3, 0), //3
                new Coord(4, 0),//4
                new Coord(0, 1),//5
                new Coord(1, 1),//6
                new Coord(2, 1),//7
                new Coord(3, 1),//8
                new Coord(4, 1), // 9
                new Coord(0, 2),// 10
                new Coord(3, 2), //11
                new Coord(4, 2), //12
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
            step11(),
            step12(),
            step13(),
            step14(),
            step15(),
            step16(),
        };


        public ExplanationStep step1()
        {
            var text = "Alice can win the 3-coloring game on any tree like this one, which contains 13 or less vertices. \n\nA tree on 13 or less vertices will always contain some vertex (shown green), which splits the graph into trunks of at most seven vertices.";
            var vertices = newVertices();

            vertices[coords[7]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "Alice must color this vertex, creating three trunks. \n\nIf Alice has a winning strategy in every trunk, then she has a winning strategy for the graph.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3()
        {
            var text = "Suppose Bob plays in this trunk. \n\nAs this trunk contains one or more dangerous vertices (shown green), Alice should play her next move here as well.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].color = Color.Blue;
            vertices[coords[8]].outline = green;
            vertices[coords[9]].outline = green;

            vertices[coords[0]].opacity = greyout;
            vertices[coords[1]].opacity = greyout;
            vertices[coords[2]].opacity = greyout;
            vertices[coords[5]].opacity = greyout;
            vertices[coords[6]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step4()
        {
            var text = "Because the graph has 13 or less vertices, she has made sure that the trunk can have at most seven vertices, and because Bob has only colored one vertex, there are no more than two colored leaves. \n\nLevels 5-8 show how Alice can win the 3-coloring game on such a trunk.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].color = Color.Blue;

            vertices[coords[0]].opacity = greyout;
            vertices[coords[1]].opacity = greyout;
            vertices[coords[2]].opacity = greyout;
            vertices[coords[5]].opacity = greyout;
            vertices[coords[6]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step5()
        {
            var text = "If Bob has colored this vertex, then the trunk matches the case from level 7, where two dangerous vertices are adjacent and each has one colored neighbor. \n\nThe trunk can be won by Alice as described in the level.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].color = Color.Blue;

            vertices[coords[0]].opacity = greyout;
            vertices[coords[1]].opacity = greyout;
            vertices[coords[2]].opacity = greyout;
            vertices[coords[5]].opacity = greyout;
            vertices[coords[6]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
        
        public ExplanationStep step6()
        {
            var text = "Alice will then play in the same trunk according to her strategy.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].color = Color.Blue;
            vertices[coords[12]].color = Color.Blue;

            vertices[coords[0]].opacity = greyout;
            vertices[coords[1]].opacity = greyout;
            vertices[coords[2]].opacity = greyout;
            vertices[coords[5]].opacity = greyout;
            vertices[coords[6]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step7()
        {
            var text = "On his next turn, Bob may decide to play in a different trunk.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].color = Color.Blue;
            vertices[coords[12]].color = Color.Blue;
            vertices[coords[1]].color = Color.Blue;

            vertices[coords[2]].opacity = greyout;
            vertices[coords[3]].opacity = greyout;
            vertices[coords[4]].opacity = greyout;
            vertices[coords[8]].opacity = greyout;
            vertices[coords[9]].opacity = greyout;
            vertices[coords[11]].opacity = greyout;
            vertices[coords[12]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step8()
        { 
            var text = "This trunk also has less than seven vertices and two colored leaves. \n\nHere, Alice may win by the strategies presented in level 5 and 6. \n\nThis trunk also contains one or more dangerous vertices (shown green).";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].color = Color.Blue;
            vertices[coords[12]].color = Color.Blue;
            vertices[coords[1]].color = Color.Blue;
            vertices[coords[5]].outline = green;
            vertices[coords[6]].outline = green;

            vertices[coords[2]].opacity = greyout;
            vertices[coords[3]].opacity = greyout;
            vertices[coords[4]].opacity = greyout;
            vertices[coords[8]].opacity = greyout;
            vertices[coords[9]].opacity = greyout;
            vertices[coords[11]].opacity = greyout;
            vertices[coords[12]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step9()
        {
            var text = "Because the trunk contains a dangerous vertex, Alice should play her next move in this trunk as well.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].color = Color.Blue;
            vertices[coords[12]].color = Color.Blue;
            vertices[coords[1]].color = Color.Blue;
            vertices[coords[6]].color = Color.Green;

            vertices[coords[2]].opacity = greyout;
            vertices[coords[3]].opacity = greyout;
            vertices[coords[4]].opacity = greyout;
            vertices[coords[8]].opacity = greyout;
            vertices[coords[9]].opacity = greyout;
            vertices[coords[11]].opacity = greyout;
            vertices[coords[12]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step10()
        {
            var text = "If Bob returns to a trunk which has previously been played in, the strategy resumes where it left off.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].color = Color.Blue;
            vertices[coords[12]].color = Color.Blue;
            vertices[coords[1]].color = Color.Blue;
            vertices[coords[6]].color = Color.Green;

            vertices[coords[0]].opacity = greyout;
            vertices[coords[1]].opacity = greyout;
            vertices[coords[2]].opacity = greyout;
            vertices[coords[5]].opacity = greyout;
            vertices[coords[6]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step11()
        {
            var text = "After Bob's turn, the trunk may still contain a dangerous vertex (shown green).";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].color = Color.Blue;
            vertices[coords[12]].color = Color.Blue;
            vertices[coords[1]].color = Color.Blue;
            vertices[coords[6]].color = Color.Green;
            vertices[coords[3]].color = Color.Blue;
            vertices[coords[8]].outline = green;

            vertices[coords[0]].opacity = greyout;
            vertices[coords[1]].opacity = greyout;
            vertices[coords[2]].opacity = greyout;
            vertices[coords[5]].opacity = greyout;
            vertices[coords[6]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step12()
        {
            var text = "Alice plays in the same trunk, continuing the strategy. \n\nAfter her turn, the trunk has no dangerous vertices left and is therefore no longer a threat.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].color = Color.Blue;
            vertices[coords[12]].color = Color.Blue;
            vertices[coords[1]].color = Color.Blue;
            vertices[coords[6]].color = Color.Green;
            vertices[coords[3]].color = Color.Blue;
            vertices[coords[8]].color = Color.Green;

            vertices[coords[0]].opacity = greyout;
            vertices[coords[1]].opacity = greyout;
            vertices[coords[2]].opacity = greyout;
            vertices[coords[5]].opacity = greyout;
            vertices[coords[6]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step13()
        {
            var text = "If Bob plays in a trunk which has no dangerous vertices, Alice does not need to play in the same trunk.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].color = Color.Blue;
            vertices[coords[12]].color = Color.Blue;
            vertices[coords[1]].color = Color.Blue;
            vertices[coords[6]].color = Color.Green;
            vertices[coords[3]].color = Color.Blue;
            vertices[coords[8]].color = Color.Green;
            vertices[coords[11]].color = Color.Red;

            vertices[coords[0]].opacity = greyout;
            vertices[coords[1]].opacity = greyout;
            vertices[coords[2]].opacity = greyout;
            vertices[coords[5]].opacity = greyout;
            vertices[coords[6]].opacity = greyout;
            vertices[coords[10]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step14()
        {
            var text = "Instead, she may move to a trunk which does contain dangerous vertices (shown green).";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].color = Color.Blue;
            vertices[coords[12]].color = Color.Blue;
            vertices[coords[1]].color = Color.Blue;
            vertices[coords[6]].color = Color.Green;
            vertices[coords[3]].color = Color.Blue;
            vertices[coords[8]].color = Color.Green;
            vertices[coords[11]].color = Color.Red;
            vertices[coords[5]].outline = green;

            vertices[coords[2]].opacity = greyout;
            vertices[coords[3]].opacity = greyout;
            vertices[coords[4]].opacity = greyout;
            vertices[coords[8]].opacity = greyout;
            vertices[coords[9]].opacity = greyout;
            vertices[coords[11]].opacity = greyout;
            vertices[coords[12]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step15()
        {
            var text = "Here, she can continue her strategy as though Bob has chosen to pass his turn.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].color = Color.Blue;
            vertices[coords[12]].color = Color.Blue;
            vertices[coords[1]].color = Color.Blue;
            vertices[coords[6]].color = Color.Green;
            vertices[coords[3]].color = Color.Blue;
            vertices[coords[8]].color = Color.Green;
            vertices[coords[11]].color = Color.Red;
            vertices[coords[5]].color = Color.Red;

            vertices[coords[2]].opacity = greyout;
            vertices[coords[3]].opacity = greyout;
            vertices[coords[4]].opacity = greyout;
            vertices[coords[8]].opacity = greyout;
            vertices[coords[9]].opacity = greyout;
            vertices[coords[11]].opacity = greyout;
            vertices[coords[12]].opacity = greyout;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step16()
        {
            var text = "When Alice has a winning strategy in the 3-coloring game, she must always play in the same trunk as Bob, when he plays in a dangerous trunk. \n\nThis way, Alice ensures that he never gets two turns in a row in the trunk, and she can perform her strategy in every trunk.";
            var vertices = newVertices();

            vertices[coords[7]].color = Color.Red;
            vertices[coords[4]].color = Color.Blue;
            vertices[coords[12]].color = Color.Blue;
            vertices[coords[1]].color = Color.Blue;
            vertices[coords[6]].color = Color.Green;
            vertices[coords[3]].color = Color.Blue;
            vertices[coords[8]].color = Color.Green;
            vertices[coords[11]].color = Color.Red;
            vertices[coords[5]].color = Color.Red;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
