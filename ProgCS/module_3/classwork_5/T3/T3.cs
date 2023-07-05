using System;
using System.Collections.Generic;
using Task3Lib;

namespace Task3
{
    public class T3
    {
        public static void Main()
        {
            List<RightCone> cones = new List<RightCone>();
            do
            {
                Console.Clear();

                cones.Add(new RightCone(new Point(0, 0, 3), 0, 0, 0, 5));
                cones.Add(new RightCone(new Point(1, -1, 11), 1, -1, 3, 5));
                cones.Add(new RightCone(new Point(10, -12, 2), 10, -12, 10, 6));
                cones.Add(new RightCone(new Point(0, 0, 13), 0, 0, 0, 2));
                cones.ForEach(cone
                    => Console.WriteLine($"{cone}\nCone's section: {cone.Section():f3}\n"));

                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}