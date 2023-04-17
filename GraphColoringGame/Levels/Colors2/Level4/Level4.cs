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
    public class Level4a : Level
    {
        public Level4a() : base() 
        {
            level = 4;
            winning = Player.Bob;
        }

        protected override Graph newGraph() => new Level4aGraph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new Level4aExplanation(graph).GetExplanation();
    }
}
