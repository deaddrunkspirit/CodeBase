using System;

namespace Task1
{
    public class T1
    {
        /// <summary>
        /// Randomizer
        /// </summary>
        private static Random rnd = new Random();

        /// <summary>
        /// Main plot of the program
        /// </summary>
        public static void Main()
        {
            int[] intArr = new int[10];
            do
            {
                Console.Clear();
                for (int i = 0; i < intArr.Length; i++)
                    intArr[i] = rnd.Next(-15, 16);
                PrintArray(intArr);
                Array.Sort(intArr, (first, second) => Math.Abs(first).CompareTo(Math.Abs(second)));
                PrintArray(intArr);
                Console.WriteLine("\n\nTo exit press Escape Key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }

        /// <summary>
        /// This method prints array of integer values
        /// </summary>
        /// <param name="arr">integer array</param>
        private static void PrintArray(int[] arr)
        {
            foreach (int num in arr)
                Console.Write($"{num,4}");
            Console.WriteLine();
        }
    }
}
