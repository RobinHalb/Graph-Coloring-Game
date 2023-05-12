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
     * Graph showing why Bob can win when a tree has more than 13 vertices. Graph has 14.
     * 
     *      0   0   0   0
     *      |   |   |   |
     *  0 - 0 - 0 - 0 - 0 - 0
     *      |   |   |   |
     *      0   0   0   0
     */
    public class Level12 : Level
    {
        public Level12() : base()
        {
            level = 12;
            winning = Player.Bob;
        }

        protected override Graph newGraph() => new Level12Graph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new Level12Explanation(graph).GetExplanation();


    }
}
