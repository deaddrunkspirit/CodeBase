using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public class T1
    {
        public static void Main()
        {
            do
            {
                Console.Clear();

                char p = 'e', q = 'z';
                Console.WriteLine($"Maximum(p,q) = {Maximum(p, q)}" +
                    $"\nMaximum(3,8) = {Maximum(3, 8)}" +
                    $"\nMaximum('abcd', '1234') = {Maximum("abcd", "1234")}" +
                    $"\nMaximum(5L,2L) = {Maximum(5L, 2L)}");
                var floatPoints = new List<Point<float>>() {
                    new Point<float>(.333f, .01f), new Point<float>(12.3f, 22.1f),
                    new Point<float>(.01f, .01f), new Point<float>(2, 2),
                    new Point<float>(23.0f, 123.9f), new Point<float>(-123, -90),
                    new Point<float>(14, -12), new Point<float>(23, 99)
                };
                floatPoints.ForEach(x => Console.WriteLine(x.ToString()));
                Console.WriteLine($"Max point: {GetMaxPoint(floatPoints)}");
                Console.Beep();
                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static Point<float> GetMaxPoint(List<Point<float>> floatPoints)
        {
            Point<float> max = floatPoints[0];
            foreach (var point in floatPoints)
                max = Maximum(point, max);
            return max;
        }

        private static T Maximum<T>(T a, T b) where T : IComparable<T>
            => a.CompareTo(b) > 0 ? a : b;
    }
}