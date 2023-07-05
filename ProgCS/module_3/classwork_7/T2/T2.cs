using System;
using Task2Lib;

namespace Task2
{
    public class T2
    {
        private static Random rnd = new Random();

        public static void Main()
        {
            do
            {
                Console.Clear();
                Coords coordinates = new Coords(2, 10);
                Circle circle1 = new Circle(1, 3, 12),
                    circle2 = new Circle(1, new Coords(4, 10)),
                    circle3 = new Circle(1, coordinates);
                Console.WriteLine($"First part of the task" +
                    $"\n1. {circle1}\n2. {circle2}\n3. {circle3}\n" +
                    $"Second part of the task");
                Rectangle[] rectangles = GenerateRectangleArray(20, -100, 100);
                Array.Sort(rectangles);
                Array.ForEach(rectangles, rectangle => { Console.WriteLine($"{rectangle}"); });
                Console.Beep();
                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static Rectangle[] GenerateRectangleArray(int sizeOfArray,
            int lowerCoordsBound, int upperCoordsBound)
        {
            Rectangle[] rectangles = new Rectangle[sizeOfArray];
            for (int i = 0; i < rectangles.Length; i++)
            {
                double x1 = rnd.Next(lowerCoordsBound, upperCoordsBound),
                    y1 = rnd.Next(lowerCoordsBound, upperCoordsBound),
                    x2 = rnd.Next(lowerCoordsBound, upperCoordsBound),
                    y2 = rnd.Next(lowerCoordsBound, upperCoordsBound);
                try
                {
                    rectangles[i] = new Rectangle(new Coords(x1, y1), new Coords(x2, y2));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            return rectangles;
        }
    }
}