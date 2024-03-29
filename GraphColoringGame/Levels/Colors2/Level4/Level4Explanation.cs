﻿using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System.Collections.Generic;

namespace GraphColoringGame.Levels
{
    /*
     * Graph is a P_4+, Alice cannot win with only 2 colors.
     * 
     *          0
     *          |
     *  0 - 0 - 0 - 0 
     */
    public class Level4Explanation : LevelExplanation
    {
        private Coord[] coords;

        public Level4Explanation(Graph graph) : base(graph)
        {
            coords = new Coord[]{
            new Coord(0,1),  //coords[0]
            new Coord(1, 1), //1
            new Coord(2, 1), //2
            new Coord(3, 1), //3
            new Coord(2, 0), //4
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
            var text = "In this graph of five vertices, the longest path contains four vertices (shown green). \n\nThis time, Bob has a winning strategy.";
            var vertices = newVertices();

            vertices[coords[0]].outline = green;
            vertices[coords[1]].outline = green;
            vertices[coords[2]].outline = green;
            vertices[coords[4]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step2()
        {
            var text = "In the 2-coloring game, a path of four vertices contains two dangerous vertices (shown purple).";
            var vertices = newVertices();

            vertices[coords[0]].outline = green;
            vertices[coords[1]].outline = purple;
            vertices[coords[2]].outline = purple;
            vertices[coords[4]].outline = green;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step3()
        {
            var text = "Much like in level 2, any vertex which Alice colors will leave behind one dangerous vertex with only one available color remaining (shown purple).";
            var vertices = newVertices();

            vertices[coords[2]].outline = purple;
            vertices[coords[4]].color = Color.Red;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }

        public ExplanationStep step4()
        {
            var text = "Using the same strategy from level 2, Bob colors a neighbor of the dangerous vertex with the remaining color to win. \n\nBecause this strategy simply needs four vertices in a line, Bob can win the 2-coloring game on any tree where the longest path is at least four.";
            var vertices = newVertices();

            vertices[coords[1]].color = Color.Blue;
            vertices[coords[4]].color = Color.Red;
            vertices[coords[2]].outline = black;

            return new ExplanationStep(text, vertices, colors, width, height, xMin, yMin);
        }
    }
}
