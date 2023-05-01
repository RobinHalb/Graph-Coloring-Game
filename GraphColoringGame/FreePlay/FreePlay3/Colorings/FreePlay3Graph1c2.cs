using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.FreePlay
{
    /*
     *      0   0
     *      |   |
     *  0 - 0 - 0
     *      |   |
     *      a   b
     */
    public class FreePlay3Graph1c2 : IFreePlay
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green });
            Coord[] coords = {
                new Coord(1, 0), // coords[0]
                new Coord(2, 0), // 1
                // Row 2
                new Coord(0, 1), // 2
                new Coord(1, 1), // 3
                new Coord(2, 1), // 4
                // Row 3
                new Coord(1, 2), // 5
                new Coord(2, 2), // 6
            };

            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[3]),
                (coords[1], coords[4]),
                // Row 2
                (coords[2], coords[3]),
                (coords[3], coords[4]),
                (coords[3], coords[5]),
                (coords[4], coords[6]),
            };

            builder.connectVerticesMany(connections);

            var graph = builder.build();

            graph.colorVertex(coords[5], Color.Red);
            graph.colorVertex(coords[6], Color.Blue);

            return graph;
        }
    }
}
