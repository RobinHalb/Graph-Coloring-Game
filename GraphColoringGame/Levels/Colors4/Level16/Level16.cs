﻿using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level16 : Level
    {
        /*
         * Graph showing Alice can use her 4 color winning strategy to win on any tree. 
         * 
         *          0   0
         *          | /
         *      0   0 - 0   
         *      |   |
         *  0 - 0 - 0 - 0 - 0
         *      |   |   
         *      0   0 - 0
         *      |   | \
         *      0   0   0
         */
        public Level16() : base()
        {
            level = 16;
            winning = Player.Alice;
        }

        protected override Graph newGraph() => new Level16Graph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new Level16Explanation(graph).GetExplanation();
    }
}
