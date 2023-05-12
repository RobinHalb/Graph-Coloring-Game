using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    /* 
     * Partial color graph showing Alice can win on a subgraph with 7 vertices when the dangerous vertices have a colored neighbor each.
     * The dangerous vertices are not neighbors.
     * a: Red colored vertex
     * b: Blue colored vertex
     *      
     *      0       0
     *      |       |
     *  a - 0 - 0 - 0 - b
     */
    public class Level8 : Level
    {
        public Level8() : base()
        {
            level = 8;
            winning = Player.Alice;
        }

        protected override Graph newGraph() => new Level8Graph().coloredGraph();
        protected override List<ExplanationStep> newExplanation() => new Level8Explanation(graph).GetExplanation();
    }
}
