using System;
using Task1Lib;

namespace Task1
{
    public class T1
    {
        public static void Main()
        {
            do
            {
                Console.Clear();

                double x = GetDouble(), y = GetDouble("Input y: ");
                Dot dot = new Dot(x, y);
                Dot.OnCoordChanged += PrintInfo;
                Dot.DotFlow(dot);

                Console.WriteLine("To exit press Escape key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void PrintInfo(Dot dot)
        {
            Console.WriteLine($"Coordinates are:\n\tx = {dot.X}\n\ty = {dot.Y}");
        }

        private static double GetDouble(string message = "Input x: ",
            double lower = double.MinValue, double upper = double.MaxValue)
        {
            double number;
            Console.Write(message);
            while (!double.TryParse(Console.ReadLine(), out number) 
                || number < lower || number > upper)
                Console.WriteLine($"Please input real number in [{lower}, {upper}]");
            return number;
        }
    }
}
