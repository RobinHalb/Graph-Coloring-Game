using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels.Level_1
{
    public abstract class LevelGraph
    {
        private List<Color> colors = new List<Color>() { Color.Red, Color.Blue };
        private Dictionary<int, Vertex> vertices = new Dictionary<int, Vertex>();


        public abstract Graph CreateGraph();
        /*{

            var data = new List<(int, int, Direction)>()
            {
                 (1,2,Direction.Right) ,
                 (2,3,Direction.Right) 
            };
        }
        */


        virtual protected Dictionary<int, Vertex> CreateVertices()
        {
            /*
             * Create vertices
             */
            var vertices = new Dictionary<int, Vertex>();

            /*
             * Connect vertices
             */

            return vertices;
        }

        protected bool ConnectVertices(int id1, int id2, Direction dir)
        {
            if (!vertices.TryGetValue(id1, out var v1)) return false;
            if (!vertices.TryGetValue(id2, out var v2)) return false;
            if (v1.neighbours[(int)dir] == null && v2.neighbours[(int)dir.Opposite()] == null)
            {
                v1.neighbours[(int)dir] = v2;
                v2.neighbours[(int)dir.Opposite()] = v1;
                vertices[id1] = v1;
                vertices[id2] = v2;
                return true;
            }
            return false;
        }
       /* bool Connect(Vertex v1, Vertex v2, Direction dir)
        {
            if (v1.neighbours[(int)dir] == null && vertices[id2].neighbours[(int)dir.Opposite()] == null)
            {
                vertices[id1].neighbours[(int)dir] = vertices[id2];
                vertices[id2].neighbours[(int)dir.Opposite()] = vertices[id1];
                return true;
            }
            return false;
        }
       */

    }
}
