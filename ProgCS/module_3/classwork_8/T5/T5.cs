using System;
using Task5Lib;

namespace Task5
{
    public class T5
    {
        public static void Main()
        {
            do
            {
                Console.Clear();

                var stackInt = new MyStack<int>();
                var stackString = new MyStack<string>();
                stackInt.Push(3);
                stackInt.Push(5);
                stackInt.Push(7);
                Console.WriteLine(stackInt);
                stackString.Push("Generics are great!");
                stackString.Push("Hi there!");
                Console.WriteLine(stackString);

                Console.Beep();
                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}