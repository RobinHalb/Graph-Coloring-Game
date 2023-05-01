using GraphColoringGame.Graphs;

namespace GraphColoringGame.Bob.Strategies
{
    public class StratDangerous : IStrat
    {
        /*
         * tryMove - return move if the given vertex is dangerous and has a neighbour that can be colored with an available color of the vertex.
         */
        public (Coord, Color)? tryMove(Vertex v)
        {
            Vertex? vertex = null;
            Color? color = null;

            if (v.isDangerous)
            {
                var colors = v.availableColors;
                foreach (var n in v.neighbours.Values)
                {
                    if (!n.isColored)
                    {
                        foreach (var c in n.availableColors)
                        {
                            if (colors.Contains(c))
                            {
                                if (!n.isDangerous) return (n.coord, c);
                                vertex = n;
                                color = c;
                                break;
                            }
                        }
                    }
                }
            }
            if (vertex != null && color != null) return (vertex!.coord, (Color)color);
            return null;
        }
    }
}
