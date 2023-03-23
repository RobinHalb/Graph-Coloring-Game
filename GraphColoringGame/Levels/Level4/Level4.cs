using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level4 : ILevel
    {
        public Graph graph { get; private set; }
        public List<ExplanationStep> explanation { get; private set; }

        public Level4() 
        {
            graph = new Level4Graph().createGraph();
            explanation = new Level4Explanation(graph).GetExplanation();
        }
    }
}
