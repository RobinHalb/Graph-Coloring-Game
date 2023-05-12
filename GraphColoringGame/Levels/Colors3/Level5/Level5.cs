using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level5 : Level
    {
        /*
         * Partial colored graph with 7 vertices showing Alice can win with 3 colors when one of two dangerous vertices has one colored neighbor.
         * a: Red colored vertex
         * 
         *      0   0
         *      |   |
         *  0 - 0 - 0
         *      |   |
         *      a   0
         */
        public Level5() : base()
        {
            level = 5;
            winning = Player.Alice;
        }

        protected override Graph newGraph() => new Level5Graph().coloredGraph();
        protected override List<ExplanationStep> newExplanation() => new Level5Explanation(graph).GetExplanation();
    }
}
