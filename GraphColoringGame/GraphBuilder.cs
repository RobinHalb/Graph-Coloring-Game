using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphColoringGame
{
    public class GraphBuilder
    {
        private List<Color> _colors = new List<Color>() {};
        //private Dictionary<int, Vertex> vertices = new Dictionary<int, Vertex>();
        private Dictionary<Coord, Vertex> _vertices = new Dictionary<Coord, Vertex>();
        //private Dictionary<int,Coord> coords = new Dictionary<int,Coord>(); //´<id, x, y>

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
            var graph = new Graph(xMin, xMax, yMin, yMax, _vertices);
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
                v1.neighbours[(int)dir] = v2;
                v2.neighbours[(int)dir.Opposite()] = v1;
                _vertices[coord1] = v1;
                _vertices[coord2] = v2;
                return true;
            }
            return false;
        }

        public IEnumerable<bool> connectVerticesMany(IEnumerable<(Coord, Coord)> pairs) => pairs.Select(p => connectVertices(p.Item1, p.Item2));


        /*{

            var data = new List<(int, int, Direction)>()
            {
                 (1,2,Direction.Right) ,
                 (2,3,Direction.Right) 
            };
        }
        */
        /*
        public void addVertex(int id) => vertices.Add(id, new Vertex(id, _colors));
        public void addVertex(int id, Coord coord)
        {
            if (vertices.ContainsKey(id) || coords.Values.Contains(coord)) return;
            vertices.Add(id, new Vertex(id, _colors));
            coords.Add(id, coord);
        }

        public void addVertices(IEnumerable<int> ids) => ids.ForEach(addVertex);

        /*
        public bool connectVertices(int id1, int id2, Direction dir)
        {
            if (!vertices.TryGetValue(id1, out var v1)) return false;
            if (!vertices.TryGetValue(id2, out var v2)) return false;
            if (v1.neighbours[(int)dir] == null && v2.neighbours[(int)dir.Opposite()] == null)
            {
                v1.neighbours[(int)dir] = v2;
                v2.neighbours[(int)dir.Opposite()] = v1;
                vertices[id1] = v1;
                vertices[id2] = v2;
                return true;
            }
            return false;
        }
        

        public bool connectVertex(int id1, int id2, Direction dir)
        {
            // First vertex doesn't exist, or already has a neighbour in given direction
            if (!vertices.TryGetValue(id1, out var v1) 
                || v1.neighbours[(int)dir] != null  
                || !coords.TryGetValue(id1, out var coord1)) return false;
            
            var coord2 = dir.MoveCoord(coord1);
            // Different vertex already at coordinates, or vertex already located somewhere else
            if (coords.Any(e => (e.Value == coord2 && e.Key != id2) || (e.Key == id2 && e.Value != coord2))) return false;
     
            if (!vertices.TryGetValue(id2, out var v2)) v2 = new Vertex(id2, _colors);
            v1.neighbours[(int)dir] = v2;
            v2.neighbours[(int)dir.Opposite()] = v1;
            vertices[id1] = v1;
            vertices[id2] = v2;
            coords[id2] = coord2;
            return true;
        }

        public bool connectVerticesMany(IEnumerable<(int, int, Direction)> connections) => connections.Select(c => connectVertices(c.Item1, c.Item2, c.Item3)).All(b => b);

       /* bool Connect(Vertex v1, Vertex v2, Direction dir)
        {
            if (v1.neighbours[(int)dir] == null && vertices[id2].neighbours[(int)dir.Opposite()] == null)
            {
                vertices[id1].neighbours[(int)dir] = vertices[id2];
                vertices[id2].neighbours[(int)dir.Opposite()] = vertices[id1];
                return true;
            }
            return false;
        }
       */

    }
}
