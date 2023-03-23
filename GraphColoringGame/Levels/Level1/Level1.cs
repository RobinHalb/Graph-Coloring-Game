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
    public class Level1 : ILevel
    {
        public Graph graph { get; private set; }
        public List<ExplanationStep> explanation { get; private set; }

        public Level1()
        {
            graph = new Level1Graph().createGraph();
            explanation = new Level1Explanation(graph).GetExplanation();
        }
    }
}
