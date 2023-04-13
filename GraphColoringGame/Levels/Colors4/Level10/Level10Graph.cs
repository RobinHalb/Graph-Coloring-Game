using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    /*
     *              0
     *              |
     *  0 - 0 - 0 - 0 - 0
     *      |   |
     *      0   0
     *        /   \
     *      0       0   
    */
    public class Level10Graph
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green, Color.Yellow });
            Coord[] coords = {
            new Coord(3,0), // coords[0]
            new Coord(0, 1), // 1
            new Coord(1, 1),//2
            new Coord(2, 1),//3
            new Coord(3, 1),//4
            new Coord(4,1), //5
            new Coord(1,2), //6
            new Coord(2,2),
            new Coord(1,3),
            new Coord(3,3),
            };

            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[4]),
                (coords[1], coords[2]),
                (coords[2], coords[3]),
                (coords[2], coords[6]),
                (coords[3], coords[4]),
                (coords[3], coords[7]),
                (coords[4], coords[5]),
                (coords[7], coords[8]),
                (coords[7], coords[9]),
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }

        public Graph coloredGraph()
        {
            var graph = createGraph();
            
            var coord1 = new Coord(0, 1);
            var coord2 = new Coord(4,1);
            var coord3 = new Coord(3,3);
            graph.colorVertex(coord1, Color.Red);
            graph.colorVertex(coord2, Color.Blue);
            graph.colorVertex(coord3, Color.Green);

            return graph;
        }
    }
}
