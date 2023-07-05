using System;
using System.Collections.Generic;
using System.Text;

namespace Task2Lib
{
    public class Circle
    {
        public Circle(Dot center, double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Radius can't be negative or 0");
            Center = center;
            Radius = radius;
        }

        public Dot Center { get; private set; }

        public double Radius { get; private set; }

        public double xMax => Center.X + Radius;

        public double xMin => Center.X - Radius;

        public override string ToString()
            => $"Circle\nCenter: {Center}\nMax x: {xMax:f3}\nMin x: {xMin:f3}";
    }
}