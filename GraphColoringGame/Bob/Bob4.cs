using GraphColoringGame.Graphs;
using GraphColoringGame.Bob.Strategies;
using System.Linq;
using System.Collections.Generic;
using System;

namespace GraphColoringGame.Bob
{
    /*
     * The representation of Bob for the 4-coloring game.
     * hasWinning - indicates whether a winning strategy for Bob has been found.
     */
    public class Bob4 : IBob
    {
        public bool hasWinning { get; private set; }

        /*
         * play - returns Bob's next move.
         */
        public (Coord, Color)? play(Graph graph)
        {
            var strats = new IStrat[]
            {
                new StratWin(),
                new StratDouble(),
            };

            foreach (var strat in strats)
            {
                foreach (var dv in graph.dangerousVertices)
                {
                    var move = strat.tryMove(dv);
                    if (move != null)
                    {
                        hasWinning = true;
                        return move;
                    }
                }
            }
            var stratDangerous = new StratDangerous();
            var moves = new List<(Coord, Color)>();
            foreach (var dv in graph.dangerousVertices)
            {
                var move = stratDangerous.tryMove(dv);
                if (move != null) moves.Add(((Coord, Color))move);
            }
            if (moves.Any())
            {
                Random rnd = new Random();
                var i = rnd.Next(moves.Count);
                return moves[i];
            }
            var vertex = graph.vertices.FirstOrDefault(v => !v.isColored);
            if (vertex != null) return (vertex.coord, vertex.availableColors[0]);
            return null;
        }
    }
}
