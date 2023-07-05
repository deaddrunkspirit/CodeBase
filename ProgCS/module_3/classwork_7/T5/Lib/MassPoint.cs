namespace Task5Lib
{
    public struct MassPoint
    {
        public PointS Coord { get; private set; }

        public double Mass { get; private set; }

        public MassPoint(PointS point, double mass)
        {
            Coord = point;
            Mass = mass;
        }

        public override string ToString()
            => $"x = {Coord.X:f3}\ty = {Coord.Y:f3}\tmass = {Mass}";
    }
}