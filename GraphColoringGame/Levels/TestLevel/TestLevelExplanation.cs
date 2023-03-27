using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GraphColoringGame.Levels
{
    public class TestLevelExplanation : LevelExplanation
        //TODO: MAKE EXPLANATION PAGE
    {
        private Coord[] coords;

        public TestLevelExplanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
                new Coord(0, 1),
                new Coord(1, 0),
                new Coord(2, 0)
            };
        }

        public List<ExplanationStep> GetExplanation() => new List<ExplanationStep>()
        {
            step1(),
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
