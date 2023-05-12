namespace GraphColoringGame.Graphs
{
    /*
     * The possible directions for a neighbor in a grid.
     */
    public enum Direction : int
    {
        Left,
        Right,
        Up,
        Down,
        UpLeft,
        UpRight,
        DownLeft,
        DownRight,
    }

    public static class DirectionExtension
    {
        /*
         * Opposite - returns the opposing direction.
         */
        public static Direction Opposite(this Direction dir) => dir switch
        {
            Direction.Left => Direction.Right,
            Direction.Right => Direction.Left,
            Direction.Up => Direction.Down,
            Direction.Down => Direction.Up,
            Direction.UpLeft => Direction.DownRight,
            Direction.UpRight => Direction.DownLeft,
            Direction.DownLeft => Direction.UpRight,
            Direction.DownRight => Direction.UpLeft,
            _ => dir
        };

        /*
         * MoveCoord - returns the coordinate neighboring the given coordinate in the direction.
         */
        public static Coord MoveCoord(this Direction dir, Coord coords) => dir switch
        {
            Direction.Left => new Coord(coords.Item1 - 1, coords.Item2),
            Direction.Right => new Coord(coords.Item1 + 1, coords.Item2),
            Direction.Up => new Coord(coords.Item1, coords.Item2 - 1),
            Direction.Down => new Coord(coords.Item1, coords.Item2 + 1),
            Direction.UpLeft => new Coord(coords.Item1 - 1, coords.Item2 - 1),
            Direction.UpRight => new Coord(coords.Item1 + 1, coords.Item2 - 1),
            Direction.DownLeft => new Coord(coords.Item1 - 1, coords.Item2 + 1),
            Direction.DownRight => new Coord(coords.Item1 + 1, coords.Item2 + 1),
            _ => coords
        };
    }
}
