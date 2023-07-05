using System;
using Task4Lib;

namespace Task4
{
    public class T4
    {
        public static void Main()
        {
            do
            {
                Console.Clear();

                var charStack = new Stack<char>();
                charStack.Push('A');
                Console.WriteLine($"charStack.Pop() = {charStack.Pop()}");
                var doubleStack = new Stack<double>();
                doubleStack.Push(3.14159);
                double x = doubleStack.Pop();
                Console.WriteLine($"x = {x}");
                var pointStack = new Stack<Point>();
                pointStack.Push(new Point());
                Point p = pointStack.Pop();
                Console.WriteLine($"p.X = {p.X}, p.Y = {p.Y}");

                Console.Beep();
                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}