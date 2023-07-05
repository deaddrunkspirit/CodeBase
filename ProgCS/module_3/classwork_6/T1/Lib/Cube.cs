namespace Task1Lib
{
    public class Cube : ITransform
    {
        private double rib = 1;

        public void Transform(double coefficent)
            => rib *= coefficent;

        public override string ToString()
            => $"Cube volume: {rib * rib * rib:g4}";
    }
}