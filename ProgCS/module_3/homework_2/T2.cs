using System;

namespace Task2
{
    public class T2
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
            int[] A = new int[10];
            do
            {
                for (int i = 0; i < A.Length; i++)
                    A[i] = rnd.Next(0, 21);
                double[] B = Array.ConvertAll(A, el => (double)1 / el);
                Array.ForEach(A, el => Console.Write($"{el}\t"));
                Console.WriteLine();
                Array.ForEach(B, el => Console.Write($"{el:f2}\t"));
                Console.WriteLine("\n\nTo exit press Escape key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
