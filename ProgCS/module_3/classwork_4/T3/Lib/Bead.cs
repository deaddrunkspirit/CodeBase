using System;

namespace Task3Lib
{
    public delegate void ChainLenChanged(double r);

    public class Bead
    {
        private double _radius;

        public double Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;
            }
        }

        public Bead(double radius)
        {
            if (radius <= 0)
                throw new ArgumentOutOfRangeException("Radius can't be negative");
            _radius = radius;
        }

        public void OnChainLenChangedHandler(object sender, ChainLenChangedEventArgs e)
        {
            this.Radius = e.Radius;
        }
    }
}