using System;

namespace S4
{
    class Program
    {
        const int lowerBound = 0;
        const int upperBound = 20;

        static void Main()
        {
            try
            {
                do
                {
                    Console.Clear();

                    int n = GetInt("Input n: ", lowerBound, upperBound);

                    int[,] matrix1 = MatrixType1(n); // making first picture matrix
                    PrintMatrix(n, matrix1); // making second picture matrix

                    int[,] matrix2 = MatrixType2(n);
                    PrintMatrix(n, matrix2);

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

        private static int[,] MatrixType2(int n)
        {
            int[,] matrix = new int[n, n];
            int l = 1;
            for (int i = 0; i < n; i++)
            {
                int k = i;
                switch (i % 2)
                {
                    case 1:
                        for (int j = 0; j >= l; j--)
                        {
                            while (k >= l && j < k)
                            {
                                matrix[i, j] = l;
                                l++;
                                k--;
                            }
                        }
                        break;
                    case 0:
                        for (int j = 0; j <= l; j++)
                        {
                            while (k >= l && j > k)
                            {
                                matrix[i, j] = l;
                                l++;
                                k--;
                            }
                        }
                        break;
                }
            }

            return matrix;
        }

        private static void PrintMatrix(int n, int[,] matrix)
        {
            for (int i = 0; i < n; i++, Console.WriteLine())
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }
            }
        }

        private static int[,] MatrixType1(int n)
        {
            int l = 1;
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                switch (i % 2)
                {
                    case 0:
                        for (int j = 0; j < n; j++)
                        {
                            matrix[j, i] = l;
                            l++;
                        }
                        break;
                    case 1:
                        for (int j = n - 1; j > -1; j--)
                        {
                            matrix[j, i] = l;
                            l++;
                        }
                        break;
                }
            }

            return matrix;
        }

        private static int GetInt(string str, int lower, int upper)
        {
            Console.Write(str);
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < lower || n > upper)
            {
                Console.WriteLine("Wrong input");
                Console.WriteLine($"Please input number in [{lower}, {upper}]");
            }

            return n;
        }
    }
}
