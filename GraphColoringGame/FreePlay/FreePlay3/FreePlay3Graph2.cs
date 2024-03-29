﻿using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.FreePlay
{
    /*
   *  0   0
   *  |   |
   *  0 - 0 - 0
   *  |   |
   *  0   0
   */
    public class FreePlay3Graph2 : IFreePlay
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green });
            Coord[] coords = {
                new Coord(0, 0), // coords[0]
                new Coord(1, 0), // 1
                // Row 2
                new Coord(0, 1), // 2
                new Coord(1, 1), // 3
                new Coord(2, 1), // 4
                // Row 3
                new Coord(0, 2), // 5
                new Coord(1, 2), // 6
            };

            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[2]),
                (coords[1], coords[3]),
                // Row 2
                (coords[2], coords[3]),
                (coords[2], coords[5]),
                (coords[3], coords[4]),
                (coords[3], coords[6]),
            };

            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}
