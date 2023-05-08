using GraphColoringGame.Graphs;
using System.Linq;

namespace GraphColoringGame.Bob.Strategies.ThreeColors
{
    public class Strat3C : IStrat
    {
        /*
         * Case:
         * 
         *           0   0   0
         *           |   |   |
         *   a - 0 - 0 - 0 - 0 - 0
         *       |   |   |   |
         *       0   0   0   0
         *       
         * Vertex names:
         * 
         *            v3a  v4a  v5a
         *             |    |    |
         *   v1 - v2 - v3 - v4 - v5 - v6
         *        |    |    |    |
         *       v2b  v3b  v4b  v5b
         *       
         * Move: Color v3
         * 
         * Max moves required to win: 4
         */


        /*
         * hasValidAB - check if a vertex has two uncolored neighbours with three available colors, other than the left and right vertex.
         * 
         * For example, given v3, v2, and v4, checks whether a valid v3a and v3b exists.
         */
        private bool hasValidAB(Vertex v, Vertex vLeft, Vertex vRight) => v.neighbours.Values.Count(n => n != vLeft && n != vRight && !n.isColored && n.availableColors.Count == 3) >= 2;

        /*
         * tryMove - return move if the pattern can be matched with the given vertex as v2.
         * 
         * The given vertex v is placed as v2 in the pattern.
         * v2 must have two available colors, and at least two uncolored neighbors with three available colors.
         * Each dangerous vertex v3, v4, and v5 must have at least two uncolored neighbours with three available colors (fx. v3a and v3b for v3), other than the assigned adjacent dangerous vertices.
         */
        public (Coord, Color)? tryMove(Vertex v2)
        {
            if (!v2.isDangerous || v2.availableColors.Count != 2 || v2.neighbours.Values.Count(n => !n.isColored && n.availableColors.Count() == 3) < 2) return null;
            var v1 = v2.neighbours.Values.FirstOrDefault(n => n.isColored);

            foreach (var v3 in v2.neighbours.Values)
            {
                if (v3.isDangerous && v3.availableColors.Count() == 3)
                {
                    foreach (var v4 in v3.neighbours.Values)
                    {
                        if (v4 != v2 && v4.isDangerous && v4.availableColors.Count == 3 &&
                                    hasValidAB(v3, v2, v4))
                        {
                            foreach (var v5 in v4.neighbours.Values)
                            {
                                if (v5 != v3 && v5.isDangerous && v5.availableColors.Count == 3 &&
                                    hasValidAB(v4, v3, v5) &&
                                    v5.neighbours.Values.Count(n => n != v4 && !n.isColored && n.availableColors.Count == 3) >= 3)
                                {
                                    return (v3.coord, v2.availableColors[0]);
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
