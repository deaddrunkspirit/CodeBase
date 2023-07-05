using System;
using Task1Lib;

namespace Task2
{
    public class T2
    {
        public static void Main()
        {
            do
            {
                Console.Clear();
                var iArray = new ITransform[4];
                ITransform shape = new Circle();
                iArray[0] = shape;
                shape.Transform(3);
                iArray[1] = shape;
                shape = Mapping(new Cube(), 2);
                iArray[2] = shape;
                iArray[3] = new Circle();
                foreach (ITransform obj in iArray)
                    Report(obj);
                Console.Beep();
                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        public static ITransform Mapping(ITransform g, double number)
        {
            g.Transform(number);
            return g;
        }

        private static void Report(ITransform g)
            => Console.WriteLine($"Class object data: {g.GetType()}\n{g}");
    }
}