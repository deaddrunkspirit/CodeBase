using System;

namespace Task2Lib
{
    public class Rectangle : IComparable
    {
        public Rectangle(Coords leftUpper, Coords rightLower)
        {
            if (leftUpper.X >= RightLower.X || leftUpper.Y <= rightLower.Y)
                throw new ArgumentException("Wrong coordinates!");
            LeftUpper = leftUpper;
            RightLower = rightLower;
        }

        public Coords LeftUpper { get; private set; }

        public Coords RightLower { get; private set; }

        public double Square
            => Math.Abs(RightLower.X - LeftUpper.X)
            * Math.Abs(LeftUpper.Y - RightLower.Y);

        public int CompareTo(object obj)
            => Square.CompareTo(((Rectangle)obj).Square);

        public override string ToString()
            => $"Rectangle\n\tLeft upper point: {LeftUpper}" +
            $"\n\tRight lower point: {RightLower}";
    }
}