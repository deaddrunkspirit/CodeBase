using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3
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
                    string pathInput = @"../../../input.txt";
                    
                    string[] arr2 = File.ReadAllLines(pathInput);
                    
                    string pathOutput = @"../../../output.txt";

                    Console.Write("Input n: ");
                    int n = GetInput();
                    Console.Write("Input k: ");
                    int k = GetInput();

                    double[] arr1 = GetArray(n, k);
                    string res = ArrayToString(arr1, arr2);
                    File.WriteAllText(pathOutput, res);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Eroor: " + e.Message);
            }
        }

        private static string ArrayToString(double[] arr, string[] arr1)
        {
            string res = "";
            for (int i = 0; i < arr.Length; i++)
            {
                res += arr[i].ToString("f3") + " ";
                for (int j = 0; j < arr1.Length; j++)
                {
                    res += arr1[j];
                }
                if (i == 9)
                {
                    res += Environment.NewLine;
                }
            }

            return res;
        }

        private static double[] GetArray(int n, int k)
        {
            double[] arr1 = new double[n];
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = rnd.Next(-k, k) + rnd.NextDouble();
            }

            return arr1;
        }

        private static int GetInput()
        {
            int n;
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Wrong input...");
            }

            return n;
        }
    }
}
