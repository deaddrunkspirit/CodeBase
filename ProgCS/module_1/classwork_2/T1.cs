using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1
{
    class Program
    {
        static Random rnd = new Random();
        static void Main()
        {
            try
            {
                Console.WriteLine("To continue press any key...");
                while (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.Write("Input k:");
                    int k = GetIntNumber();
                    Console.Write("Input m:");
                    int m = GetIntNumber();
                    int[] arrA = CreateArray(k);
                    int[] arrB = CreateArray(m);
                    int[] arrC = MergeArray(arrA, arrB);
                    ShowArray(arrC);
                    Console.ReadKey();

                    Console.WriteLine("To exit press Escape");
                    Console.WriteLine("To continue press any key");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private static int GetIntNumber()
        {
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.WriteLine("Wrong input");
            }

            return n;
        }

        static int[] CreateArray(int n)
        {
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-1, 2);
            }

            return arr;
        }
        static void ShowArray(int[] arr)
        {
            string res = "";
            int length = (int)(arr.Length / 2);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    res += arr[i].ToString();
                }
                res += Environment.NewLine;
            }
            Console.WriteLine(res);
        }

        static int[] MergeArray(int[] arr_1, int[] arr_2)
        {
            int[] arr_3 = new int[Math.Max(arr_1.Length, arr_2.Length)];
            for (int i = 0; i < Math.Min(arr_1.Length, arr_2.Length); i++)
            {
                if (i % 2 == 0)
                {
                    arr_3[i] = arr_1[i];
                }
                else
                {
                    arr_3[i] = arr_2[i];
                }
            }
            for (int i = Math.Min(arr_1.Length, arr_2.Length); i < arr_3.Length; i++)
            {
                arr_3[i] = 0;
            }
            return arr_3;
        }


    }
}
