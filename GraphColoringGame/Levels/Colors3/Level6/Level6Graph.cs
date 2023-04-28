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
     *  a - 0 - 0
     *      |   |
     *      b   0
     * 
     */
    public class Level6Graph
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green });
            Coord[] coords = {
                new Coord(1,0), // coords[0] v1a
                new Coord(2, 0), // 1 v2a
                new Coord(0, 1),//2 v0
                new Coord(1, 1),//3 v1
                new Coord(2, 1),//4 v2
                new Coord(1,2), //5 v1b
                new Coord(2,2), //6 v2b
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

        public Graph coloredGraph() 
        {
            var graph = createGraph();
            var coord1 = new Coord(0, 1);
            var coord2 = new Coord(1, 2);
            graph.colorVertex(coord1, Color.Red);
            graph.colorVertex(coord2, Color.Blue);

            return graph;
        }

    }
}
