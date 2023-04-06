using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level2Graph
    {

        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue });
            Coord[] coords = {
            new Coord(0,0), // coords[0]
            new Coord(1, 0), // 1
            new Coord(2, 0), //2
            new Coord(3, 0),//3
            };

            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[1]),
                (coords[1], coords[2]),
                (coords[2], coords[3]),
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}
