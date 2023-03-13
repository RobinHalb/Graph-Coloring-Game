using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Graphs
{
    public class Vertex
    {
        //public readonly int id;
        public readonly Coord coord;
        public Color color = Color.None;
        public bool isColored => color != Color.None;
        public Dictionary<Direction,Vertex> neighbours = new Dictionary<Direction,Vertex>();
        //public Vertex[] neighbours = new Vertex[8];
        //public IEnumerable<Direction> directions() => neighbours.Select<Vertex, int?>((v, i) => v != null ? i : null).Where(d => d != null).Cast<Direction>();
        public IEnumerable<Direction> directions => neighbours.Keys;

        private int uncoloredCount => neighbours.Count(n => !n.Value.isColored);

        private List<Color> _availableColors;
        public List<Color> availableColors { get => UpdateAvailable(); private set => _availableColors = value; }

        public bool isDangerous => uncoloredCount >= availableColors.Count;

        public Vertex(Coord coord, List<Color> availableColors)
        {
            this.coord = coord;
            _availableColors = availableColors;
        }

        private List<Color> UpdateAvailable()
        {
            _availableColors.RemoveAll(c => neighbours.Any(n => n.Value.color == c));
            return _availableColors;
        }
    }
}
