using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using GraphColoringGame.Levels.Level1Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class TestLevel : Level
    {
        public TestLevel(): base() {}

        protected override Graph newGraph() => new TestLevelGraph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new TestLevelExplanation(graph).GetExplanation();
    }
}
