using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace GraphColoringGame.Bob.Strategies
{
    public class StratDangerous : IStrat
    {
        /*
         * tryMove - return move if the given vertex is dangerous and has a neighbour that can be colored with an available color of the vertex.
         */
        public (Coord, Color)? tryMove(Vertex v)
        {
            List<(Coord,Color)> safe = new List<(Coord, Color)>();
            List<(Coord, Color)> dangerous = new List<(Coord, Color)>();

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
                                if (n.isDangerous) dangerous.Add((n.coord, c));
                                else safe.Add((n.coord, c));
                                break;
                            }
                        }
                    }
                }
            }
            if (safe.Any())
            {
                Random rnd = new Random();
                var i = rnd.Next(safe.Count);
                return safe[i];
            }
            if (dangerous.Any())
            {
                Random rnd = new Random();
                var i = rnd.Next(dangerous.Count);
                return dangerous[i];
            }
            return null;
        }
    }
}
