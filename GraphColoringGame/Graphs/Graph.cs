﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace GraphColoringGame.Graphs
{
    public class Graph
    {
        public readonly int xMin, xMax, yMin, yMax;
        public readonly int width;
        public readonly int height;

        private Dictionary<Coord, Vertex> _vertices;
        public IEnumerable<Coord> coords => _vertices.Keys;
        public IEnumerable<(Coord, IEnumerable<Direction>)> connections => _vertices.Select(e => (e.Key, e.Value.directions));
        private List<Vertex> _dangerousVertices;
        public List<Vertex> dangerousVertices => updateDangerous();
        public readonly List<Color> colors;


        // Coords mapped to vertices

        //private Dictionary<int, int[]> neighbours;

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

        public Color getVertexColor(Coord coord)
        {
            var res = _vertices.TryGetValue(coord, out var v);
            if (res) return v.color;
            return Color.None;
        }

        public bool canColor(Coord coord, Color color) => _vertices.TryGetValue(coord, out var v) && v.availableColors.Contains(color);

        public bool colorVertex(Coord coord, Color color)
        {
            if (_vertices.TryGetValue(coord, out var v) && v.availableColors.Contains(color))
            {
                v.color = color;
                return true;
            }
            return false;
        }

        private List<Vertex> updateDangerous()
        {
            _dangerousVertices.RemoveAll(v => !v.isDangerous);
            return _dangerousVertices;
        }

    }
}
