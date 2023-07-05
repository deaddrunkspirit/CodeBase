using System;

namespace Task4
{
    class Program
    {
        static void Main()
        {
            try
            {
                do
                {
                    Console.Clear();
                    uint n = GetIntNumber("Input n: "); // Getting integer n > 0
                    uint m = GetIntNumber("Input m: "); // Getting integer m > 0
                    int[,] arr = GetMatrix(n, m);
                    SquareMatrixConvert(n, m, arr);

                    Output(n, m, arr);

                    Console.WriteLine("To exit press ESCAPE");
                    Console.WriteLine("To continue press any key . . .");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// This method converts square matrix (if it is square) to matrix
        /// in which every element, such that (i > j) is eqal to zero
        /// </summary>
        /// <param name="n">count of rows</param>
        /// <param name="m">count of columns</param>
        /// <param name="arr">matrix</param>
        private static void SquareMatrixConvert(uint n, uint m, int[,] arr)
        {
            if (n == m)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (i > j)
                        {
                            arr[i, j] = 0;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This method makes matrix n x m. Each element of matrix
        /// is calculate as ((i + 1) * (2 * j + 1))
        /// </summary>
        /// <param name="n">count of rows</param>
        /// <param name="m">count of columns</param>
        /// <returns></returns>
        private static int[,] GetMatrix(uint n, uint m)
        {
            int[,] arr = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = (i + 1) * (2 * j + 1);
                }
            }

            return arr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n">number of rows</param>
        /// <param name="m">number of columns</param>
        /// <param name="arr">matrix</param>
        private static void Output(uint n, uint m, int[,] arr)
        {
            Console.WriteLine();
            for (int i = 0; i < (n - 1); i++, Console.WriteLine())
            {
                for (int j = 0; j < (m - 1); j++)
                {
                    Console.Write("{0,4}", arr[i, j]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Rank = " + arr.Rank);
            Console.WriteLine("Length = " + arr.Length);
        }

        /// <summary>
        /// This method gets positive integer number
        /// </summary>
        /// <param name="str">string that describes what are you inputing</param>
        /// <returns></returns>
        private static uint GetIntNumber(string str)
        {
            uint n;
            Console.Write(str);
            while (!uint.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Wrong Input");
            }

            return n;
        }
    }
}
