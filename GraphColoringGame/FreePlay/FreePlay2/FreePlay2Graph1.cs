using GraphColoringGame.Graphs;
using System.Collections.Generic;

namespace GraphColoringGame.FreePlay
{
    public class FreePlay2Graph1 : IFreePlay
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue });
            var coords = new Coord[] {
                new Coord(0, 0),
                new Coord(1, 0),
                new Coord(2, 0)
            };
            builder.addVertexMany(coords);

            var connections = new (Coord, Coord)[] {
                (coords[0], coords[1]),
                (coords[1], coords[2])
            };
            builder.connectVerticesMany(connections);
            return builder.build();
        }

        
    }
}
