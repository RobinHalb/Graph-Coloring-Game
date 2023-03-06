using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels.Level_1
{
    public class Level1Graph : LevelGraph
    {
        private List<Color> colors = new List<Color>() { Color.Red, Color.Blue };
        

        public override Graph CreateGraph()
        {
            var vertices = CreateVertices();
            return new Graph(3, 1, vertices);
        }

        protected override Dictionary<int, Vertex> CreateVertices()
        {
            /*
             * Create vertices
             */
            var vertices = new Dictionary<int, Vertex>()
            {
                {1, new Vertex(1, colors)},
                {2, new Vertex(2, colors)},
                {3, new Vertex(3, colors)},
            };


            /*
             * Connect vertices
             */
            Connect(1, 2, Direction.Right);
            Connect(2, 3, Direction.Right);
            

            return vertices;
        }
      
    }
}
