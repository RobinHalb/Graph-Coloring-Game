using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public abstract class Level
    {
        public Graph graph { get; protected set; }
        public List<ExplanationStep> explanation { get; protected set; }

        public int level { get; protected set; }

        public Level()
        {
            graph = newGraph();
            explanation = newExplanation();
        }

        public void reset() => graph = newGraph();

        protected abstract Graph newGraph();
        protected abstract List<ExplanationStep> newExplanation();
    }
}
