using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphColoringGame.Graphs;

namespace GraphColoringGame.Levels
{
    public class Level1Graph
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue });
            Coord[] coords = {
                new Coord(0, 0),
                new Coord(1, 0),
                new Coord(2, 0)
            };
            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[1]),
                (coords[1], coords[2])
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}
