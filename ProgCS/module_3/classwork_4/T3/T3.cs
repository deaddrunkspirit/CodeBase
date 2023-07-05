using System;

namespace Task3
{
    public class T3
    {
        public static void Main()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}