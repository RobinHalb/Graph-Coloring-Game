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
            if (v.isDangerous)
            {
                foreach (var n in v.neighbours.Values)
                {
                    if (!n.isColored)
                    {
                        foreach (var c in n.availableColors)
                        {
                            if (v.availableColors.Contains(c)) return (n.coord, c);
                        }

                    }
                }
            }
            return null;
        }
    }
}
