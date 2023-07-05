using System;
using Task1Lib;

namespace Task1
{
    public class T1
    {
        /// <summary>
        /// Main plot of the program
        /// </summary>
        public static void Main()
        {
            ConvertRule c1 = RemoveDigits,
                c2 = RemoveSpaces,
                c12 = c1;
            c12 += c2;
            Converter conv = new Converter();
            do
            {
                string[] strArr =
                    { "W T F", "123 123a 123", "rrrrr  111  666",
                    "ahd uisg f712g igaf 813d", "  fyq98egisf" 
                };

                try
                {
                    Console.WriteLine("Remove digits:");
                    PrintDel(c1, strArr);
                    Console.WriteLine("\nRemove spaces:");
                    PrintDel(c2, strArr);
                    Console.WriteLine("\nBoth methods:");
                    PrintDel(c12, strArr);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("String was empty");
                }
                Console.WriteLine("\n\nTo exit press Escape key\n" +
                    "To continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// This method prints array of string by special rule
        /// </summary>
        /// <param name="f">rule</param>
        /// <param name="arr">array of strings</param>
        private static void PrintDel(ConvertRule f, string[] arr)
        {
            foreach (string str in arr)
                Console.Write($"|{f(str)}|\t");
        }

        /// <summary>
        /// This method removes all digits from string
        /// </summary>
        /// <param name="str">some string</param>
        /// <returns></returns>
        public static string RemoveDigits(string str)
        {
            if (str == string.Empty)
                throw new ArgumentOutOfRangeException();

            return str.Replace("0", "").
                Replace("1", "").Replace("2", "").Replace("3", "").
                Replace("4", "").Replace("5", "").Replace("6", "").
                Replace("7", "").Replace("8", "").Replace("9", "");
        }

        /// <summary>
        /// This method removes all spaces from string
        /// </summary>
        /// <param name="str">some string</param>
        /// <returns></returns>
        public static string RemoveSpaces(string str)
        {
            if (str == string.Empty)
                throw new ArgumentOutOfRangeException();

            return str.Replace(" ", "");
        }
    }
}
