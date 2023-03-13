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
        public Vertex[] neighbours = new Vertex[8];
        public IEnumerable<Direction> directions() {
            var dirs = new List<Direction>();
            for (int i = 0; i < 8; i++) if (neighbours[i] != null) dirs.Add((Direction)i);
            //var a = neighbours.Select<Vertex, int?>((v, i) => v != null ? i : null);
            //var b = a.Where(d => d != null);
            //var c = b.Cast<Direction>();
            return dirs;
        }
        private int uncoloredCount => neighbours.Count(n => !n?.isColored ?? true);

        private List<Color> _availableColors;
        public List<Color> availableColors => UpdateAvailable();

        public bool isDangerous => uncoloredCount >= availableColors.Count;
        //public Dictionary<Direction, Vertex> uncoloredNeighbours { get; private set; }
        //public Dictionary<Direction, Vertex> coloredNeighbours { get; private set; }
        /*
        public Vertex(int id, List<Color> availableColors)
        {
            this.id = id;
            _availableColors = availableColors;
        }*/
        public Vertex(Coord coord, List<Color> availableColors)
        {
            this.coord = coord;
            _availableColors = availableColors;
        }

        private List<Color> UpdateAvailable()
        {
            _availableColors.RemoveAll(c => neighbours.Any(n => n?.color == c));
            return _availableColors;
        }

        /*
        public void Color(Color color)
        {
            if (this.color == null && availableColors.Contains(color))
            {
                this.color = color;
                availableColors.Remove(color);
                foreach (KeyValuePair<Direction,Vertex> neighbour in uncoloredNeighbours)
                {
                    neighbour.Value.Update(neighbour.Key.Opposite());
                }
            }
        }

        public void Update(Direction dir) 
        { 
            if (uncoloredNeighbours.TryGetValue(dir, out var neighbour) &&
                availableColors.Contains((Color)neighbour.color))
            {
                availableColors.Remove((Color)neighbour.color);
            }
            coloredNeighbours.Add(dir, neighbour);
            uncoloredNeighbours.Remove(dir);
            isDangerous = uncoloredNeighbours.Count >= availableColors.Count;
        }
        */
    }
}
