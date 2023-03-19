using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Explanation
{
    public class ExplanationStep
    {
        public string text { get; private set; }
        public Dictionary<Coord, ExplanationVertex> vertices { get; private set; }

        public ExplanationStep(string text, Dictionary<Coord,ExplanationVertex> vertices)
        {
            this.text = text;
            this.vertices = vertices;
        }
    }
}
