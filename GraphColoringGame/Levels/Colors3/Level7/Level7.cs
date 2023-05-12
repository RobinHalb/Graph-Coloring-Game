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
        /*
         *  Partial color graph showing Alice can win on a subgraph with 7 vertices when the dangerous vertices have a colored neighbor.
         *  The dangerous vertices are neighbors.
         *  a: Red vetex
         *  b: Blue vertex
         *  
         *      0   0
         *      |   |
         *  a - 0 - 0
         *      |   |
         *      0   b
         */

        public Level7() : base()
        {
            level = 7;
            winning = Player.Alice;
        }

        protected override Graph newGraph() => new Level7Graph().coloredGraph();
        protected override List<ExplanationStep> newExplanation() => new Level7Explanation(graph).GetExplanation();
    }
}
