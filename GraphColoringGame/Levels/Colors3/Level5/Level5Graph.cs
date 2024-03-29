﻿using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    /*
     * Partial colored graph with 7 vertices showing Alice can win with 3 colors when one of two dangerous vertices has one colored neighbor.
     * a: Red colored vertex
     * 
     *      0   0
     *      |   |
     *  0 - 0 - 0
     *      |   |
     *      a   0
     */
    public class Level5Graph {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green });
            Coord[] coords = {
            new Coord(1,0), //coords[0]
            new Coord(2, 0), //1
            // Row 2
            new Coord(0, 1), //2
            new Coord(1, 1), //3
            new Coord(2, 1), //4
            // Row 3
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

        /*
            coloredGraph: Returns the graph with pre-colored vertices
         */
        public Graph coloredGraph()
        {
            var graph = createGraph();
            var coord1 = new Coord(1,2);
            graph.colorVertex(coord1, Color.Red);

            return graph;
        }
    }
}

