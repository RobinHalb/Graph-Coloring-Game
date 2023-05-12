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
    public class Level10 : Level
    {
        /*
         * Partial colored graph with 11 vertices. Demonstrates that Alice may not win when there is a supgraph similar to Level 9 in the graph.
         * a: Red colored vertex
         * b: Blue colored vertex
         * 
         *      0   0       a
         *      |   |       |
         *  a - 0 - 0 - b - 0
         *      |   |       |
         *      0   0       0
         */
        public Level10() : base() 
        {
            level = 10;
            winning = Player.Bob;
        }

        protected override Graph newGraph() => new Level10Graph().coloredGraph();
        protected override List<ExplanationStep> newExplanation() => new Level10Explanation(graph).GetExplanation();
    }
}
    

