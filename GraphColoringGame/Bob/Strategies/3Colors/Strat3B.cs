using GraphColoringGame.Graphs;
using System.Linq;

namespace GraphColoringGame.Bob.Strategies.ThreeColors
{
    public class Strat3B : IStrat
    {
        /*
         * Case:
         * 
         *       0   0
         *       |   |
         *   a - 0 - 0 - 0
         *       |   |
         *       0   0
         *       
         * Vertex names:
         * 
         *       v2a  v3a
         *        |    |
         *   v1 - v2 - v3 - v4
         *        |    |
         *       v2b  v3b
         *   
         * Move: Color v4 with a
         * 
         * Max moves required to win: 3
         */


        /*
         * tryMove - return move if the pattern can be matched.
         * 
         * The given vertex is placed as v2 in the pattern.
         * For each possible vertex in each place in the pattern, it is checked whether the requirements are met.
         * - v1 must be colored.
         * - v2 must have at least two uncolored neighbours, with no colored neighbours themselves.
         * - v3 must be a dangerous vertex, and have at least two uncolored neighbours, one of which may have one colored neighbour.
         * - v4 must be uncolored, and have the color of v1 available.
         */
        public (Coord, Color)? tryMove(Vertex v2)
        {
            var v1 = v2.neighbours.Values.FirstOrDefault(n => n.isColored);
            if (!v2.isDangerous || v1 == null) return null;

            foreach (var v3 in v2.neighbours.Values)
            {
                if (v3.isDangerous &&
                    v2.neighbours.Values.Count(n => n != v3 && !n.isColored && n.availableColors.Count == 3) >= 2)
                {
                    foreach (var v4 in v3.neighbours.Values)
                    {
                        if (!v4.isColored && v4 != v2 && v4.availableColors.Contains(v1.color))
                        {
                            var v3Neighbours = v3.neighbours.Values.Where(n => !n.isColored && n != v2 && n != v4 && n.availableColors.Count >= 2);
                            if (v3Neighbours.Count() >= 2 && 
                                v3Neighbours.Any(n => n.availableColors.Count == 3))
                            {
                                return (v4.coord, v1.color);
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
