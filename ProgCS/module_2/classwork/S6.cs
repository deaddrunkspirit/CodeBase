using System;

namespace S6
{
    class Program
    {
        const int upper = Int32.MaxValue;
        const int lower = 1;

        static Random rnd = new Random();

        static void Main()
        {
            try
            {
                do
                {
                    Console.Clear();

                    int n = GetInt("Input n: ");
                    int[][] arrA = GetArrayA(n);
                    int[][] arrB = GetArrayB(n, arrA);

                    PrintArrayOfArrays(arrA);
                    Console.WriteLine("--------------------");
                    Console.WriteLine("--------------------");
                    PrintArrayOfArrays(arrB);

                    Console.WriteLine("To exit press Escape");
                    Console.WriteLine("To continue press any key . . .");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.ReadKey();
            }
        }

        private static void PrintArrayOfArrays(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++, Console.WriteLine())
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write("{0,3}", arr[i][j]);
                }
            }
        }

        private static int[][] GetArrayB(int n, int[][] arrA)
        {
            int[][] arrB = new int[n / 2][];
            int l = 0;
            switch (arrA.Length % 2)
            {
                case 0:
                    arrB = new int[n][];
                    for (int i = 0; i < arrA.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            arrB[l] = arrA[i];
                            l++;
                        }
                    }
                    break;
                case 1:
                    arrB = new int[(int)(n / 2 + 1)][];
                    for (int i = 0; i < arrA.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            arrB[l] = arrA[i];
                            l++;
                        }
                    }
                    break;
            }

            return arrB;
        }

        private static int[][] GetArrayA(int n)
        {
            int[][] arrA = new int[n][];
            for (int i = 0; i < arrA.GetLength(0); i++)
            {
                int n1 = rnd.Next(1, 15);
                arrA[i] = new int[n1];
                for (int j = 0; j < arrA[i].Length; j++)
                {
                    arrA[i][j] = rnd.Next(1, 15);
                }
            }

            return arrA;
        }

        private static int GetInt(string str)
        {
            Console.Write(str);
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < lower || n > upper)
            {
                Console.WriteLine($"Please input number in [{lower}, {upper}]");
            }

            return n;
        }
    }
}
