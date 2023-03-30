using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Play
{
    public class Bob2 : IBob
    {
        public (Coord, Color)? play(Graph graph)
        {
            foreach (var dv in graph.dangerousVertices)
            {
                if (dv.availableColors.Count == 1) 
                {
                    var color = dv.availableColors[0];
                    foreach (var n in dv.neighbours.Values)
                    {
                        if (!n.isColored && n.availableColors.Contains(color)) return (n.coord, color);
                    }
                }
            }
            var vertex = graph.vertices.FirstOrDefault(v => !v.isColored);
            if (vertex != null) return (vertex.coord, vertex.availableColors[0]);
            return null;
        }
    }
}
