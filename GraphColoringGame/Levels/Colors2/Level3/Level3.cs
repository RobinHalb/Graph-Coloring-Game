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
    public class Level3 : Level
    {
        /*
         * Graph is a P_3+ where Alice can win and lose depending on whether she is following her winning strategy.
         * 
         *      0
         *      |
         *  0 - 0 - 0 
         */
        public Level3() : base() 
        {
            level = 3;
            winning = Player.Alice;
        }

        protected override Graph newGraph() => new Level3Graph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new Level3Explanation(graph).GetExplanation();
    }
}
