using System;
using System.Collections.Generic;
using System.IO;
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
                string path = @"..\..\..\MyTest.txt";
                int numberOfElements = GetInt("Input the number of lines");

                var points = new List<ColorPoint>();
                FillPointList(numberOfElements, points);
                string[] arrData = Array.ConvertAll(points.ToArray(),
                    (ColorPoint cp) => cp.ToString());

                File.WriteAllLines(path, arrData);
                Console.WriteLine($"{numberOfElements} lines were wrote in:\n{path}");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void FillPointList(int numberOfElements, List<ColorPoint> points)
        {
            ColorPoint newPoint;
            for (int i = 0; i < numberOfElements; i++)
            {
                int colorNumber = rnd.Next(0, ColorPoint.colors.Length);
                newPoint = new ColorPoint()
                {
                    x = rnd.NextDouble(),
                    y = rnd.NextDouble(),
                    color = ColorPoint.colors[colorNumber],
                };
                points.Add(newPoint);
            }
        }

        private static int GetInt(string message,
            int upperBound = int.MaxValue, int lowerBound = int.MinValue)
        {
            int number;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out number)
                || number < lowerBound || number > upperBound)
                Console.WriteLine("Please input integer number in " +
                    $"[{lowerBound}, {upperBound}]");

            return number;
        }
    }
}
