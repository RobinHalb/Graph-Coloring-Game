﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphColoringGame.Graphs;

namespace GraphColoringGame.Levels
{
    /*
     * Graph with 11 vertices, demonstrating Alice's winning strategy, and how Bob can create a subgraph similar to Level 9 if Alice does not follow her winnning strategy.
     * 
     *      0   0   0
     *      |   |   |
     *  0 - 0 - 0 - 0 - 0
     *      |   |   |
     *      0   0   0
     */
    public class Level11Graph
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green });
            Coord[] coords = {
            new Coord(1, 0), // coords[0]
            new Coord(2, 0), // 1
            new Coord(3, 0), //2
            // Row 2
            new Coord(0, 1), //3
            new Coord(1, 1), //4
            new Coord(2, 1), //5
            new Coord(3, 1), //6
            new Coord(4, 1), //7
            // Row 3
            new Coord(1, 2), //8
            new Coord(2, 2), //9
            new Coord(3, 2), //10
            };



            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[4]),
                (coords[1], coords[5]),
                (coords[2], coords[6]),
                (coords[3], coords[4]),
                (coords[4], coords[5]),
                (coords[5], coords[6]),
                (coords[6], coords[7]),
                (coords[8], coords[4]),
                (coords[9], coords[5]),
                (coords[10], coords[6]),
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}
