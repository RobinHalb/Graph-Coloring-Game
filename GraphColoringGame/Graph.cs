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
        private List<Vertex> _dangerousVertices;
        public List<Vertex> dangerousVertices => UpdateDangerous();
        // Coords mapped to vertices

        //private Dictionary<int, int[]> neighbours;

        public Graph(int width, int height, Dictionary<int, Vertex> vertices) 
        {
            this.width = width;
            this.height = height;
            this.vertices = vertices;
            _dangerousVertices = vertices.Values.Where(v => v.isDangerous).ToList();
        }

        public void Color(int id, Color color)
        {
            if (vertices.TryGetValue(id, out var v))
            {
                v.color = color;
                //var nb = neighbours[id];
                /*
                for (int i = 0; i < nb.Length; id++)
                {
                    if (nb[i] != 0)
                    {
                        Update(nb[i], color);
                    }
                }
                foreach (int nid in neighbours[id])
                {
                    if (nid != 0) Update(nid, color);
                }
                */
            }
        }

        private List<Vertex> UpdateDangerous()
        {
            _dangerousVertices.RemoveAll(v => !v.isDangerous);
            return _dangerousVertices;
        }

        /*
        // updates a neighbor + isdangerous
        private void Update(int id, Color color)
        {
            vertices[id].availableColors.Remove(color);
            // if available colors && uncolored neighbor count is equal or less:
            if (vertices[id].isDangerous) {
                dangerousVertices.Add(id);
            }
        }
        */
        // method for uncolored vertecies count (for dangerous)
        /*    
            private int CountUncolored(int id)
            {
                if (neighbours.TryGetValue(id, out var nb))
                {
                    return nb.Count(nid => vertices.ContainsKey(nid) && vertices[nid].isColored);
                }
                return 0;
            }
        */

    }
}
