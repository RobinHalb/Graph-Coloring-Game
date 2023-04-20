using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level12 : Level
    {
        public Level12() : base()
        {
            level = 12;
            winning = Player.Alice;
        }

        protected override Graph newGraph() => new Level12Graph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new Level12Explanation(graph).GetExplanation();
    }
}
