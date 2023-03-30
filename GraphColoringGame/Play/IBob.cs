using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Play
{
    public interface IBob
    {
        (Coord, Color)? play(Graph graph);
    }
}
