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
     * Graph with 11 vertices, demonstrating Alice's winning strategy, and how Bob can create a subgraph similar to Level 9 if Alice does not follow her winnning strategy.
     * 
     *      0   0   0
     *      |   |   |
     *  0 - 0 - 0 - 0 - 0
     *      |   |   |
     *      0   0   0
     */
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
