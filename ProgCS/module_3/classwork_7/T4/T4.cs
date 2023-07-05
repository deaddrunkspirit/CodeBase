using Structures;
using System;

namespace Task4
{
    public class T4
    {
        private static Random rnd = new Random();

        private static readonly PointS zero = new PointS(0, 0);

        public static void Main()
        {
            do
            {
                Console.Clear();

                CircleS[] circles = new CircleS[rnd.Next(5, 10)];
                double[] keys = new double[circles.Length];
                InitializeCircleArray(circles);
                PrintCircleArray(circles, "Default array:\n");
                Array.Sort(circles);
                PrintCircleArray(circles, "Sorted by radius:\n");
                for (int i = 0; i < circles.Length; i++)
                    keys[i] = circles[i].Center.Distance(zero);
                Array.Sort(keys, circles);
                PrintCircleArray(circles, "Sorted by distance to zero:\n");
                Console.Beep();
                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void PrintCircleArray(CircleS[] circles, string message)
        {
            Console.WriteLine(message);
            Array.ForEach(circles, circle => Console.WriteLine($"{circle}\n"));
            Console.WriteLine();
        }

        private static void InitializeCircleArray(CircleS[] circles)
        {
            for (int i = 0; i < circles.Length; i++)
                circles[i] = new CircleS(rnd.Next(-100, 100),
                    rnd.Next(-100, 100), rnd.Next(1, 100));
        }
    }
}