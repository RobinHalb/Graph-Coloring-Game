using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level6 : Level
    {
        /*
         * Partial colored graph with 7 vertices showing Alice can win when one of two dangerous vertices has two colored neighbors.
         * a: Red colored vertex
         * b: Blue colored vertex
         * 
         *      0   0
         *      |   |
         *  a - 0 - 0
         *      |   |
         *      b   0
         */
        public Level6() : base()
        {
            level = 6;
            winning = Player.Alice;
        }

        protected override Graph newGraph() => new Level6Graph().coloredGraph();
        protected override List<ExplanationStep> newExplanation() => new Level6Explanation(graph).GetExplanation();
    }
}
