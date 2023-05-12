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
    /*
     * Graph with a P_3. Alice can both win and lose depending on whether she is following her winning strategy
     *  0 - 0 - 0 
     */
    public class Level1 : Level
    {
        public Level1() : base() 
        { 
            level = 1;
            winning = Player.Alice;
        }

        protected override Graph newGraph() => new Level1Graph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new Level1Explanation(graph).GetExplanation();
    }
}
