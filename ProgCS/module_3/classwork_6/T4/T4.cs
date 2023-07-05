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
                var booklet = new Book()
                {
                    Author = "L.N. Volgin",
                    Title = @"""Consistent Optimum Principle"""
                };
                Console.WriteLine($"Author: {booklet.Author}\nTitle: {booklet.Title}");
                Console.Beep();
                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}