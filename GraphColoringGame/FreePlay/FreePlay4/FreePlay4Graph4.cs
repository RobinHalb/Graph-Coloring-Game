using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.FreePlay
{
    /*
     *          0       0   0
     *          |       | /
     *      0   0   0 - 0   0
     *      |   |       | /
     *  0 - 0 - 0 - 0 - 0 - 0
     *    / |       |       |       
     *  0   0       0   0 - 0 - 0 - 0
     *                      |
     *              0 - 0 - 0 - 0
     */
    public class FreePlay4Graph4 :IFreePlay
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green, Color.Yellow });
            Coord[] coords = {
            new Coord(2, 0), // coords[0]
            new Coord(4, 0), // 1
            new Coord(5, 0), // 2
            // Row 2
            new Coord(1, 1), // 3
            new Coord(2, 1), // 4
            new Coord(3, 1), // 5
            new Coord(4, 1), // 6
            new Coord(5, 1), // 7
            // Row 3
            new Coord(0, 2), // 8
            new Coord(1, 2), // 9
            new Coord(2, 2), // 10
            new Coord(3, 2), // 11
            new Coord(4, 2), // 12
            new Coord(5, 2), // 13
            //  Row 4
            new Coord(0, 3), // 14
            new Coord(1, 3), // 15
            new Coord(3, 3), // 16
            new Coord(4, 3), // 17
            new Coord(5, 3), // 18
            new Coord(6, 3), // 19
            new Coord(7, 3), // 20
            // Row 5
            new Coord(3, 4), // 21
            new Coord(4, 4), // 22
            new Coord(5, 4), // 23
            new Coord(6, 4), // 24
            };

            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[4]),
                (coords[1], coords[6]),
                (coords[2], coords[6]),
                // Row 2
                (coords[3], coords[9]),
                (coords[4], coords[10]),
                (coords[5], coords[6]),
                (coords[6], coords[12]),
                (coords[7], coords[12]),
                // Row 3
                (coords[8], coords[9]),
                (coords[9], coords[10]),
                (coords[9], coords[14]),
                (coords[9], coords[15]),
                (coords[10], coords[11]),
                (coords[11], coords[12]),
                (coords[11], coords[16]),
                (coords[12], coords[13]),
                (coords[13], coords[18]),
                // Row 4
                (coords[17], coords[18]),
                (coords[18], coords[19]),
                (coords[18], coords[23]),
                (coords[19], coords[20]),
                // Row 5
                (coords[21], coords[22]),
                (coords[22], coords[23]),
                (coords[23], coords[24]),
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}
