﻿using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    /*
     * Partial colored graph with 11 vertices. Demonstrates that Alice may not win when there is a supgraph similar to Level 9 in the graph.
     * a: Red colored vertex
     * b: Blue colored vertex
     * 
     *      0   0       a
     *      |   |       |
     *  a - 0 - 0 - b - 0
     *      |   |       |
     *      0   0       0
     */
    public class Level10Graph
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green });
            Coord[] coords = {
                new Coord(1,0), // coords[0]
                new Coord(2, 0), // 1
                new Coord(4, 0), // 2
                // Row
                new Coord(0, 1), //3
                new Coord(1, 1), //4
                new Coord(2, 1), //5
                new Coord(3, 1), //6
                new Coord(4, 1), //7
                // Row 3
                new Coord(1, 2), //8
                new Coord(2, 2), //9
                new Coord(4, 2), //10
            };



            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[3], coords[4]),
                (coords[4], coords[5]),
                (coords[5], coords[6]),
                (coords[6], coords[7]),
                (coords[4], coords[0]),
                (coords[4], coords[8]),
                (coords[5], coords[1]),
                (coords[5], coords[9]),
                (coords[7], coords[2]),
                (coords[7], coords[10]),
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
            var vertex1 = new Coord(0,1);
            var vertex2 = new Coord(4,0);
            var vertex3 = new Coord(3,1);
            graph.colorVertex(vertex1, Color.Red);
            graph.colorVertex(vertex2, Color.Red);
            graph.colorVertex(vertex3, Color.Blue);

            return graph;
        }
    }
}
