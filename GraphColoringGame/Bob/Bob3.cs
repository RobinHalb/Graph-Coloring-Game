using GraphColoringGame.Bob.Strategies;
using GraphColoringGame.Bob.Strategies.ThreeColors;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Documents;

namespace GraphColoringGame.Bob
{
    public class Bob3 : IBob
    {
        public bool hasWinning { get; private set; }

        /*
         * play - returns Bob's next move.
         * 
         * For each possible strategy in order of number of required moves, checks whether the strategy can be applied to any of the dangerous vertices.
         * If no dangerous vertices are present in the graph, a random uncolored vertex will be colored.
         */
        public (Coord, Color)? play(Graph graph)
        {
            var strats = new IStrat[]
            {
                new StratWin(),
                new Strat3A(),
                new StratDouble(),
                new Strat3B(),
                new Strat3C(),
                new Strat3D(),
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
