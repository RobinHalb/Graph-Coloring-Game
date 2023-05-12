using GraphColoringGame.Graphs;

namespace GraphColoringGame.Bob
{
    /*
     * The interface representing Bob in the k-coloring game.
     * hasWinning - indicates whether a winning strategy for Bob has been found.
     */
    public interface IBob
    {
        public bool hasWinning { get; }

        /*
         * play - returns Bob's next move.
         */
        (Coord, Color)? play(Graph graph);
    }
}
