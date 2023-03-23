using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels.TestLevel2Content
{
    class TestLevel2Explanation : LevelExplanation
    {
        //TODO: MAKE EXPLANATION PAGE
        private Coord[] coords;

        public TestLevel2Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
                new Coord(0, 1),
            };
        }

        public List<ExplanationStep> GetExplanation() => new List<ExplanationStep>()
        {
                step1()
        };

        public ExplanationStep step1()
        {
            var text = "";
            var vertices = newVertices();

            vertices[coords[1]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
