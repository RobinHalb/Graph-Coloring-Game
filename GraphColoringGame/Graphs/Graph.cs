using System.Collections.Generic;
using System.Linq;

namespace GraphColoringGame.Graphs
{
    /*
     * A graph used to play the game.
     * Min, xMax, yMin, yMax - the minimum and maximum coordinates of the graph.
     * width, height - the width and height of the graph as a grid.
     * coords - the list of coordinates containing vertices in the graph.
     * vertices - the list of vertices in the graph.
     * connections - the list of coordinates and directions where a vertices have edges.
     * dangerousVertices - the list of dangerous vertices in the graph.
     * colors - the list of colors used available for the graph.
     * winner - the winning player.
     * isDone - checks whether either player has won.
     */
    public class Graph
    {
        public readonly int xMin, xMax, yMin, yMax;
        public readonly int width, height;

        private Dictionary<Coord, Vertex> _vertices;
        public IEnumerable<Coord> coords => _vertices.Keys;
        public IEnumerable<Vertex> vertices => _vertices.Values;
        public IEnumerable<(Coord, IEnumerable<Direction>)> connections => _vertices.Select(e => (e.Key, e.Value.directions));
        private List<Vertex> _dangerousVertices;
        public List<Vertex> dangerousVertices => updateDangerous();
        public readonly List<Color> colors;
        public Player? winner { get; private set; }
        public bool isDone => winner != null;

        public Graph(int xMin, int xMax, int yMin, int yMax, Dictionary<Coord, Vertex> vertices, List<Color> colors)
        {
            this.xMin = xMin;
            this.xMax = xMax;
            this.yMin = yMin;
            this.yMax = yMax;
            this.width = xMax - xMin + 1;
            this.height = yMax - yMin + 1;
            this.colors = colors;
            _vertices = vertices;
            _dangerousVertices = vertices.Values.Where(v => v.isDangerous).ToList();
        }

        /*
         * getVertexColor - returns the color of the vertex at the given coordinates.
         */
        public Color getVertexColor(Coord coord)
        {
            var res = _vertices.TryGetValue(coord, out var v);
            if (res) return v.color;
            return Color.None;
        }
        
        /*
         * canColor - returns true if a vertex exists at the given coordinates which can be colored with the given color.
         */
        public bool canColor(Coord coord, Color color) => _vertices.TryGetValue(coord, out var v) && v.availableColors.Contains(color);

        /*
         * colorVertex - colors the vertex at the given coordinates with the given color, if possible, and returns true if successful.
         */
        public bool colorVertex(Coord coord, Color color)
        {
            if (isDone) return false;
            if (_vertices.TryGetValue(coord, out var v) && v.availableColors.Contains(color))
            {
                v.color = color;
                checkIfDone();
                return true;
            }
            return false;
        }

        /*
         * updateDangerous - removes non-dangerous vertices from the list of dangerous vertices.
         */
        private List<Vertex> updateDangerous()
        {
            _dangerousVertices.RemoveAll(v => !v.isDangerous);
            return _dangerousVertices;
        }

        /*
         * checkIfDone - checks whether the graph is either colored or uncolorable, and updates winner accordingly.
         */
        private void checkIfDone()
        {
            if (winner != null) return;
            if (dangerousVertices.Any(v => v.isUncolorable)) winner = Player.Bob;
            else if (_vertices.Values.All(v => v.isColored)) winner = Player.Alice;
            
        }
    }
}
