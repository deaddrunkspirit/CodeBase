namespace Task2Lib
{
    public struct Coords
    {
        public double X { get; private set; }

        public double Y { get; private set; }

        public Coords(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
            => $"Point({X}, {Y})";
    }
}