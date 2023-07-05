namespace Task1Lib
{
    public class Cube : Figure, IArea, IVolume
    {
        public Cube(double side) : base(side)
        {
        }

        public double Volume => Side * Side * Side;

        public double Area => Side * Side * 6;

        public override string ToString()
            => $"{base.ToString()}\tArea: {Area:f3}\n\tVolume: {Volume:f3}";
    }
}