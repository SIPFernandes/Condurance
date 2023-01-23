namespace Condurance.App.Services.Interfaces
{
    public interface IGrid
    {
        public int MaxX { get; }
        public int MaxY { get; }
        public HashSet<Coordinate> ObstaclesHash { get; }
    }
}
