namespace Task1Lib
{
    public abstract class Figure
    {
        protected Figure(double side)
        {
            Side = side;
        }

        public double Side { get; private set; }

        public override string ToString()
            => $"Figure {this.GetType().Name}:\n";
    }
}