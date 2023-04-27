using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level6 : Level
    {
        public Level6() : base()
        {
            level = 6;
            winning = Player.Alice;
        }

        protected override Graph newGraph() => new Level6Graph().coloredGraph();
        protected override List<ExplanationStep> newExplanation() => new Level6Explanation(graph).GetExplanation();
    }
}
