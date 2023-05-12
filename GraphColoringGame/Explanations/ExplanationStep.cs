using GraphColoringGame.Graphs;
using System.Collections.Generic;

namespace GraphColoringGame.Explanations
{
    /*
     * A step in the explanation for a level.
     * text - the text for the step.
     * vertices - the dictionary of ExplanationVertex representing the graph to be shown with the step.
     * colors - the list of colors available to the graph.
     * xMin, yMin - the coordinates for the corner of the graph closest to (0,0).
     * width, height - the width and height of the graph.
     */
    public class ExplanationStep
    {
        public string text { get; private set; }
        public Dictionary<Coord, ExplanationVertex> vertices { get; private set; }
        public readonly List<Color> colors;
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
