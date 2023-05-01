using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level8 : Level
    {
        public Level8() : base()
        {
            level = 8;
            winning = Player.Alice;
        }

        protected override Graph newGraph() => new Level8Graph().coloredGraph();
        protected override List<ExplanationStep> newExplanation() => new Level8Explanation(graph).GetExplanation();
    }
}
