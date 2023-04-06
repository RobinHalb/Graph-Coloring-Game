using GraphColoringGame.Bob.Strategies;
using GraphColoringGame.Graphs;
using System.Linq;

namespace GraphColoringGame.Bob
{
    public class Bob2 : IBob
    {
        /*
        * play - returns Bob's next move.
        */
        public (Coord, Color)? play(Graph graph)
        {
            var strat = new StratWin();
            foreach (var dv in graph.dangerousVertices)
            {
                var move = strat.tryMove(dv);
                if (move != null) return move;
            }
            var vertex = graph.vertices.FirstOrDefault(v => !v.isColored);
            if (vertex != null) return (vertex.coord, vertex.availableColors[0]);
            return null;
        }
    }
}
