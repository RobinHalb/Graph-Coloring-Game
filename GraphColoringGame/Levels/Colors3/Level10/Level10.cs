using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level10 : Level
    {
        public Level10() : base()
        {
            level = 10;
            winning = Player.Bob;
        }

        protected override Graph newGraph() => new Level10Graph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new Level10Explanation(graph).GetExplanation();

    }
}
