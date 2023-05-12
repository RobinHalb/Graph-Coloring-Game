using System.Collections.Generic;
using System.Linq;

namespace GraphColoringGame.Graphs
{
    /*
     * A vertex in the graph.
     * coord - the coordinates of the vertex in the graph.
     * color - the color of the vertex.
     * isColored - whether the vertex is colored.
     * neighbours - the neighbors of the vertex in the graph, indexed by the direction in which they are located.
     * directions - the directions in which the vertex has edges.
     * uncoloredCount - the number of uncolored neighbors.
     * availableColors - the list of legal colors for the vertex.
     * isDangerous - whether the vertex is dangerous.
     * isUncolorable - whether the vertex is uncolorable..
     */
    public class Vertex
    {
        public readonly Coord coord;
        public Color color = Color.None;
        public bool isColored => color != Color.None;
        public Dictionary<Direction,Vertex> neighbours = new Dictionary<Direction,Vertex>();
        public IEnumerable<Direction> directions => neighbours.Keys;

        private int uncoloredCount => neighbours.Count(n => !n.Value.isColored);

        private List<Color> _availableColors;
        public List<Color> availableColors { get => UpdateAvailable(); private set => _availableColors = value; }

        public bool isDangerous => !isColored && uncoloredCount >= availableColors.Count;
        public bool isUncolorable => !isColored && availableColors.Count == 0;

        public Vertex(Coord coord, List<Color> availableColors)
        {
            this.coord = coord;
            _availableColors = availableColors.ToList();
        }
        
        /*
         * UpdateAvailable - checs the neighbors of the vertex to update the list of legel colors.
         */
        private List<Color> UpdateAvailable()
        {
            _availableColors.RemoveAll(c => neighbours.Any(n => n.Value.color == c));
            return _availableColors;
        }
    }
}
