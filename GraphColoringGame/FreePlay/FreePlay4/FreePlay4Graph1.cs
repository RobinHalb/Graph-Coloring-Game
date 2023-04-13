using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.FreePlay
{
    /// <summary>
    ///     0   0       0           0
    ///     0   0   0   0   0       0   0
    ///     0   0   0   0   0   0   0   0
    ///     0   0   0   0   0   0   0   0
    ///                 0   0   0   0
    /// </summary>
    public class FreePlay4Graph1 :IFreePlay
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green, Color.Yellow });
            Coord[] coords = {
            new Coord(0,0), // coords[0]
            new Coord(1, 0), // 1
            new Coord(3, 0),//2
            new Coord(6, 0),//3
            new Coord(0, 1),//4
            new Coord(1,1), //5
            new Coord(2,1), //6
            new Coord(3,1), //7
            new Coord(4,1), //8
            new Coord(6,1), //9
            new Coord(7,1), //10
            //y = 2
            new Coord(0,2),//11
            new Coord(1,2),//12
            new Coord(2,2),//13
            new Coord(3,2),//14
            new Coord(4,2),//15
            new Coord(5,2),//16
            new Coord(6,2),//17
            new Coord(7,2),//18

            //y=3
            new Coord (0,3),//19
            new Coord(1,3),//21
            new Coord(2,3),//22
            new Coord(3,3),//23
            new Coord(4,3),//24
            new Coord(5,3),//25
            new Coord(6,3),//26
            new Coord(7,3),//27

            //y=4
            new Coord(3, 4),//28
            new Coord(4,4),//29
            new Coord(5,4),//30
            new Coord(6,4),//31
            };

            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[1]),
                (coords[1], coords[5]),
                (coords[5], coords[12]),
                (coords[4], coords[12]),
                (coords[12], coords[7]),
                (coords[12], coords[6]),
                (coords[11], coords[12]),
                (coords[12], coords[19]),
                (coords[12], coords[20]),
                (coords[12], coords[21]),
                (coords[12], coords[13]),
                (coords[13], coords[14]),
                (coords[14], coords[7]),
                (coords[7], coords[2]),
                (coords[14], coords[22]),
                (coords[14], coords[15]),
                (coords[15], coords[8]),
                (coords[15], coords[16]),
                (coords[16], coords[24]),
                (coords[24], coords[23]),
                (coords[24], coords[25]),
                (coords[25], coords[26]),
                (coords[24], coords[29]),
                (coords[29], coords[28]),
                (coords[28], coords[27]),
                (coords[29], coords[30]),
                (coords[16], coords[17]),
                (coords[17], coords[18]),
                (coords[17], coords[9]),
                (coords[9], coords[10]),
                (coords[9], coords[3]),
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}
