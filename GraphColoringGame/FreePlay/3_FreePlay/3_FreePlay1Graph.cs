using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.FreePlay
{
    /// <summary>
    ///     0       0
    ///     |       |
    ///     0       0
    ///     |       |
    ///     0       0
    ///       \   /
    ///         0
    ///         |
    ///     0 - 0 - 0
    ///         |
    ///         0
    ///       /   \
    ///     0       0
    /// </summary>
    public class _3_FreePlay1Graph
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green });
            Coord[] coords = {
            new Coord(0,0), // coords[0]
            new Coord(2, 0), // 1
            new Coord(0, 1),//2
            new Coord(2, 1),//3
            new Coord(0, 2),//4
            new Coord(2,2), //5
            new Coord(1,3), //6
            new Coord(0,4), // 7
            new Coord(1,4), // 8
            new Coord(2,4),// 9
            new Coord(1,5), // 10
            new Coord(0,6),//11
            new Coord(2,6),//12
            };

            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[2]),
                (coords[1], coords[3]),
                (coords[2], coords[4]),
                (coords[4], coords[6]),
                (coords[3], coords[5]),
                (coords[5], coords[6]),
                (coords[6], coords[8]),
                (coords[7], coords[8]),
                (coords[8], coords[9]),
                (coords[8], coords[10]),
                (coords[10], coords[11]),
                (coords[10], coords[12])
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}
