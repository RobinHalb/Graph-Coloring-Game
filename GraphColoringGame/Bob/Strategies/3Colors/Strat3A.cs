using GraphColoringGame.Graphs;
using System.Linq;

namespace GraphColoringGame.Bob.Strategies.ThreeColors
{
    public class Strat3A : IStrat
    {
        /*
         * Case:
         * 
         *       0   0
         *       |   |
         *   a - 0 - 0 - a
         *       |   
         *       0   
         *       
         * Vertex names:
         * 
         *       v2a  v3a
         *        |    |
         *   v1 - v2 - v3 - v4
         *        |
         *       v2b
         *       
         * Move: Color v2a with b
         */


        /*
         * tryMove - return move if the pattern can be matched.
         * 
         * The given vertex is placed as v2 in the pattern.
         * For each possible vertex in each place in the pattern, it is checked whether the requirements are met.
         * - v1 must be colored.
         * - v2a must have at least two available colors.
         * - v3 must be a dangerous vertex and have at least one colored neighbour (v4) with the same color as v1, and at least one uncolored vertex (v3a), which can be colored with the same color as is chosen for v2a.
         */
        public (Coord, Color)? tryMove(Vertex v2)
        {
            var v1 = v2.neighbours.Values.FirstOrDefault(n => n.isColored);
            if (v1 == null) return null;

            foreach (var v2a in v2.neighbours.Values)
            {
                if (!v2a.isColored && v2a.availableColors.Count >= 2)
                {
                    foreach (var c1 in v2a.availableColors)
                    {
                        if (c1 != v1.color)
                        {
                            var c2 = v2.availableColors.First(c => c != c1);
                            foreach (var v3 in v2.neighbours.Values)
                            {
                                if (v3 != v2a && v3.isDangerous &&
                                    v2.neighbours.Values.Any(n => n != v3 && n != v2a && !n.isColored && n.availableColors.Contains(c2)) &&
                                    v3.neighbours.Values.Any(n => n.isColored && n.color == v1.color) &&
                                    v3.neighbours.Values.Any(n => n != v2 && !n.isColored && n.availableColors.Contains(c1)))
                                {
                                    return (v2a.coord, c1);
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
