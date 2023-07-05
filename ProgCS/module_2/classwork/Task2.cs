using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            do
            {
                string path = @"../../../output2.txt";

                Console.Clear();
                Console.Write("Input N: ");
                int n = GetIntNumber();
                int[,] matrix = GetSquareMatrix(n);
                OutputMatrix(matrix);

                Console.WriteLine("To exit press ESCAPE");
                Console.WriteLine("To continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void OutputMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++, Console.WriteLine())
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }
            }
        }

        private static string MatrixToString(int n, int[,] matrix)
        {
            string res = "";
            int counter = 0;

            foreach (int num in matrix)
            {
                res += num + " ";
                if (counter == n)
                {
                    res += Environment.NewLine;
                    counter = 0;
                }
                ++counter;
            }

            return res;
        }

        private static int[,] GetSquareMatrix(int n)
        {
            int[,] matrix = new int[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = (i + j) % n + 1;
                }
            }

            return matrix;
        }

        private static int GetIntNumber()
        {
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.WriteLine("Wrong input");
                Console.Write("Input N:");
            }

            return n;
        }
    }
}
