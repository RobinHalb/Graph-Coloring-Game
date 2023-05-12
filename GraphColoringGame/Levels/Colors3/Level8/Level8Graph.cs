using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    /* 
     *      
     *      0       0
     *      |       |
     *  a - 0 - 0 - 0 - b
     */
    public class Level8Graph
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green });
            Coord[] coords = {
            new Coord(1,0), //coords[0]
            new Coord(3, 0), //1
            // Row 2
            new Coord(0, 1), //2
            new Coord(1, 1), //3
            new Coord(2, 1), //4
            new Coord(3, 1), //5
            new Coord(4, 1), //6
            
            };

            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[3]),
                (coords[1], coords[5]),
                (coords[2], coords[3]),
                (coords[3], coords[4]),
                (coords[4], coords[5]),
                (coords[5], coords[6]),
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }

        public Graph coloredGraph() 
        {
            var graph = createGraph();
            var coord1 = new Coord(0,1);
            var coord2 = new Coord(4, 1);
            graph.colorVertex(coord1, Color.Red);
            graph.colorVertex(coord2, Color.Blue);
            return graph;

        }
    }
}
