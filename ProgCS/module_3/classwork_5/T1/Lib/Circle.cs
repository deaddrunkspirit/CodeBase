using System;

namespace Task1Lib
{
    public class Circle
    {
        private Point _center;

        private double _radius;

        public Circle(double x, double y, double radius)
        {
            _center = new Point(x, y);
            Radius = radius;
        }

        public Point Center => _center;

        public double Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public override string ToString()
            => $"Circle\nCenter coordinates: X = {_center.X:f3}, Y = {_center.Y:f3}" +
            $"\nRadius = {_radius:f3}";
    }
}