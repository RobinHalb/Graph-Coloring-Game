using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    /*
     * This graph will explain the three different cases with dangerous vertices on a subgraph with at most 7 vertices.
     * Another graph will have to be constructed to illutrate a subcase in case 3 where the dangerous vertices are not neighbors.
     * 
     *      0   0
     *      |   |
     *  0 - 0 - 0
     *      |   |
     *      0   0
     * 
     */
    public class Level5Graph {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green });
            Coord[] coords = {
            new Coord(1,0), // coords[0]
            new Coord(2, 0), // 1
            new Coord(0, 1),//2
            new Coord(1, 1),//3
            new Coord(2, 1),//4
            new Coord(1,2), //5
            new Coord(2,2), //6
            };

            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[3]),
                (coords[1], coords[4]),
                (coords[2], coords[3]),
                (coords[3], coords[4]),
                (coords[3], coords[5]),
                (coords[4], coords[6]),
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}

