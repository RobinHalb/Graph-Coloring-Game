using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels.TestLevel2Content
{
    public class TestLevel2 : ILevel
    {
        public Graph graph { get; private set; }
        public List<ExplanationStep> explanation { get; private set; }

        public TestLevel2() 
        {
            graph = new Test2LevelGraph().createGraph();
            explanation = new TestLevel2Explanation(graph).GetExplanation();
        }
    }
}
