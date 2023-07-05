namespace Task3Lib
{
    public class Square : IFigure
    {
        private double side;

        public Square(double side)
            => this.side = side;

        public double Area
            => side * side;

        public override string ToString()
            => $"Square with side: {side:g4}";
    }
}