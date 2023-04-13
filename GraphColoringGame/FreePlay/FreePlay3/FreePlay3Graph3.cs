using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.FreePlay
{
    /// <summary>
    ///         0 - 0 - 0
    ///         |
    ///     0 - 0 - 0 - 0 - 0
    ///         |       |
    ///         0   0 - 0 - 0
    ///                 |
    ///                 0
    /// </summary>
    public class FreePlay3Graph3 : IFreePlay
    {

        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green });
            Coord[] coords = {
            new Coord(1,0), // coords[0]
            new Coord(2, 0), // 1
            new Coord(3, 0),//2
            new Coord(0, 1),//3
            new Coord(1, 1),//4
            new Coord(2,1), //5
            new Coord(3,1), //6
            new Coord(4,1), // 7
            new Coord(1,2), // 8
            new Coord(2,2),// 9
            new Coord(3,2), // 10
            new Coord(4,2),//11
            new Coord(3,3),//12
            };

            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[1]),
                (coords[0], coords[4]),
                (coords[1], coords[2]),
                (coords[4], coords[3]),
                (coords[4], coords[5]),
                (coords[4], coords[8]),
                (coords[5], coords[6]),
                (coords[6], coords[7]),
                (coords[6], coords[10]),
                (coords[9], coords[10]),
                (coords[8], coords[10]),
                (coords[10], coords[11]),
                (coords[10], coords[12])
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}
