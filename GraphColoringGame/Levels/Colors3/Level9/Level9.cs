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
    

