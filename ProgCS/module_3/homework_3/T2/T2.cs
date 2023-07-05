using System;
using Task2Lib;

namespace Task2
{
    public class T2
    {
        public static void Main()
        {
            do
            {
                Console.Clear();

                double x1 = GetDouble("Input upper left corner x: "),
                    y1 = GetDouble("Input upper left corner y: "),
                    x2 = GetDouble("Input lower right corner x: "),
                    y2 = GetDouble("Input lower right corner y: ");
                Square square = new Square(x1, y1, x2, y2);
                Square.OnSizeChanged += SquareConsoleInfo;
                Console.WriteLine($"Square side: {square.Side}");

                do
                {
                    Console.Clear();

                    square.X2 = GetDouble("Input right lower corner x: ");
                    square.Y2 = GetDouble("Input right lower corner y: ");

                    Console.WriteLine("\n\nTo end cycle press Escape key" +
                        "\nTo continue press any key . . .");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);

                Console.WriteLine("To exit press Escape key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void SquareConsoleInfo(double number) { Console.WriteLine($"{number:f2}"); }

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
