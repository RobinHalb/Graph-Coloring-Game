using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level14 : Level
    {
        public Level14() : base()
        {
            level = 14;
            winning = Player.Alice;
        }

        protected override Graph newGraph() => new Level14Graph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new Level14Explanation(graph).GetExplanation();

    }
}
