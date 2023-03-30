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
    public class Level5 : Level
    {

        public Level5() : base() 
        {
            level = 5;
        }

        protected override Graph newGraph() => new Level5Graph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new Level5Explanation(graph).GetExplanation();
    }
}
