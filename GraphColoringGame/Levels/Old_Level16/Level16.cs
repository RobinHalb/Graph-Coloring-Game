using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level16a : Level
    {
        public Level16a() : base()
        {
            level = 16;
            winning = Player.Alice;
        }

        protected override Graph newGraph() => new Level16aGraph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new Level16aExplanation(graph).GetExplanation();
    }
}
