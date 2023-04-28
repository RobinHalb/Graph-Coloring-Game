using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level15 : Level
    {
        public Level15() : base()
        {
            level = 15;
            winning = Player.Alice;
        }

        protected override Graph newGraph() => new Level15Graph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new Level15Explanation(graph).GetExplanation();
    }
}
