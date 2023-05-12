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
         *  v0a       v2a
         *   |         |
         *   v0 - v1 - v2
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
         * The given vertex is placed as v0 in the pattern.
         * For each possible vertex in each place in the pattern, it is checked whether the requirements are met.
         * - v0 and v2 must each be dangerous and have exactly two available colors.
         * - v0 and v2 must share an available color, and each have a neighbour different from v1, which can be colored with the other available color.
         * - v1 must be uncolored and colorable with the shared available color.
         */
        public (Coord, Color)? tryMove(Vertex v0)
        {
            var v0Colors = v0.availableColors;
            if (!v0.isDangerous || v0Colors.Count != 2) return null;

            foreach (var v1 in v0.neighbours.Values)
            {
                if (!v1.isColored)
                {
                    var v1Colors = v1.availableColors;
                    foreach (var v2 in v1.neighbours.Values)
                    {
                        var v2Colors = v2.availableColors;
                        if (v2 != v0 && v2.isDangerous && v2Colors.Count == 2)
                        {
                            foreach (var cShared in v0Colors)
                            {
                                if (v1Colors.Contains(cShared) && v2Colors.Contains(cShared))
                                {
                                    var cv1 = v0Colors.First(c => c != cShared);
                                    var cv3 = v2Colors.First(c => c != cShared);

                                    if (v0.neighbours.Values.Any(n => n != v1 && !n.isColored && n.availableColors.Contains(cv1)) &&
                                        v2.neighbours.Values.Any(n => n != v1 && !n.isColored && n.availableColors.Contains(cv3))) 
                                    {
                                        return (v1.coord, cShared);
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
