using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphColoringGame.Graphs;

namespace GraphColoringGame.Levels
{
    public class Old_Level2Graph
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue });
            Coord[] coords = {
                new Coord(0, 0),
                new Coord(0, 1),
                new Coord(1, 1),
                new Coord(2, 1),
                new Coord(2, 0),
                new Coord(3, 1),
            };
            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[2]),
                (coords[1], coords[2]),
                (coords[2], coords[3]),
                (coords[3], coords[4]),
                (coords[3], coords[5]),

            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}
