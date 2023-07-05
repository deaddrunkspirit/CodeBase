using System;
using System.Collections.Generic;
using Figures;

namespace Task2
{
    public class T2
    {
        public static void Main()
        {
            do
            {
                Console.Clear();
                try
                {
                    TriangleComp triangle = new TriangleComp(
                        new double[]
                        { GetDouble("Input first point x: "),
                    GetDouble("Input second point x: "),
                    GetDouble("Input third point x: ") },
                        new double[]
                        { GetDouble("Input first point y: "),
                    GetDouble("Input second point y: "),
                    GetDouble("Input third point y: ") }
                        );

                    Console.Clear();
                    Console.WriteLine(triangle + "\n");

                    int countOfPoints = GetInt("How many points you want to check: ");
                    List<Point> points = new List<Point>(countOfPoints);
                    for (int i = 0; i < countOfPoints; i++)
                        points.Add(new Point(GetDouble("Input x: "),
                            GetDouble("Input y: ")));
                    Console.WriteLine("Point belongs to triangle?");
                    points.ForEach(point
                        => Console.WriteLine
                        ($"\t{triangle.PointBelongsToTriangle(point)}"));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("\n\nTo exit press Escape key\n" +
                    "To continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        public static double GetDouble(string message = "Input n: ",
            double lowerBound = int.MinValue, double upperBound = int.MaxValue)
        {
            Console.Write(message);
            double number;
            while (!double.TryParse(Console.ReadLine(), out number) ||
                number < lowerBound || number > upperBound)
                Console.WriteLine
                    ($"Please input real number in [{lowerBound}, {upperBound}]");

            return number;
        }

        public static int GetInt(string message = "Input n: ",
            int lowerBound = int.MinValue, int upperBound = int.MaxValue)
        {
            Console.Write(message);
            int number;
            while (!int.TryParse(Console.ReadLine(), out number) ||
                number < lowerBound || number > upperBound)
                Console.WriteLine
                    ($"Please input real number in [{lowerBound}, {upperBound}]");

            return number;
        }
    }
}