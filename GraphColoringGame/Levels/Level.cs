using GraphColoringGame.Explanations;
using GraphColoringGame.Graphs;
using System.Collections.Generic;

namespace GraphColoringGame.Levels
{
    /*
     * A level with a graph and an explanation.
     * graph - the graph belonging to the level.
     * explanation - the list of ExplanationSteps explaining the level.
     * level - the number of the level.
     * winning - the player who has a winning strategy in the level.
     */
    public abstract class Level
    {
        public Graph graph { get; protected set; }
        public List<ExplanationStep> explanation { get; protected set; }

        public int level { get; protected set; }
        public Player winning { get; protected set; } = Player.Alice;

        public Level()
        {
            graph = newGraph();
            explanation = newExplanation();
        }

        /*
         * reset - creates a new graph to reset start over.
         */
        public void reset() => graph = newGraph();

        /*
         * newGraph - returns a new instance of the graph belonging to the level.
         */
        protected abstract Graph newGraph();

        /*
         * newExplanation - returns a new instance of the explanation belonging to the level.
         */
        protected abstract List<ExplanationStep> newExplanation();
    }
}
