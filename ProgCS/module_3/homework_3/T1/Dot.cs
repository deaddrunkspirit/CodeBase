using System;

namespace Task1Lib
{
    public delegate void CoordChanged(Dot dot);

    public class Dot
    {
        private static Random rnd = new Random();

        public Dot(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; private set; }

        public double Y { get; private set; }

        public static event CoordChanged OnCoordChanged;
        
        public static void DotFlow(Dot dot)
        {
            for (int i = 0; i < 11; i++)
            {
                X = rnd.Next(-10, 10) + rnd.NextDouble();
                Y = rnd.Next(-10, 10) + rnd.NextDouble();
                if (X < 0 && Y < 0)
                    OnCoordChanged(dot);
            }
        }

    }
}
