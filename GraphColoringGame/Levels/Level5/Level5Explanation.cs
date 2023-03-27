using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level5Explanation : LevelExplanation
    {
        private Coord[] coords;
        public Level5Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
            new Coord(0,0), // coords[0]
            new Coord(1, 0), // 1
            new Coord(2, 0), //2
            new Coord(3, 0),//3
            new Coord(1, -1),//4
            new Coord(2, -1)//5
            };
        }
    }
}
