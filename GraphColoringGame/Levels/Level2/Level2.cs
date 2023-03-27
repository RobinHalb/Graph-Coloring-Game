﻿using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringGame.Levels
{
    public class Level2 : Level
    {
        public Level2(): base() 
        {
            level = 2;
        }

        protected override Graph newGraph() => new Level2Graph().createGraph();
        protected override List<ExplanationStep> newExplanation() => new Level2Explanation(graph).GetExplanation();


}
}
