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
            new Coord(0,1), // coords[0]
            new Coord(1, 1), // 1
            new Coord(2, 1), //2
            new Coord(3, 1),//3
            new Coord(1, 0),//4
            new Coord(2, 0),//5
            new Coord(1,2),
            new Coord(2,2)
            };



            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[1]),
                (coords[1], coords[4]),
                (coords[1], coords[2]),
                (coords[2], coords[3]),
                (coords[2], coords[5]),
                (coords[1], coords[6]),
                (coords[2], coords[7]),
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }

        public Graph coloredGraph() 
        {
            var graph = createGraph();
            var vertex1 = new Coord(0,1);
            var vertex2 = new Coord(3,1);
            graph.colorVertex(vertex1, Color.Red);
            graph.colorVertex(vertex2, Color.Red);

            return graph;
        }
    }
}