using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level7 : Level
    {
        public Level7() : base()
        {
            level = 7;
            winning = Player.Alice;
        }

        protected override Graph newGraph() => new Level7Graph().coloredGraph();
        protected override List<ExplanationStep> newExplanation() => new Level7Explanation(graph).GetExplanation();
    }
}
