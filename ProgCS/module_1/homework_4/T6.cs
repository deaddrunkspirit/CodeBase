using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    class Program
    {
        static void Main()
        {
            var arr = new int[] { 10, 1, 123 };
            PrintArray(arr);
            Console.WriteLine("");
            Array.Sort(arr);
            PrintArray(arr);
            Console.WriteLine("");
            Array.Reverse(arr);
            PrintArray(arr);
            Console.WriteLine("");
            NewMethod(arr);

            Console.ReadLine();
        }

        private static void NewMethod(int[] arr)
        {
            if (arr.Length == 3)
                Console.WriteLine("SanyaXuesos");
        }

        static Random rnd = new Random();
        static Random tx = new Random(3);

        public static void GenRandomArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next() % 100;
                Console.Write(arr[i]);
            }
        }

        public static void RandomArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = tx.Next() % 100;
                Console.Write(arr[i]);
            }
        }

        private static void PrintArray(int[] arr)
        {
            Console.WriteLine("");
            foreach (int i in arr)
            {
                Console.Write(i + " & ");
            }
        }
    }
}
