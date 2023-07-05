using System;
using System.IO;

namespace _4
{
    class Program
    {
        static Random rnd = new Random();

        static void Main()
        {
            try
            {
                do
                {
                    string path = @"../../../log.txt";
                    Console.Write("Input n: ");
                    int n = GetInt();

                    string str = GetStringOfChar(n);
                    char[] chArr = GetCharArray(n, str);

                    /// 2
                    Console.Write("Input k: ");
                    int k = GetInt();
                    char[] newChArray = ModKArray(str, k);

                    /// 3
                    Console.Write("Input ch1: ");
                    char ch1 = GetChar();
                    Console.Write("Input ch2: ");
                    char ch2 = GetChar();

                    /// 4
                    Console.Write("Input letter: ");
                    char letter = GetChar();

                    string res = "chArr " + ToStringChArr(chArr) 
                        + Environment.NewLine + "newChArr = " 
                        + ToStringChArr(newChArray) + Environment.NewLine 
                        + "ch1 = " + ch1 + " ; " + "ch2 = " + ch2 
                        + Environment.NewLine 
                        + "Count of elements in (ch1, ch2) = " 
                        + ElementsFromCh1ToCh2(str, ch1, ch2) 
                        + Environment.NewLine + "Count of " + letter 
                        + " is " + CountOfLetter(letter, str);

                    File.WriteAllText(path, res);

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

        private static string ToStringChArr(char[] chArr)
        {
            string res = "[ ";
            for (int i = 0; i < chArr.Length; i++)
            {
                res += chArr[i] + ", ";
            }

            return res + "]";
        }
        private static char[] ModKArray(string str, int k)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if ((i) % k == 0)
                {
                    count++;
                }
            }

            char[] chArr = new char[count];
            int j = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] - 97) % k == 0)
                {
                    chArr[j] = str[i];
                    j++;
                }
            }

            return chArr;
        }

        private static int CountOfLetter(char letter, string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (letter == str[i])
                {
                    count++;
                }
            }

            return count;
        }

        private static int ElementsFromCh1ToCh2(string str, char ch1, char ch2)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] > ch1 && str[i] < ch2)
                {
                    count++;
                }
            }

            return count;
        }

        private static char GetChar()
        {
            char ch1;
            while (!char.TryParse(Console.ReadLine(), out ch1) 
                || ch1 > 'z' || ch1 < 'a')
            {
                Console.WriteLine("Wrong input");
            }

            return ch1;
        }

        private static char[] GetCharArray(int n, string res)
        {
            char[] chArr = new char[n];
            for (int i = 0; i < res.Length; i++)
            {
                chArr[i] = res[i];
            }

            return chArr;
        }

        private static string GetStringOfChar(int n)
        {
            string res = "";
            for (int i = 0; i < n; i++)
            {
                res += Convert.ToChar(rnd.Next('a', 'z' + 1));
            }

            return res;
        }

        private static int GetInt()
        {
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.WriteLine("Wrong input");
            }

            return n;
        }
    }
}
