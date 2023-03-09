﻿using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame
{
    public class Graph
    {
        public readonly int xMin, xMax, yMin, yMax;
        public readonly int width;
        public readonly int height;

        private Dictionary<Coord, Vertex> _vertices;
        private List<Vertex> _dangerousVertices;
        public List<Vertex> dangerousVertices => UpdateDangerous();
        // Coords mapped to vertices

        //private Dictionary<int, int[]> neighbours;

        public Graph(int xMin, int xMax, int yMin, int yMax, Dictionary<Coord, Vertex> vertices) 
        {
            this.xMin = xMin;
            this.xMax = xMax;
            this.yMin = yMin;
            this.yMax = yMax;
            this.width = xMax - xMin;
            this.height = yMax - yMin;
            _vertices = vertices;
            _dangerousVertices = vertices.Values.Where(v => v.isDangerous).ToList();
        }

        public bool Color(Coord coord, Color color)
        {
            if (_vertices.TryGetValue(coord, out var v))
            {
                v.color = color;
                return true;
            }
            return false;
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
