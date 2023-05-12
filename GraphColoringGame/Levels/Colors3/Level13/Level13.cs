using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level13 : Level
    {
        /*
         * Graph with 14 vertices showing Alice cannot win on trees with more than 13 vertices.
         * 
         *      0   0   0   0   0
         *      |   |   |   |   |
         *      0 - 0 - 0 - 0 - 0 - 0
         *          |   |   |   |
         *          0   0   0   0
         */
        public Level13() : base()
        {
            level = 13;
            winning = Player.Bob;
        }

        protected override Graph newGraph() => new Level13Graph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new Level13Explanation(graph).GetExplanation();

    }
}
