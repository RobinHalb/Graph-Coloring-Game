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
    public class TestLevel2 : Level
    {

        public TestLevel2() : base() {}

        protected override Graph newGraph() => new Test2LevelGraph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new TestLevel2Explanation(graph).GetExplanation();
    }
}
