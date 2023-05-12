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
     * This level uses a partial colored graph, where Alice cannot win with 3 colors.
     * a: Red colored vertex
     * 
     *      0   0
     *      |   |
     *  a - 0 - 0 - a
     *      |   |
     *      0   0
     */
    public class Level9 : Level
    {
        public Level9() : base() 
        {
            level = 9;
            winning = Player.Bob;
        }

        protected override Graph newGraph() => new Level9Graph().coloredGraph();
        protected override List<ExplanationStep> newExplanation() => new Level9Explanation(graph).GetExplanation();
    }
}
    

