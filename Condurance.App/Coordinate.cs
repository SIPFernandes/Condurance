namespace Condurance.App
{
    public class Coordinate : IEquatable<Coordinate?>
    {
        public int X { get; }
        public int Y { get; }
        public Coordinate(int x, int y) 
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X}:{Y}";
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Coordinate);
        }

        public bool Equals(Coordinate? other)
        {
            return other is not null &&
                   X == other.X &&
                   Y == other.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
