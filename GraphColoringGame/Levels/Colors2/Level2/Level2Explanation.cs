using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System.Collections.Generic;

namespace GraphColoringGame.Levels
{
    /*
     * Graph is a P_4. It shows Alice cannot win with only two colors on paths longer than 3.
     * 
     * 0 - 0 - 0 - 0
     */
    public class Level2Explanation : LevelExplanation
    {
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
                step4(),
        };

        public ExplanationStep step1()
        {
            var text = "In this level where the graph has four vertices in a line, Bob is the one to have a winning strategy. \n\nNotice that this graph contains two dangerous vertices (shown green).";
            var vertices = newVertices();
            vertices[coords[1]].outline = green;
            vertices[coords[2]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "No matter which vertex Alice colors, there will be at least one dangerous vertex remaining. \n\nThis dangerous vertex has only one legal color left.";
            var vertices = newVertices();

            vertices[coords[2]].color = Color.Red;
            vertices[coords[1]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3()
        {
            var text = "If both of the dangerous vertices are left, exactly one of them (shown purple) has only one legal color left.";
            var vertices = newVertices();

            vertices[coords[3]].color = Color.Red;
            vertices[coords[1]].outline = green;
            vertices[coords[2]].outline = purple;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step4()
        {
            var text = "Since the graph now contains a dangerous vertex with only one legal color left, Bob can win by coloring a neighbor of the vertex with the remaining color.";
            var vertices = newVertices();

            vertices[coords[1]].color = Color.Blue;
            vertices[coords[3]].color = Color.Red;
            vertices[coords[2]].outline = black;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
