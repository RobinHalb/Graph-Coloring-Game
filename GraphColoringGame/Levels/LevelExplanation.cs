using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GraphColoringGame.Levels
{
    public abstract class LevelExplanation
    {
        protected System.Windows.Media.Color green = Colors.ForestGreen;
        protected System.Windows.Media.Color purple = Colors.Purple;
        protected System.Windows.Media.Color black = Colors.Black;
        protected double greyout = 0.2;

        protected IEnumerable<(Coord, IEnumerable<Direction>)> connections;
        protected List<Graphs.Color> colors;
        protected int width, height, xMin, yMin;

        public LevelExplanation(Graph graph)
        {
            this.connections = graph.connections;
            this.colors = graph.colors.ToList();
            this.width = graph.width;
            this.height = graph.height;
            this.xMin = graph.xMin;
            this.yMin = graph.yMin;
        }

        protected Dictionary<Coord, ExplanationVertex> newVertices()
        {
            var vertices = new Dictionary<Coord, ExplanationVertex>();
            foreach (var (coord, dirs) in connections)
                vertices.Add(coord, new ExplanationVertex(dirs));
            return vertices;
        }
    }
}
