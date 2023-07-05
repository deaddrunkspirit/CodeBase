using System;
using Task1Lib;

namespace Task12
{
    public class T12
    {
        public static void Main()
        {
            do
            {
                Console.Clear();

                Function f = new Function(2, 0);
                Console.WriteLine(f);
                f.Transform(2);
                Console.WriteLine(f);

                //ITransform[] iarray = { new Circle(), new Cube(), new Cylinder() };
                //foreach (ITransform obj in iarray)
                //    Report(obj);
                //do
                //{
                //    double newCoefficent = GetDouble();
                //    foreach (ITransform obj in iarray)
                //        obj.Transform(newCoefficent);
                //    foreach (ITransform obj in iarray)
                //        Report(obj);
                //    Console.Beep();
                //    Console.WriteLine("\n\nTo exit press Escape key" +
                //        "\nTo continue changing coefficent press any key . . .");
                //} while (Console.ReadKey().Key != ConsoleKey.Escape);
                Console.Beep();
                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void Report(ITransform g)
            => Console.WriteLine($"Class object data: {g.GetType()}\n{g}");

        private static double GetDouble(string message = "Input coefficent: ",
            double lowerBound = 0, double upperBound = int.MaxValue)
        {
            Console.Write(message);
            double number;
            while (!double.TryParse(Console.ReadLine(), out number)
                || number <= lowerBound || number > upperBound)
                Console.WriteLine
                    ($"Please input real number in ({lowerBound}, {upperBound}]");

            return number;
        }
    }
}