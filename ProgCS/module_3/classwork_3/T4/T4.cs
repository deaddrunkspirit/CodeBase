using System;
using Task4Lib;

namespace Task4
{
    public class T4
    {public static void Main()
        {
            ConsoleUI c = new ConsoleUI();
            do
            {
                Console.Clear();

                c.GetStringFromUI();

                Console.WriteLine("\n\nTo exit press Escape key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
