using System;

namespace Task2Lib
{
    public class Circle
    {
        public Circle(double radius, Coords center)
        {
            if (radius <= 0)
                throw new ArgumentException("Radius can't be negative!");
            Radius = radius;
            Center = center;
        }

        public Circle(double radius, double x, double y)
        {
            if (radius <= 0)
                throw new ArgumentException("Radius can't be negative!");
            Radius = radius;
            Center = new Coords(x, y);
        }

        public double Radius { get; private set; }

        public Coords Center { get; private set; }

        public override string ToString()
            => $"Circle\n\tCenter: {Center}\n\tRadius = {Radius:g4}";
    }
}