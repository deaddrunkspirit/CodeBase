using System;

namespace S3
{
    class Program
    {
        static Random rnd = new Random();

        const int upper = 1000;
        const int lower = 1;

        const int maxEl = 10;
        const int minEl = 1;

        static void Main()
        {
            try
            {
                do
                {
                    Console.Clear();

                    int m = GetInt("Input m: ", lower, upper); // gets count of rows
                    int n = GetInt("Input n: ", lower, upper); // gets count of columns
                    int[,] matrix = GenerateMatrix(m, n); // gets matrix

                    WriteMatrix(matrix); // print matrix
                    Console.WriteLine();
                    Console.WriteLine();

                    // INITIALIZATION
                    int[] indexArr = new int[n];
                    int[] sumArr = new int[n];
                    GetSumAndIndexArr(matrix, indexArr, sumArr);
                    // now we have index and sum arrays, where we have sums and indexes of columns
                    SortingArrays(sumArr, indexArr);

                    //SORTING METHOD TO DO


                    // OUTPUT of sums and indexes
                    for (int i = 0; i < indexArr.Length; i++)
                    {
                        Console.Write("{0,3}", indexArr[i]);
                    }
                    Console.WriteLine();
                    for (int i = 0; i < sumArr.Length; i++)
                    {
                        Console.Write("{0,3}", sumArr[i]);
                    }
                    Console.WriteLine();
                    Console.WriteLine("To exit press Escape key");
                    Console.WriteLine("To continue press any key . . .");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.ReadKey();
            }
        }

        private static void Change(ref int a,ref int b)
        {
            a += b;
            b = a - b;
            a -= b;
        }

        private static void SortingArrays(int[] sumArr, int[] indexArr)
        {
            
            for (int i = 0; i < sumArr.Length; i++)
            {
                for (int j = i + 1; j < sumArr.Length; j++)
                {
                    if (sumArr[i] > sumArr[j])
                    {
                        Change(ref sumArr[i], ref sumArr[j]);
                        Change(ref indexArr[i], ref indexArr[j]);
                    }
                }
            }
        }

        /// <summary>
        /// This method fills two arrays with indexes and sums of columns of matrix
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="indexArr">array of indexes of columns</param>
        /// <param name="sumArr">array of sums of columns</param>
        private static void GetSumAndIndexArr(int[,] matrix, int[] indexArr, int[] sumArr)
        {
            for (int i = 0; i < sumArr.Length; i++)
            {
                indexArr[i] = i + 1;
            }
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    sum += matrix[j, i];
                }
                sumArr[i] = sum;
                sum = 0;
            }
        }

        /// <summary>
        /// This method print matrix in console
        /// </summary>
        /// <param name="matrix"></param>
        private static void WriteMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++, Console.WriteLine())
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }
            }
        }

        /// <summary>
        /// Thos method generates matrix MxN
        /// </summary>
        /// <param name="m">count of rows</param>
        /// <param name="n">count of columns</param>
        /// <returns></returns>
        private static int[,] GenerateMatrix(int m, int n)
        {
            int[,] matrix = new int[m, n];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(minEl, maxEl + 1);
                }
            }

            return matrix;
        }

        /// <summary>
        /// Thos method gets integer number in bounds [lower, upper] from user
        /// </summary>
        /// <param name="str">Name of number</param>
        /// <param name="lower">lower bound of number</param>
        /// <param name="upper">upper bound of number</param>
        /// <returns></returns>
        private static int GetInt(string str, int lower, int upper)
        {
            int n;
            Console.Write(str);
            while (!int.TryParse(Console.ReadLine(), out n) || n < lower || n > upper)
            {
                Console.WriteLine("Error: wrong input!");
                Console.WriteLine($"Plese input number in [{lower}, {upper}]");
            }

            return n;
        }
    }
}
