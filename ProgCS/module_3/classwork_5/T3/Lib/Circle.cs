namespace Task3Lib
{
    public class Circle
    {
        public Circle(double x, double y, double z, double radius)
        {
            Center = new Point(x, y, z);
            Radius = radius;
        }

        public Point Center { get; private set; }

        public double Radius { get; private set; }

        public override string ToString()
            => $"Circle\n\tCenter: {Center}\n\t\tRadius: {Radius:3}";
    }
}