using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.FreePlay
{
    public class FreePlay4Graph5 : IFreePlay
    {
        /*
         *  0   0   0   0   0   0
         *    \ |   | /   /     |
         *  0 - 0 - 0 - 0 - 0 - 0 - 0
         *      |       | \     |
         *      0 - 0   0   0   0
         *      | \
         *      0   0 - 0
         * 
         */
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green, Color.Yellow });
            Coord[] coords = {
            new Coord(0, 0), // coords[0]
            new Coord(1, 0), // 1
            new Coord(2, 0), // 2
            new Coord(3, 0), // 3
            new Coord(4, 0), // 4
            new Coord(5, 0), // 5
            // Row 2
            new Coord(0, 1), // 6
            new Coord(1, 1), // 7
            new Coord(2, 1), // 8
            new Coord(3, 1), // 9
            new Coord(4, 1), // 10
            new Coord(5, 1), // 11
            new Coord(6, 1), // 12
            // Row 3
            new Coord(1, 2), // 13
            new Coord(2, 2), // 14
            new Coord(3, 2), // 15
            new Coord(4, 2), // 16
            new Coord(5, 2), // 17
            // Row 4
            new Coord(1, 3), // 18
            new Coord(2, 3), // 19
            new Coord(3, 3), // 20
            };

            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[7]),
                (coords[1], coords[7]),
                (coords[2], coords[8]),
                (coords[3], coords[8]),
                (coords[4], coords[9]),
                (coords[5], coords[11]),
                // Row 2
                (coords[6], coords[7]),
                (coords[7], coords[8]),
                (coords[7], coords[13]),
                (coords[8], coords[9]),
                (coords[9], coords[10]),
                (coords[9], coords[15]),
                (coords[9], coords[16]),
                (coords[10], coords[11]),
                (coords[11], coords[12]),
                (coords[11], coords[17]),
                // Row 3
                (coords[13], coords[14]),
                (coords[13], coords[18]),
                (coords[13], coords[19]),
                // Row 4
                (coords[19], coords[20]),
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}
