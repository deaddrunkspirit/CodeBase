using System;

namespace Task1Lib
{
    public class Function : ITransform
    {
        private readonly double k;

        private double b;

        public Function(double k, double b)
        {
            this.k = k;
            this.b = b;
        }

        public void Transform(double coefficent)
        {
            b -= coefficent * k;
        }

        public override string ToString()
            => k == 0 ? $"y = {b:g3}" : b == 0 ? $"y = {k:g3}x"
            : b < 0 ? $"y = {k:g3}x - {Math.Abs(b):g3}" : $"y = {k:g3}x + {b:g3}";
    }
}