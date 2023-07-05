using System;

namespace S1
{
    class Program
    {
        static Random rnd = new Random();

        static void Main()
        {
            try
            {
                do
                {
                    double b = 50 / 0.0;
                    byte c = (byte)b;
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private static void GetSumAndComp(int k, int[,] matrix, ref int sum, ref int comp)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, k];
                comp *= matrix[i, k];
            }
        }

        /// <summary>
        /// This method converts matrix to string
        /// </summary>
        /// <param name="matrix">matrix to convert</param>
        /// <returns></returns>
        private static string MatrixToString(int[,] matrix)
        {
            string res = "";
            for (int i = 0; i < matrix.GetLength(0); i++, res += "\n")
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    res += matrix[i, j] + "\t";
                }
            }

            return res;
        }

        /// <summary>
        /// this method generates random matrix size m x n
        /// </summary>
        /// <param name="m">number of rows</param>
        /// <param name="n"> number of columns</param>
        /// <returns></returns>
        private static int[,] GetMatrix(int m, int n, int min, int max)
        {
            int[,] matrix = new int[m, n];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(min, max + 1);
                }
            }

            return matrix;
        }

        /// <summary>
        /// This method gets positive integer 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static int GetPositiveInt(string str, int upper)
        {
            Console.Write(str);
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > upper)
            {
                Console.WriteLine("Wrong input!");
                Console.WriteLine("Input positive integer number");
            }

            return n;
        }
    }
}
