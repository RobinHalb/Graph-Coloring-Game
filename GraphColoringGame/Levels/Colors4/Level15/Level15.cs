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
     * Partial colored graph showing Alice's winning strategy with 4 colors using trunks.
     * a: Red colored vertex
     * b: Blue colored vertex
     * c: Yellow colored vertex
     * 
     *              0
     *              |
     *  a - 0 - 0 - 0 - 0 - b
     *          |   |
     *      0 - 0   0
     *        /   \
     *      0       c
     */
    public class Level15 : Level
        {
            public Level15() : base()
            {
                level = 15;
                winning = Player.Alice;
            }

            protected override Graph newGraph() => new Level15Graph().coloredGraph();
            protected override List<ExplanationStep> newExplanation() => new Level15Explanation(graph).GetExplanation();
        }
}
