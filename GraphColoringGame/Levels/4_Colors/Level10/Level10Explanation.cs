using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level10Explanation : LevelExplanation
    {
            private Coord[] coords;

        public Level10Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[] {
            new Coord(3,0), // coords[0]
            new Coord(0, 1), // 1
            new Coord(1, 1),//2
            new Coord(2, 1),//3
            new Coord(3, 1),//4
            new Coord(4,1), //5
            new Coord(1,2), //6
            new Coord(2,2),
            new Coord(1,3),
            new Coord(3,3),
            new Coord(4,4),
          };
        }

        public List<ExplanationStep> GetExplanation() => new List<ExplanationStep>()
        {
                step1(),
                step2(),
                step3(),
                step4(),
        };

        public ExplanationStep step1()
        {
            var text = "Alice can win graphs with 4 colors, if she does not make a mistake. On graphs with four colors, the strategy is a little different than with 3 colors..";
            var vertices = newVertices();
            vertices[coords[1]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[9]].color = Color.Green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2() 
        {
            var text = "...using trunks. A trunk is a subgraph, where every colored vertex in it is a leaf, like the graph in this level. \n" +
                "An uncolored vertex will appear in exactly one trunk. A colored vertex will appear in as many trunks as it has neighbors.";
            var vertices = newVertices();
            vertices[coords[1]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[9]].color = Color.Green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);

        }

        public ExplanationStep step3() 
        {
            var text = "To split this trunk, Alice needs to identify a vertex with the degree of at least three as there are currently three colored vertices in this trunk." +
                "After Alice has colored this vertex with some color the graph will split into three different trunks.";
            var vertices = newVertices();
            vertices[coords[1]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[9]].color = Color.Green;
            vertices[coords[3]].outline = green;

            return new ExplanationStep(text, vertices, colors ,width, height, xMin, yMin);
        
        }

        public ExplanationStep step4() 
        {
            var text = "The new trunks are the following: \n" +
                "";
            var vertices = newVertices();
            vertices[coords[1]].color = Color.Red;
            vertices[coords[5]].color = Color.Blue;
            vertices[coords[9]].color = Color.Green;

            vertices[coords[3]].color = Color.Red;
            vertices[coords[3]].outline = green;
            

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
    }
