using System;

namespace Task8
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
                    Console.Clear();

                    Console.WriteLine("n and m is the size of matrix A");
                    Console.WriteLine("k and p is the size of matrix B");
                    Console.WriteLine("Remember that multiplication of " +
                        "matrixes is possible if and only if count of " +
                        "columns in A equals to count of rows in B");
                    Console.WriteLine();

                    int n = GetPositiveInt("Input n: ");
                    int m = GetPositiveInt("Input m: ");
                    int k = GetPositiveInt("Input k: ");
                    int p = GetPositiveInt("Input p: ");
                    int[,] matrixA = CreateMatrix(n, m); // Generate matrix A
                    int[,] matrixB = CreateMatrix(k, p); // Generate matrix B
                    int[,] matrixC = MatrixMult(matrixA, matrixB); // Try to make matrix C

                    Console.WriteLine(MatrixToString(matrixA)); //Output for A
                    Console.WriteLine(MatrixToString(matrixB)); //Output for B
                    Console.WriteLine(MatrixToString(matrixC)); //Output for C  


                    Console.WriteLine("To exit press Escape key");
                    Console.WriteLine("To continue press any key");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// This method converts matrix to string
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static string MatrixToString(int[,] matrix)
        {
            string res = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    res += matrix[i, j] + "\t";
                }
                res += Environment.NewLine;
            }

            return res;
        }

        /// <summary>
        /// This method creates matrix C, which is multiplication of A and B
        /// </summary>
        /// <param name="matrA">matrix n x k</param>
        /// <param name="matrB">matrix k x p</param>
        /// <returns></returns>
        private static int[,] MatrixMult(int[,] matrA, int[,] matrB)
        {
            int n = matrA.GetLength(0); // count of Rows in A
            int k = matrB.GetLength(0); // count of Rows in B and columns in A
            int p = matrB.GetLength(1); // count of Columns in B
            int[,] matrC = new int[n, p]; // creating matrix C

            if (matrA.GetLength(1) != matrB.GetLength(0))
            // We are checking if multiplication is possible
            // (matrix moltiplication possible if and only if number 
            //of columns in A is equal to number of Rows in B)
            {
                throw new InvalidOperationException("Multiplication of matrixes is impossible . . .");
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    for (int l = 0; l < k; l++)
                    {
                        // Each matrix C element is a sum of bitwise 
                        // product of elements in all rows A on all 
                        //ellements in columns B
                        matrC[i, j] += matrA[i, l] * matrB[l, j];
                    }
                }
            }

            return matrC;
        }

        /// <summary>
        /// This method generates matrix m x n 
        /// and fills it with random elements in range [1, 10]
        /// </summary>
        /// <param name="n">count of columns</param>
        /// <param name="m">count of rows</param>
        /// <returns></returns>
        private static int[,] CreateMatrix(int m, int n)
        {
            int[,] matrix = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rnd.Next(1, 11);
                }
            }

            return matrix;
        }

        /// <summary>
        /// This method gets an integer number
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static int GetPositiveInt(string str)
        {
            Console.Write(str);
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
            {
                Console.WriteLine("Wrong input . . .");
            }

            return n;
        }
    }
}
