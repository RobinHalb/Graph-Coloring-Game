using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Bob.Strategies
{
    public interface IStrat
    {
        public (Coord, Color)? tryMove(Vertex v);
    }
}
