using System;
using Task3Lib;

namespace Task3
{
    public class T3
    {
        public static void Main()
        {
            do
            {
                Console.Clear();

                ISeries pell = new Pell(), luke = new Luke(), fibonacci = new Fibonacci();
                Console.WriteLine("First part of the task:");
                PrintSeries(9, pell);
                Console.WriteLine($"pell[3] = {pell[3]}");
                PrintSeries(4, pell);
                PrintSeries(3, pell);
                Console.WriteLine("\nSecond part:\n");
                pell.SetBegin();
                int numberOfElements = GetInt();
                Console.Write("Pell:\t\t");
                PrintSeries(numberOfElements, pell);
                Console.WriteLine();
                Console.Write("Fibonacci:\t");
                PrintSeries(numberOfElements, fibonacci);
                Console.WriteLine();
                Console.Write("Luke:\t\t");
                PrintSeries(numberOfElements, luke);
                Console.WriteLine();

                Console.Beep();
                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static int GetInt(string message = "Input index of last element: ",
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

        private static void PrintSeries(int countOfElements, ISeries series)
        {
            for (int i = 0; i < countOfElements; i++)
                Console.Write($"{series.GetNext}\t");
            Console.WriteLine();
        }
    }
}