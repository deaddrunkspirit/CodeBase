using System;
using Task5Lib;

namespace Task5
{
    public class T5
    {
        private static Random gen = new Random(0);

        public static void Main()
        {
            MassPoint[] elements;
            do
            {
                Console.Clear();

                elements = new MassPoint[GetInt()];
                for (int i = 0; i < elements.Length; i++)
                {
                    elements[i] = new MassPoint(new PointS(gen.Next(-10, 11),
                        gen.Next(-10, 11)), gen.Next(1, 6));
                    Console.WriteLine(elements[i]);
                }
                SetOfMassPoint real;
                do
                {
                    Console.Clear();

                    double radius = GetDouble();
                    real = new SetOfMassPoint(elements, new PointS(0, 0), radius);
                    Console.WriteLine($"{real}\n{real.MassCenter}" +
                        $"\n\nTo exit press Escape key" +
                        "\nTo continue press any key . . .");
                    Console.Beep();
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
                Console.Beep();
                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static int GetInt(string message = "Input count of points: ",
            int lowerBound = 1, int upperBound = int.MaxValue)
        {
            int number;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out number)
                || number < lowerBound || number > upperBound)
                Console.WriteLine
                    ($"Please input integer number in [{lowerBound}, {upperBound}]");
            return number;
        }

        private static double GetDouble(string message = "Input set radius: ",
            int lowerBound = 0, int upperBound = int.MaxValue)
        {
            double number;
            Console.Write(message);
            while (!double.TryParse(Console.ReadLine(), out number)
                || number < lowerBound || number > upperBound)
                Console.WriteLine
                    ($"Please input integer number in ({lowerBound}, {upperBound}]");

            return number;
        }
    }
}