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
        public Level3() : base() 
        {
            level = 3;
            winning = Player.Bob;
        }

        protected override Graph newGraph() => new Level3Graph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new Level3Explanation(graph).GetExplanation();
    }
}
