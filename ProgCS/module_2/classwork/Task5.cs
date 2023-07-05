using System;
using System.IO;

namespace Task5
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

                    string path = "../../../Pasal.txt";
                    int n = GetPositiveInt("Input n: ");
                    int[][] pascal = GetPascalSet(n);

                    PrintPascalSet(pascal);
                    string res = ToStringPascal(n, pascal); 

                    File.WriteAllText(path, res);
                    Console.WriteLine("To exit press ESCAPE key");
                    Console.WriteLine("To continue press any key . . .");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                Console.ReadKey();
            }
        }

        private static string ToStringPascal(int n, int[][] pascal)
        {
            string res = "";
            foreach (int[] arr in pascal)
            {
                foreach (int num in arr)
                {
                    for (int i = 0; i < (n / 2); i++)
                    {
                        res += " ";
                    }
                    res += num;
                }
                res += Environment.NewLine;
            }

            return res;
        }

        private static void PrintPascalSet(int[][] pascal)
        {
            foreach (int[] arr in pascal)
            {
                foreach (int num in arr)
                {
                    Console.Write("{0,4}", num);
                }
                Console.WriteLine();
            }
        }

        private static int[][] GetPascalSet(int n)
        {
            int[][] pascal = new int[n + 1][];

            for (int i = 0; i < pascal.Length; i++)
            {
                pascal[i] = new int[i + 1];
                pascal[i][0] = pascal[i][i] = 1;
                for (int j = 0; j < i; j++)
                {
                    pascal[i][j] = pascal[i - 1][j - 1] + pascal[i - 1][j];
                }
            }

            return pascal;
        }

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
