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
         *       v1a  v2a
         *        |    |
         *   v0 - v1 - v2 - v3
         *        |    |
         *       v1b  v2b
         *   
         * Move: Color v3 with a
         * 
         * Max moves required to win: 3
         */


        /*
         * tryMove - return move if the pattern can be matched.
         * 
         * The given vertex is placed as v1 in the pattern.
         * For each possible vertex in each place in the pattern, it is checked whether the requirements are met.
         * - v0 must be colored.
         * - v1 must have at least three uncolored neighbours with some color different from v0 available, and at least two of them must have 3 available colors.
         * - v2 must be a dangerous vertex, and have at least four uncolored neighbours, one of which must be different from v1 and v3 and have 3 available colors.
         * - v3 must be uncolored, and have the color of v0 available.
         */
        public (Coord, Color)? tryMove(Vertex v1)
        {
            var v0 = v1.neighbours.Values.FirstOrDefault(n => n.isColored);
            if (!v1.isDangerous || v0 == null) return null;

            var v1n = v1.neighbours.Values.Where(n => !n.isColored && n.availableColors.Count == 3);

            if (v1n.Count() == 3 ||
                (v1n.Count() == 2 &&
                 v1.neighbours.Values.Count(n => !n.isColored && !(n.availableColors.Count() == 1 && n.availableColors.Contains(v0.color))) >= 3))
            {
                foreach (var v2 in v1n)
                {
                    if (v2.isDangerous && v2.neighbours.Values.Count(n => !n.isColored) >= 4)
                    {
                        foreach (var v3 in v2.neighbours.Values)
                        {
                            if (!v3.isColored && v3 != v1 && v3.availableColors.Contains(v0.color) &&
                                v2.neighbours.Values.Any(n => n != v1 && n != v3 && n.availableColors.Count == 3))
                            {
                                return (v3.coord, v0.color);
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
