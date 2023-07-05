using System;
using Task5Lib;

namespace Task6
{
    public class T6
    {
        public static void Main()
        {
            int[,] arr = new int[15, 15];
            int x = 0;
            do
            {
                Console.Clear();
                Methods.lineComplete += () => { Console.WriteLine(); };
                Methods.newItemFilled += Methods.ArraySumCount;
                Methods.newItemFilled += Methods.MidVal;
                Methods.newItemFilled += Methods.ChangeMax;
                Methods.ArrayFill(arr);
                Methods.ArrayPrint(arr);
                Console.WriteLine("To exit press Escape key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
