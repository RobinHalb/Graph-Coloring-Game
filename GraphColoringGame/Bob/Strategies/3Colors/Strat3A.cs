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
         *   a - 0 - 0 - a/b
         *       |   
         *       0   
         *       
         * Vertex names:
         * 
         *       v1a  v2a
         *        |    |
         *   v0 - v1 - v2 - v3
         *        |
         *       v1b
         *       
         * Move: Color v1a with b
         * 
         * Max moves required to win: 2
         */


        /*
         * tryMove - return move if the pattern can be matched.
         * 
         * The given vertex is placed as v1 in the pattern.
         * For each possible vertex in each place in the pattern, it is checked whether the requirements are met.
         * - v0 must be colored.
         * - v1a must have at least one available color different from the color of v0.
         * - v1b must have a color different from v0 and v1a available.
         * - v2 must be a dangerous vertex and have at least one colored neighbour (v3), and at least one uncolored vertex (v2a), which can be colored differently from v3 and v1b.
         */
        public (Coord, Color)? tryMove(Vertex v1)
        {
            var v0 = v1.neighbours.Values.FirstOrDefault(n => n.isColored);
            if (!v1.isDangerous || v0 == null) return null;

            foreach (var v1a in v1.neighbours.Values)
            {
                if (!v1a.isColored)
                {
                    foreach (var c1 in v1a.availableColors)
                    {
                        if (c1 != v0.color)
                        {
                            var c2 = v1.availableColors.First(c => c != c1);
                            foreach (var v2 in v1.neighbours.Values)
                            {
                                if (v2 != v1a && v2.isDangerous &&
                                    v1.neighbours.Values.Any(n => n != v2 && n != v1a && !n.isColored && n.availableColors.Contains(c2)) &&
                                    ((v2.neighbours.Values.Any(n => n.isColored && n.color != v0.color) &&
                                    v2.neighbours.Values.Any(n => n != v1 && !n.isColored && n.availableColors.Contains(c1))) ||
                                    (v2.neighbours.Values.Any(n => n.isColored && n.color != c1) &&
                                    v2.neighbours.Values.Any(n => n != v1 && !n.isColored && n.availableColors.Contains(v0.color)))))
                                {
                                    return (v1a.coord, c1);
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
