﻿using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using GraphColoringGame.Levels.Level1Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level4 : Level
    {
        public Level4() : base() 
        {
            level = 4;
        }

        protected override Graph newGraph() => new Level4Graph().coloredGraph();
        protected override List<ExplanationStep> newExplanation() => new Level4Explanation(graph).GetExplanation();
    }
}
    

