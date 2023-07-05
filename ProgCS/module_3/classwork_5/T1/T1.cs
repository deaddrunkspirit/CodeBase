using System;
using System.Collections.Generic;
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

                List<Circle> circles = new List<Circle>();
                FillCircleList(circles);
                circles.Sort((first, second)
                    => first.Center.Distance(new Point(0, 0))
                    .CompareTo
                    (second.Center.Distance(new Point(0, 0))));
                circles.ForEach(x => Console.WriteLine(x));

                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void FillCircleList(List<Circle> circles)
        {
            int countOfCircles = GetInt();
            for (int i = 0; i < countOfCircles; i++)
            {
                Console.WriteLine($"{i + 1} circle:\n\n");
                circles.Add(new Circle(
                      GetDouble("Input x: ", int.MinValue),
                      GetDouble("Input y: ", int.MinValue),
                      GetDouble("Input radius: ")));
                Console.Clear();
                Console.WriteLine($"{i + 1} circle:\n{circles[i]}" +
                    $"\n\nTo continue press any key");
                Console.ReadKey();
            }
        }

        private static int GetInt(string message = "Input count of circles: ",
            int lowerBound = 0, int upperBound = int.MaxValue)
        {
            Console.Write(message);
            int number;
            while (!int.TryParse(Console.ReadLine(), out number) ||
                lowerBound >= number || upperBound < number)
                Console.WriteLine
                    ($"Please input integer number in [{lowerBound}, {upperBound}]");
            return number;
        }

        private static double GetDouble(string message = "Input count of circles: ",
            double lowerBound = 0, double upperBound = int.MaxValue)
        {
            Console.Write(message);
            double number;
            while (!double.TryParse(Console.ReadLine(), out number) ||
                lowerBound > number || upperBound < number)
                Console.WriteLine
                    ($"Please input integer number in [{lowerBound}, {upperBound}]");
            return number;
        }
    }
}