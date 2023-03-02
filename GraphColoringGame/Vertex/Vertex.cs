using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphColoringGame;

namespace GraphColoringGame
{
    public class Vertex
    {
        public readonly int id;
        public Color? color;
        public bool isDangerous { get; private set; }
        public List<Color> availableColors { get; private set; }
        public Dictionary<Direction, Vertex> uncoloredNeighbours { get; private set; }
        public Dictionary<Direction, Vertex> coloredNeighbours { get; private set; }

        public Vertex(int id)
        {
            this.id = id;
        }

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

    }
}
