using System;
using Task3Lib;

namespace Task3
{
    public class T3
    {
        private static Random rnd = new Random();

        private const int arraySize = 7;

        public static void Main()
        {
            do
            {
                Console.Clear();
                var massCircles = new Circle[arraySize];
                var massSquares = new Square[arraySize];
                InitializeFigureArrays(massCircles, massSquares);
                Methods.GreaterAreaInfo(massCircles, 30);
                Methods.GreaterAreaInfo(massSquares, 4);
                Console.Beep();
                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void InitializeFigureArrays(Circle[] massCircles, Square[] massSquare)
        {
            for (int i = 0; i < arraySize; i++)
            {
                massCircles[i] = new Circle(rnd.Next(10));
                massSquare[i] = new Square(rnd.Next(10));
            }
        }
    }
}