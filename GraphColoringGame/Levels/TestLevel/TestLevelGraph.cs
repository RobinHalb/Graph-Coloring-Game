using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphColoringGame.Graphs;

namespace GraphColoringGame.Levels.TestLevelContent
{
    public class TestLevelGraph
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green });
            Coord[] coords = {
            new Coord(1,0), // coords[0]
            new Coord(2, 0), // 1
            new Coord(0, 1), //2
            new Coord(1, 1),//3
            new Coord(2, 1),//4
            new Coord(3, 1),//5
            new Coord(1, 2),//6
            new Coord(2, 2)//7
            };

        
        
            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[3]),
                (coords[1], coords[4]),
                (coords[2], coords[3]),
                (coords[3], coords[6]),
                (coords[3], coords[4]),
                (coords[7], coords[4]),
                (coords[4], coords[5]),
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}
