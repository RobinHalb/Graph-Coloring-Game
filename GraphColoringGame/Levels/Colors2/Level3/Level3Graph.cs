using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphColoringGame.Graphs;

namespace GraphColoringGame.Levels
{
    /*
     * Graph is a P_3+ where Alice can win and lose depending on whether she is following her winning strategy.
     * 
     *      0
     *      |
     *  0 - 0 - 0 
     */
    public class Level3Graph
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue });
            Coord[] coords = {
            new Coord(0,1), // coords[0]
            new Coord(1, 1), // 1
            new Coord(2, 1), //2
            new Coord(1, 0),//3
            };



            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[1]),
                (coords[1], coords[2]),
                (coords[1], coords[3]),
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}
