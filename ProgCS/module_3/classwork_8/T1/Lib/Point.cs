using System;

namespace Task1
{
    public class Point<T> : IComparable<Point<T>> where T : struct
    {
        public T X { get; }

        public T Y { get; }

        public Point(T x, T y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Squre distance between Point(0, 0) and this Point
        /// </summary>
        public dynamic Distance
            => (dynamic)X * X + (dynamic)Y * Y;

        public int CompareTo(Point<T> other)
            => Distance.CompareTo(other.Distance);

        public override string ToString() =>
            $"Type of coordinates: {typeof(T)}\n" +
            $"X: {X:0.####}\nY: {Y:0.####}\n" +
            $"Distance from (0; 0): {Distance:0.####}\n\n";
    }
}
}