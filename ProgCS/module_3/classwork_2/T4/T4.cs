using System;

namespace Task4
{
    public class T4
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
            int[] arr = new int[10];
            Comparison<int>[] predicateArr = { Increasing, AbsIncreasing, 
                Decreasing, AbsDecreasing };

            do
            {
                Console.Clear();
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = rnd.Next(-20, 21);
                Series ser = new Series(arr);
                foreach (Comparison<int> rule in predicateArr)
                {
                    Console.WriteLine($"{rule.Method.Name}");
                    ser.Order(rule);
                    Array.ForEach(arr, x => Console.Write($"{x}\t"));
                    Console.WriteLine();
                }
                Console.WriteLine("\n\nTo exit press Escape key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Sorting rule in increasing order
        /// </summary>
        /// <param name="first">first number</param>
        /// <param name="second">second number</param>
        /// <returns></returns>
        private static int Increasing(int first, int second)
            => first.CompareTo(second);

        /// <summary>
        /// Sorting rule in decreasing order
        /// </summary>
        /// <param name="first">first number</param>
        /// <param name="second">second number</param>
        /// <returns></returns>
        private static int Decreasing(int first, int second)
            => second.CompareTo(first);

        /// <summary>
        /// Sorting rule by absolute value in increasing order
        /// </summary>
        /// <param name="first">first number</param>
        /// <param name="second">second number</param>
        /// <returns></returns>
        private static int AbsIncreasing(int first, int second) 
            => Math.Abs(first).CompareTo(Math.Abs(second));

        /// <summary>
        /// Sorting rule by absolute value in decreasing order
        /// </summary>
        /// <param name="first">first number</param>
        /// <param name="second">second number</param>
        /// <returns></returns>
        private static int AbsDecreasing(int first, int second)
            => Math.Abs(second).CompareTo(Math.Abs(first));
    }
}
