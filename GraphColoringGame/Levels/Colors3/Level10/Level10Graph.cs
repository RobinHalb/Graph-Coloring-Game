using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    /*
     *  0 - 0
     *      |
     *      0   0   0   0   0
     *      |   |   |   |   |
     *      0 - 0 - 0 - 0 - 0 - 0
     *          |   |   |   |
     *          0   0   0   0
     */
    public class Level10Graph
    {
        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue, Color.Green });
            Coord[] coords = {
            new Coord(0, 0), //0
            new Coord(1, 0), //1
            new Coord(1, 1), //2
            new Coord(2,1), // 3
            new Coord(3, 1), // 4
            new Coord(4, 1), //5
            new Coord(5,1),//6
            new Coord(1,2),
            new Coord(2, 2),//7
            new Coord(3, 2),//8
            new Coord(4, 2),//9
            new Coord(5, 2),//10
            new Coord(6,2), // 11
            new Coord(2,3),// 12
            new Coord(3,3), //13
            new Coord(4,3), //14
            new Coord (5,3), //15
            };



            builder.addVertexMany(coords);

            (Coord, Coord)[] connections = {
                (coords[0], coords[1]),
                (coords[1], coords[2]),
                (coords[2], coords[7]),
                (coords[7], coords[8]),
                (coords[8], coords[3]),
                (coords[8], coords[9]),
                (coords[8], coords[13]),
                (coords[9], coords[4]),
                (coords[9], coords[14]),
                (coords[9], coords[10]),
                (coords[10], coords[5]),
                (coords[10], coords[15]),
                (coords[10], coords[11]),
                (coords[11], coords[6]),
                (coords[11], coords[12]),
                (coords[11], coords[16]),
            };
            builder.connectVerticesMany(connections);

            return builder.build();
        }
    }
}
