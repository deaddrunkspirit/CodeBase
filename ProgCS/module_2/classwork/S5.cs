using System;

namespace S5
{
    class Program
    {
        const int lower = 1;
        const int upper = 1000;

        static Random rnd = new Random();

        static void Main()
        {
            try
            {
                do
                {
                    Console.Clear();

                    int m = GetInt("Input m: ", lower, upper);
                    int n = GetInt("Input n: ", lower, upper);
                    int[,] matrix1 = GetTenIMatrix(m, n);
                    PrintMatrix(matrix1);
                    Console.WriteLine("--------------");
                    Console.WriteLine("--------------");

                    int[,] matrix2 = RandomMatrix(m, n);
                    PrintMatrix(matrix2);
                    Console.WriteLine("---------------");
                    Console.WriteLine("---------------");
                    PrintMatrixOdd(matrix2);
                    Console.WriteLine("---------------");
                    Console.WriteLine("---------------");
                    PrintMatrixEven(matrix2);


                    Console.WriteLine("To exit press Escape");
                    Console.WriteLine("To continue press any key . . . ");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.ReadKey();
            }
        }

        private static void PrintMatrixEven(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++, Console.WriteLine())
            {
                switch (i % 2)
                {
                    case 1:
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (j % 2 == 0)
                            {
                                Console.Write("{0,4}", matrix[i, j]);
                            }
                            else
                            {
                                Console.Write("{0,4}", 0);
                            }
                        }
                        break;
                    case 0:
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (j % 2 == 1)
                            {
                                Console.Write("{0,4}", matrix[i, j]);
                            }
                            else
                            {
                                Console.Write("{0,4}", 0);
                            }
                        }
                        break;
                }
            }
        }

        private static void PrintMatrixOdd(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++, Console.WriteLine())
            {
                switch(i % 2)
                {
                    case 0:
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (j % 2 == 0)
                            {
                                Console.Write("{0,4}", matrix[i, j]);
                            }
                            else
                            {
                                Console.Write("{0,4}", 0);
                            }
                        }
                        break;
                    case 1:
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (j % 2 == 1)
                            {
                                Console.Write("{0,4}", matrix[i, j]);
                            }
                            else
                            {
                                Console.Write("{0,4}", 0);
                            }
                        }
                        break;
                }
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++, Console.WriteLine())
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,4}", matrix[i, j]);
                }
            }
        }

        private static int[,] RandomMatrix(int m, int n)
        {
            int[,] matrix = new int[m, n];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(1, 100);
                }
            }

            return matrix;
        }

        private static int[,] GetTenIMatrix(int m, int n)
        {
            int[,] matrix = new int[m, n];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 10 * i;
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
                Console.WriteLine($"Please input numbers in [{lower}; {upper}]");
            }

            return n;
        }
    }
}
