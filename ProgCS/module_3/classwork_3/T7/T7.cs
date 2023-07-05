using System;
using System.Text;
using Task7Lib;

namespace Task7
{
    public class T7
    {
        private static Random rnd = new Random(55);

        public static void Main()
        {
            int[] arr = new int[19999];
            do
            {
                Console.Clear();

                for (int i = 0; i < arr.Length; i++)
                    arr[i] = rnd.Next();
                Sorting run = new Sorting(arr);
                View watch = new View();
                run.onSort += new SortHandler(Display.BarShow);
                run.onSort += new SortHandler(watch.nShow);
                run.Sort();
                Console.WriteLine("\n");

                Console.WriteLine("To exit press Escape key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
