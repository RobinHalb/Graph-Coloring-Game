using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame
{
    public class Graph
    {
        public readonly int width;
        public readonly int height;
        private Dictionary<int, Vertex> vertices;
        private List<int> dangerousVertices;
        private Dictionary<int, int[]> neighbours;

        public void Color(int id, Color color)
        {
            if (vertices.TryGetValue(id, out var v))
            {
                v.color = color;
                var nb = neighbours[id];
                for (int i = 0; i < nb.Length; id++)
                {
                    if (nb[i] != null)
                    {
                        Update(nb[i], color);
                    }
                }
                foreach (int nid in neighbours[id])
                {
                    if (nid != null) Update(nid, color);
                }

            }
        }
        // updates neighbors + dangerous
        private void Update(int id, Color color)
        {
            vertices[id].availableColors.Remove(color);
        }

        // method for uncolored vertecies count (for dangerous)
    }
}
