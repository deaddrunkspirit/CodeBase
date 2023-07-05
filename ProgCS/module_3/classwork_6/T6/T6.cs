using System;
using Task6Lib;

namespace Task6_
{
    public class T6
    {
        public static void Main()
        {
            do
            {
                Console.Clear();
                RealSearch function = new RealSearch(-0.2, 0.3, 0.001);
                Console.WriteLine($"Function root Sin(x) = {function.RootSearch():g4}" +
                    $"\nIteration count = {function.IterationQuality}");
                Console.Beep();
                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}