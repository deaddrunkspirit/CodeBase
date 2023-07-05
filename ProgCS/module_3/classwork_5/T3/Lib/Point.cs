using System;

namespace Task3Lib
{
    public class Point
    {
        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X { get; private set; }

        public double Y { get; private set; }

        public double Z { get; private set; }

        public double Distance(Point point)
            => Math.Sqrt(Math.Pow(point.X - X, 2) + Math.Pow(point.Y - Y, 2) +
                Math.Pow(point.Z - Z, 2));

        public override string ToString()
            => $"Point: x = {X}, y = {Y}, z = {Z}";
    }
}