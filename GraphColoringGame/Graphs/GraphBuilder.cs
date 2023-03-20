using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Graphs
{
    public class GraphBuilder
    {
        private List<Color> _colors = new List<Color>() { };
        private Dictionary<Coord, Vertex> _vertices = new Dictionary<Coord, Vertex>();

        public GraphBuilder(List<Color> colors)
        {
            _colors = colors;
        }

        /*
         * createGraph - creates and returns the graph from the provided data.
         */
        public Graph build()
        {
            var xMin = _vertices.Keys.Min(c => c.Item1);
            var xMax = _vertices.Keys.Max(c => c.Item1);
            var yMin = _vertices.Keys.Min(c => c.Item2);
            var yMax = _vertices.Keys.Max(c => c.Item2);
            var graph = new Graph(xMin, xMax, yMin, yMax, _vertices, _colors);
            return graph;
        }

        /*
         * addVertex - adds a new Vertex at the given coordinate.
         */
        public void addVertex(Coord coord) => _vertices.Add(coord, new Vertex(coord, _colors));

        public void addVertexMany(IEnumerable<Coord> coords) => coords.ForEach(addVertex);

        /*
         * connectVertices - connects the vertices at the given coordinates.
         * Returns true if coordinates are nighbours and are successfully connected, otherwise returns false.
         */
        public bool connectVertices(Coord coord1, Coord coord2)
        {
            if (coord1.direction(coord2, out var dir) && _vertices.TryGetValue(coord1, out var v1) && _vertices.TryGetValue(coord2, out var v2))
            {
                v1.neighbours[dir] = v2;
                v2.neighbours[dir.Opposite()] = v1;
                _vertices[coord1] = v1;
                _vertices[coord2] = v2;
                return true;
            }
            return false;
        }

        public IEnumerable<bool> connectVerticesMany(IEnumerable<(Coord, Coord)> pairs)
        {
            var res = new List<bool>();
            foreach (var pair in pairs) res.Add(connectVertices(pair.Item1, pair.Item2));
            return res;
        }

    }
}
