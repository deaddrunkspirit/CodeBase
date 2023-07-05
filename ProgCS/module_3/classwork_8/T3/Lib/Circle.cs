using System;

namespace Task3Lib
{
    public class Circle : IFigure
    {
        private int radius;

        public Circle(int radius)
            => this.radius = radius;

        public double Area
            => Math.PI * radius * radius;

        public override string ToString()
            => $"Circle with radius: {radius:g4}";
    }
}