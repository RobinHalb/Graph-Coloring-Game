using GraphColoringGame.Graphs;

namespace GraphColoringGame.Bob
{
    public interface IBob
    {
        (Coord, Color)? play(Graph graph);
    }
}
