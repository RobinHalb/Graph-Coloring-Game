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
    public class Level4 : Level
    {
       /*
        * Graph is a P_4+, Alice cannot win with only 2 colors.
        * 
        *          0
        *          |
        *  0 - 0 - 0 - 0 
        */
        public Level4() : base() 
        {
            level = 4;
            winning = Player.Bob;
        }

        protected override Graph newGraph() => new Level4Graph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new Level4Explanation(graph).GetExplanation();
    }
}
