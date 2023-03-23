using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GraphColoringGame.Explanations
{
    public class ExplanationStep
    {
        public string text { get; private set; }
        public Dictionary<Coord, ExplanationVertex> vertices { get; private set; }
        public readonly List<Graphs.Color> colors;
        public readonly int xMin, yMin;
        public readonly int width, height;

        public ExplanationStep(string text, Dictionary<Coord,ExplanationVertex> vertices, List<Graphs.Color> colors, int width, int height, int xMin, int yMin)
        {
            this.text = text;
            this.vertices = vertices;
            this.colors = colors;
            this.width = width;
            this.height = height;  
            this.xMin = xMin;
            this.yMin = yMin;
        }
    }
}
