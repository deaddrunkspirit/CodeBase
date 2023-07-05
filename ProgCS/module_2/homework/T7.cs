using System;

namespace T7
{
    public class MyFunction
    {
        double xmi, xma;

        public MyFunction(double mi, double ma)
        {
            xmi = mi;
            xma = ma;
        }

        public double this[double x] => x < xmi || x > xma ? 0 : Math.Sin(x);

    }

    class Program
    {
        static void Main()
        {
            do
            {
                Console.WriteLine("-----------------");
                Console.WriteLine("-----------------");
                double rmi = -5, rma = 5;
                var sin = new MyFunction(0, Math.PI);
                double s = 0, del = 0.001;
                for (double x = rmi; x < rma; x += del)
                {
                    s += del;
                }
                s *= del;
                Console.WriteLine(s);
                Console.WriteLine("-----------------");
                Console.WriteLine("-----------------");
                Console.WriteLine("To exit press Escape");
                Console.WriteLine("To continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
