using System;

namespace Task1Lib
{
    public class Circle : ITransform
    {
        public double Radius { get; private set; } = 1;

        public double Area => Math.PI * Radius * Radius;

        public void Transform(double coefficent)
            => Radius *= coefficent;

        public override string ToString()
            => $"Circle area: {Area:g4}";
    }
}