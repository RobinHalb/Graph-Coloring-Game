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
    public class Level1 : Level
    {
        public Level1() : base() { }

        protected override Graph newGraph() => new Level1Graph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new Level1Explanation(graph).GetExplanation();
    }
}
