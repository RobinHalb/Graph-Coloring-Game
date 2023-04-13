﻿using GraphColoringGame.Graphs;
using GraphColoringGame.Bob.Strategies;
using System.Linq;

namespace GraphColoringGame.Bob
{
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
            foreach (var dv in graph.dangerousVertices)
            {
                var move = stratDangerous.tryMove(dv);
                if (move != null) return move;
            }
            var vertex = graph.vertices.FirstOrDefault(v => !v.isColored);
            if (vertex != null) return (vertex.coord, vertex.availableColors[0]);
            return null;
        }
    }
}