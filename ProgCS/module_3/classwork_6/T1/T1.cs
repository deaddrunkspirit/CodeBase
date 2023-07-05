using System;
using Task1Lib;

namespace Task1
{
    public class T1
    {
        private static Random rnd = new Random();

        public static void Main()
        {
            do
            {
                Console.Clear();
                var circle = new Circle();
                Report(circle);
                var cube = new Cube();
                Report(cube);
                ITransform shape = circle;
                Report(shape);
                var pyramyd = new RegularQuadrantPyramyd();
                Report(pyramyd);
                pyramyd.Transform(rnd.NextDouble() + 1);
                Console.Beep();
                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        public static void Report(ITransform g)
            => Console.WriteLine($"Class object data: {g.GetType()}\n{g}");
    }
}