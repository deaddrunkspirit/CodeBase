using System;

namespace S2
{
    class Program
    {
        static Random rnd = new Random();

        static void Main()
        {
            do
            {
                Console.Clear();
                int m = GetInt("Input m: ", 0, Int32.MaxValue);
                int n = GetInt("Input n: ", 0, Int32.MaxValue);

                double[,] matrix = GetDoubleMatrix(m, n, 1, 10);
                ShowMatrix(matrix); // shows double matrix
                SumOfColumns(matrix); // shows sums of all columns

                Console.WriteLine("To exit press Escape");
                Console.WriteLine("To continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// this method writes sums of all columns
        /// </summary>
        /// <param name="matrix">double matrix MxN</param>
        private static void SumOfColumns(double[,] matrix)
        {
            double sum = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    sum += matrix[j, i];
                }
                Console.WriteLine($"Sum of column {i + 1} is {sum.ToString("f3")}");
                sum = 0;
            }
        }

        /// <summary>
        /// this method shows double matrix 
        /// </summary>
        /// <param name="matrix">double matrix MxN</param>
        private static void ShowMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++, Console.WriteLine())
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,10}", matrix[i, j].ToString("f3"));
                }
            }
        }

        /// <summary>
        /// this method generates random double matrix MxN
        /// </summary>
        /// <param name="m">number of rows</param>
        /// <param name="n">number of columns</param>
        /// <param name="min">minimum value of matrix element</param>
        /// <param name="max">maximum value of matrix value</param>
        /// <returns></returns>
        private static double[,] GetDoubleMatrix(int m, int n, int min, int max)
        {
            double[,] matrix = new double[m, n];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(min, max + 1) + rnd.NextDouble();
                }
            }

            return matrix;
        }

        /// <summary>
        /// this method gets integer number N
        /// </summary>
        /// <param name="str">Name of integer number</param>
        /// <param name="lower">minimum value of N</param>
        /// <param name="upper">maxinum value of N</param>
        /// <returns></returns>
        private static int GetInt(string str, int lower, int upper)
        {
            Console.Write(str);
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < lower || n > upper)
            {
                Console.WriteLine("Wrong input");
                Console.WriteLine($"Input integer number in [{lower}, {upper}]");
            }

            return n;
        }
    }
}
