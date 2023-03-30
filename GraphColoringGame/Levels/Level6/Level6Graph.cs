﻿using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level6Graph
    {


        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green });
            Coord[] coords = {
            new Coord(1,-1), // coords[0]
            new Coord(2, -1), // 1
            new Coord(3, -1), //2
            new Coord(4, -1),//3
            new Coord(0, 0),//4
            new Coord(1, 0),//5
            new Coord(2, 0),//6
            new Coord(3, 0),//7
            new Coord(4,0), // 8
            new Coord(5,0),// 9
            new Coord(1,1), //10
            new Coord(2,1), //11
            new Coord(3, 1), //12
            new Coord(4, 1), //13
            };



            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[5]),
                (coords[1], coords[6]),
                (coords[2], coords[7]),
                (coords[3], coords[8]),
                (coords[4], coords[5]),
                (coords[5], coords[6]),
                (coords[6], coords[7]),
                (coords[7], coords[8]),
                (coords[8], coords[9]),
                (coords[5], coords[10]),
                (coords[6], coords[11]),
                (coords[7], coords[12]),
                (coords[8], coords[13]),
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}
