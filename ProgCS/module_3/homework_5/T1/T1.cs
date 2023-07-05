using System;
using Task1Lib;

namespace Task1
{
    public class T1
    {
        public static void Main()
        {
            do
            {
                Console.Clear();

                IArea[] iFigures = { new Triangle(5), new Square(5), new Cube(5) };
                Array.ForEach(iFigures, figure => Console.WriteLine(figure));

                Console.Beep();
                Console.WriteLine("\n\nTo exit press Escape key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}