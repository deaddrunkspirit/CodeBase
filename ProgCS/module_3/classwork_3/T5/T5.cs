using System;
using Task5Lib;

namespace Task5
{
    public class T5
    {
        private static Random rnd = new Random();

        public static void Main()
        {
            int[,] arr = new int[15, 15];
            do
            {
                Console.Clear();

                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arr.GetLength(1); j++)
                        arr[i, j] = rnd.Next(100);
                Methods.lineComplete += () => { Console.WriteLine(); };
                Methods.ArrayPrint(arr);

                Console.WriteLine("To exit press Escape key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
