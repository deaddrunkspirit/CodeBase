using System;

namespace Task1Lib
{
    public class RegularQuadrantPyramyd : ITransform
    {
        private double baseSide;

        public double height;

        public void Transform(double coefficent)
        {
            height *= coefficent;
            baseSide *= coefficent;
        }

        public override string ToString()
        {
            double volume = 1 / 3 * baseSide * baseSide * height,
                surfaceArea = Math.Sqrt(Math.Pow(1 / 2 * height, 2)
                            + Math.Pow(height, 2)) * 4 + height * height;
            return $"Regular quadrant pyramyd volume: {volume:g4}" +
                $"\nRegular quadrant pyramid surface area: {surfaceArea:g4}";
        }
    }
}