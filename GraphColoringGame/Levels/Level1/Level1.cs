using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level1 : ILevel
    {
        public Graph graph { get; private set; }

        public Level1()
        {
            graph = new Level1Graph().createGraph();
        }
    }
}
