using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.FreePlay
{
    public class FreePlay4Graph2 : IFreePlay
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green, Color.Yellow });
            Coord[] coords = {
            new Coord(0,0), // coords[0]
            new Coord(1, 0), // 1
            new Coord(2, 0),//2
            new Coord(3, 0),//3
            new Coord(4, 0),//4
            new Coord(5,0), //5
            //y=1
            new Coord(0,1), //6
            new Coord(1,1), //7
            new Coord(2,1), //8
            new Coord(3,1), //9
            new Coord(4,1), //10
            new Coord(5,1),//11
            //y=2
            new Coord (0,2),//12
            new Coord(1,2),//13
            new Coord(2,2),//14
            new Coord(3,2),//15
            new Coord(4,2),//16
            new Coord(5,2),//17
            //y=3
            new Coord(0,3),//18
            new Coord(1,3),//19
            new Coord (2,3),//20
            new Coord(3,3),//21
            new Coord(4,3),//22
            new Coord(5,3),//23
            };

            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[1]),
                (coords[0], coords[6]),
                (coords[6], coords[12]),
                (coords[12], coords[18]),
                (coords[18], coords[19]),
                (coords[19], coords[20]),
                (coords[20], coords[21]),
                (coords[21], coords[22]),
                (coords[22], coords[23]),
                (coords[1], coords[7]),
                (coords[7], coords[13]),
                (coords[7], coords[8]),
                (coords[8], coords[2]),
                (coords[8], coords[14]),
                (coords[8], coords[9]),
                (coords[9], coords[3]),
                (coords[9], coords[15]),
                (coords[9], coords[10]),
                (coords[10], coords[16]),
                (coords[10], coords[4]),
                (coords[10], coords[11]),
                (coords[11], coords[5]),
                (coords[11], coords[17]),
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}
