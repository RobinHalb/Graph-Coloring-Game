using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.FreePlay
{
    /* 
     * 
     *      0
     *      |
     *  0 - 0   0
     *      |   |
     *      0 - 0 - 0
     *      
     */
    public class FreePlay3Graph6 : IFreePlay
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green });
            Coord[] coords = {
            new Coord(1,0), // coords[0]
            new Coord(0, 1), // 1
            new Coord(1, 1),//2
            new Coord(2, 1),//3
            new Coord(1, 2),//4
            new Coord(2,2), //5
            new Coord(3,2), //6
            };

            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[2]),
                (coords[1], coords[2]),
                (coords[2], coords[4]),
                (coords[4], coords[5]),
                (coords[5], coords[6]),
                (coords[5], coords[3]),
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}
