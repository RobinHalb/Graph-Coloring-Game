using GraphColoringGame.Explanation;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels.Level1Content
{
    class Level1Explanation
    {
        private Coord[] _coords;
        private IEnumerable<(Coord, IEnumerable<Direction>)> _connections;

        public Level1Explanation(Graph graph)
        {
            _connections = graph.connections;

            _coords = new Coord[] {
                new Coord(0, 0),
                new Coord(1, 0),
                new Coord(2, 0)
            };
        }

        public List<ExplanationStep> GetExplanation() => new List<ExplanationStep>()
        {
            step1(),
            step2()
        };

        private Dictionary<Coord, ExplanationVertex> newVertices()
        {
            var vertices = new Dictionary<Coord, ExplanationVertex>();
            foreach (var (coord, dirs) in _connections)
                vertices.Add(coord, new ExplanationVertex(dirs));
            return vertices;
        }

        public ExplanationStep step1()
        {
            var text = "Explanation step 1";
            var vertices = newVertices();
            // Set colors

            return new ExplanationStep(text, vertices);
        }

        public ExplanationStep step2()
        {
            var text = "Explanation step 2";
            var vertices = newVertices();
            // Set colors
            vertices[_coords[0]].color = Color.Red;

            return new ExplanationStep(text, vertices);
        }
    }
}
