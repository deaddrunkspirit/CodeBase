using System;

namespace Task1Lib
{
    public class Triangle : Figure, IArea
    {
        public Triangle(double side) : base(side)
        {
        }

        public double Area
            => Math.Sqrt(3 * Side / 2 * Math.Pow(3 * Side / 2 - Side, 3));

        public override string ToString()
            => $"{base.ToString()}\tArea: {Area:f3}";
    }
}