using GraphColoringGame.Graphs;

namespace GraphColoringGame.Bob.Strategies
{
    public class StratWin : IStrat
    {
        /*
         * tryMove - return move if the given given vertex has a winning move.
         * 
         * If the vertex is dangerous and has only one available color, checks if a neighbour can be colored with that color.
         */
        public (Coord, Color)? tryMove(Vertex v)
        {
            if (v.isDangerous && v.availableColors.Count == 1)
            {
                var c = v.availableColors[0];
                foreach (var n in v.neighbours.Values)
                {
                    if (!n.isColored && n.availableColors.Contains(c)) return (n.coord, c);
                }
            }
            return null;
        }
    }
}
