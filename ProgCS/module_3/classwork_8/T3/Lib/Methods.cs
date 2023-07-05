using System;

namespace Task3Lib
{
    public class Methods
    {
        public static void GreaterAreaInfo<F>(F[] mass, double border) where F : IFigure
            => Array.ForEach(mass, el =>
            {
                if (el.Area > border)
                    Console.WriteLine($"{el}");
            });
    }
}