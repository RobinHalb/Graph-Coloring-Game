﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphColoringGame.Graphs;

namespace GraphColoringGame.Levels
{
    /*
     * Graph is a P_4+, Alice cannot win with only 2 colors.
     * 
     *          0
     *          |
     *  0 - 0 - 0 - 0 
     */
    public class Level4Graph
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue });
            Coord[] coords = {
            new Coord(0,1),  //coords[0]
            new Coord(1, 1), //1
            new Coord(2, 1), //2
            new Coord(3, 1), //3
            new Coord(2, 0), //4
            };



            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[1]),
                (coords[1], coords[2]),
                (coords[2], coords[3]),
                (coords[4], coords[2]),
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}
