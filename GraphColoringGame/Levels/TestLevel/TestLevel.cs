using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using GraphColoringGame.Levels.Level1Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels.TestLevelContent
{
    public class TestLevel : ILevel
    {
        public Graph graph { get; private set; }
        public List<ExplanationStep> explanation { get; private set; }

        public TestLevel()
        {
            graph = new TestLevelGraph().createGraph();
            explanation = new TestLevelExplanation(graph).GetExplanation();
        }
    }
}
