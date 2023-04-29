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
    public class Level11 : Level
    {
        public Level11() : base() 
        {
            level = 11;
            winning = Player.Alice;
        }

        protected override Graph newGraph() => new Level11Graph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new Level11Explanation(graph).GetExplanation();
    }
}
