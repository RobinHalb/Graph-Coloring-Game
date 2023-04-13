using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;

namespace GraphColoringGame.Levels
{
    /*
     *  0 - 0 - 0 
     */
    public class Level1Graph
    {
        private Coord[] _coords;
        private (Coord, Coord)[] _connections;
        private Graph _graph;

        public Level1Graph()
        {
            _coords = new Coord[] {
                new Coord(0, 0),
                new Coord(1, 0),
                new Coord(2, 0)
            };
            _connections = new (Coord,Coord)[] {
                (_coords[0], _coords[1]),
                (_coords[1], _coords[2])
            };
        }

        public Graph createGraph()
        {
            var builder = new GraphBuilder(new List<Color>() { Color.Red, Color.Blue });
            
            builder.addVertexMany(_coords);
            builder.connectVerticesMany(_connections);
            _graph= builder.build();
            return _graph;
        }

        
    }
}
