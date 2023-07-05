using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3
{
    class Program
    {
        static void Main()
        {
            //File.Create(@"../Data2.txt");
            string path = @"Data2.txt";
            if (File.Exists(path))
            {
                string createText = "10 20 30 40 50"
                    + Environment.NewLine + "60 70 80 90";
                File.WriteAllText(path, createText, Encoding.UTF8);
            }
            if (File.Exists(path))
            {
                string readText = File.ReadAllText(path);
                string[] stringValues = readText.Split(' ');
                int[] arr = StringArrayToIntArray(stringValues);
                foreach (int i in arr)
                {
                    Console.Write(i + " ");
                }
                Console.ReadLine();
            }
        }

        public static int[] StringArrayToIntArray(string[] str)
        {
            int[] arr = null;
            if (str.Length != 0)
            {
                arr = new int[0];
                foreach (string s in str)
                {
                    int tmp;
                    if (int.TryParse(s, out tmp))
                    {
                        Array.Resize(ref arr, arr.Length + 1);
                        arr[arr.Length - 1] = tmp;
                    }
                }
            }
            return arr;
        }
    }
}
