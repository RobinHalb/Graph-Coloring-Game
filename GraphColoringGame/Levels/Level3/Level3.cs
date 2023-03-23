using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level3 : ILevel
    {
        public Graph graph { get; private set; }
        public List<ExplanationStep> explanation { get; private set; }

        public Level3()
        {
            graph = new Level3Graph().createGraph();
        }
    }
}
