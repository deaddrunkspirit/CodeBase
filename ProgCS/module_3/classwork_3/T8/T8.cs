using System;

namespace Task8
{
    public class T8
    {
        public static void Main()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("To exit press Escape key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
