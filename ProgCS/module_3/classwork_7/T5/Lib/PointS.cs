using System;

namespace Task5Lib
{
    public struct PointS : IComparable<PointS>
    {
        public PointS(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; private set; }

        public double Y { get; private set; }

        public int CompareTo(PointS other)
            => Distance(new PointS(0, 0)).CompareTo(other.Distance(new PointS(0, 0)));

        public double Distance(PointS anotherPoint) =>
            Math.Sqrt(Math.Pow(anotherPoint.Y - Y, 2) + Math.Pow(anotherPoint.X - X, 2));

        public override string ToString()
            => $"Point: X = {X:f3}, Y = {Y:f3}";
    }
}