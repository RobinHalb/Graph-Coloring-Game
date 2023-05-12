using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Graphs
{
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
        
        private List<Color> UpdateAvailable()
        {
            _availableColors.RemoveAll(c => neighbours.Any(n => n.Value.color == c));
            return _availableColors;
        }
    }
}
