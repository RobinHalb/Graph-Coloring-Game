using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    /*
     * Graph with 14 vertices showing Alice cannot win on trees with more than 13 vertices.
     * 
     *      0   0   0   0   0
     *      |   |   |   |   |
     *      0 - 0 - 0 - 0 - 0 - 0
     *          |   |   |   |
     *          0   0   0   0
     */
    public class Level13Graph
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green });

            Coord[] coords = {
                new Coord(0, 0), // 0
                new Coord(1, 0), // 1
                new Coord(2, 0), // 2
                new Coord(3, 0), // 3
                new Coord(4, 0), // 4
                // Row 2
                new Coord(0, 1), // 5
                new Coord(1, 1), // 6
                new Coord(2, 1), // 7
                new Coord(3, 1), // 8
                new Coord(4, 1), // 9
                new Coord(5, 1), // 10
                // Row 3
                new Coord(1, 2), // 11
                new Coord(2, 2), // 12
                new Coord(3, 2), // 13
                new Coord(4, 2), // 14
            };



            builder.addVertexMany(coords);
            (Coord, Coord)[] connections = {
                (coords[0], coords[5]),
                (coords[5], coords[6]),
                (coords[6], coords[7]),
                (coords[7], coords[8]),
                (coords[8], coords[9]),
                (coords[9], coords[10]),
                (coords[6], coords[1]),
                (coords[6], coords[11]),
                (coords[7], coords[2]),
                (coords[7], coords[12]),
                (coords[8], coords[3]),
                (coords[8], coords[13]),
                (coords[9], coords[4]),
                (coords[9], coords[14]),
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}
