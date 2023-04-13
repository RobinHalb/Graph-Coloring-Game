using GraphColoringGame.Graphs;

namespace GraphColoringGame.Bob
{
    public interface IBob
    {
        public bool hasWinning { get; }
        (Coord, Color)? play(Graph graph);
    }
}
