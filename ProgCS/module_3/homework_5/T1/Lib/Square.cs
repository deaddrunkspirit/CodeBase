namespace Task1Lib
{
    public class Square : Figure, IArea
    {
        public Square(double side) : base(side)
        {
        }

        public double Area => Side * Side;

        public override string ToString()
            => $"{base.ToString()}\tArea: {Area:f3}";
    }
}