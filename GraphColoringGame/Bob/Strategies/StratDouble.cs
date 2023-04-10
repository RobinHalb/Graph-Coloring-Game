using GraphColoringGame.Graphs;
using System.Linq;

namespace GraphColoringGame.Bob.Strategies
{
    public class StratDouble : IStrat
    {
        /*
         * Case: 
         *  Dangerous vertices with two available colors each, separated by one vertex
         * 
         *   0       0
         *   |       |
         *   0 - 0 - 0
         *   |       |
         *   ?       ?
         *       
         * Vertex names:
         * 
         *  v1a       v3a
         *   |         |
         *   v1 - v2 - v3
         *   |         |
         *   ?         ?
         *       
         * Move: Color v2 with available color shared by v1 and v3
         * 
         * Max moves required to win: 2
         */


        /*
         * tryMove - return move if the pattern can be matched.
         * 
         * The given vertex is placed as v1 in the pattern.
         * For each possible vertex in each place in the pattern, it is checked whether the requirements are met.
         * - v1 and v3 must each be dangerous and have exactly two available colors.
         * - v1 and v3 must share an available color, and each have a neighbour different from v2, which can be colored with the other available color.
         * - v2 must be uncolored and colorable with the shared available color.
         */
        public (Coord, Color)? tryMove(Vertex v1)
        {
            var v1Colors = v1.availableColors;
            if (!v1.isDangerous || v1Colors.Count != 2) return null;

            foreach (var v2 in v1.neighbours.Values)
            {
                if (!v2.isColored)
                {
                    var v2Colors = v2.availableColors;
                    foreach (var v3 in v2.neighbours.Values)
                    {
                        var v3Colors = v3.availableColors;
                        if (v3 != v1 && v3.isDangerous && v3Colors.Count == 2)
                        {
                            foreach (var cShared in v1Colors)
                            {
                                if (v2Colors.Contains(cShared) && v3Colors.Contains(cShared))
                                {
                                    var cv1 = v1Colors.First(c => c != cShared);
                                    var cv3 = v3Colors.First(c => c != cShared);

                                    if (v1.neighbours.Values.Any(n => n != v2 && !n.isColored && n.availableColors.Contains(cv1)) &&
                                        v3.neighbours.Values.Any(n => n != v2 && !n.isColored && n.availableColors.Contains(cv3))) 
                                    {
                                        return (v2.coord, cShared);
                                    }
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
