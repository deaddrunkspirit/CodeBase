using System;

namespace Task3
{
    public class T3
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
            double[] A = new double[10];
            do
            {
                for (int i = 0; i < A.Length; i++)
                    A[i] = rnd.Next(-3, 2) + rnd.NextDouble();
                int[] B = Array.ConvertAll(A, delegate (double el) { return el > 0 ? (int)el : 0; });
                Array.ForEach(A, el => Console.Write($"{el:f2}\t"));
                Console.WriteLine();
                Array.ForEach(B, el => Console.Write($"{el}\t"));
                Console.WriteLine("\n\nTo exit press Escape key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
