using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T5
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("To start press any key...");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                if (!int.TryParse(Console.ReadLine(), out int n) || n < 0 || n > 100)
                {
                    Console.WriteLine("N is incorrect");
                    return;
                }
                if (!int.TryParse(Console.ReadLine(), out int k) || k < 0 || k > 1000)
                {
                    Console.WriteLine("K is incorrect");
                    return;
                }
                int[] arr = GenerateArray(n, k);
                ThanosSnap(arr);
                

                Console.WriteLine("To exit programm press ESCAPE");
                Console.WriteLine("To continue press any key");
            }

        }

        static void ThanosSnap(int[] data)
        {
            int a;
            Random rnd = new Random();
            for (int i = 0; i < data.Length; i++)
            {
                a = rnd.Next(1, 2);
                if (a == 1)
                {
                    data[i] = 0;
                }
            }

        }

        static int[] GenerateArray(int n, int k)
        {
            Random rnd = new Random();
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-k + 1, k);
            }
            return arr;
        }
    }
}
