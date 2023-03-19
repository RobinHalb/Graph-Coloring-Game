using GraphColoringGame.Explanation;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public interface ILevel
    {
        public Graph graph { get; }
        public List<ExplanationStep> explanation { get; }
    }
}
