using System;

namespace S2
{
    public class LatinChar
    {
        char _char;

        public LatinChar()
        {
            _char = 'a';
        }

        public LatinChar(char ch)
        {
            _char = ch;
        }

        public char IsLatin
        {
            set
            {
                if ((value >= 'a' && value <= 'z') || (value >= 'A' && value <= 'Z'))
                {
                    _char = value;
                }
                else
                {
                    _char = 'a';
                }
            }
            get { return _char; }
        }
    }

    class Program
    {
        const char lower = Char.MinValue;
        const char upper = Char.MaxValue;

        static void Main()
        {
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("=========================");
                    Console.WriteLine("=========================");
                    Console.WriteLine("You need to input 2 char symbols from 'A' to 'Z' \nor from 'a' to 'z'");
                    char minCh = GetChar("Input minimal Char: ", lower, upper);
                    char maxCh = GetChar("Input maximal Char: ", minCh, upper);
                    Console.WriteLine("\n");
                    // Input

                    Console.WriteLine("From minCh to maxCh Latin char symbols are:\n");
                    while (minCh <= maxCh)
                    {
                        var latinChar = new LatinChar(minCh);
                        Console.Write(latinChar.IsLatin);
                        minCh++;
                    }
                    // Output

                    Console.WriteLine("\n");
                    Console.WriteLine("=========================");
                    Console.WriteLine("=========================");
                    Console.WriteLine("To exit press Escape key");
                    Console.WriteLine("To continue press any key . . .");
                    // Message
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Incorrect input of symbols");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        /// <summary>
        /// This method gets char symbol
        /// </summary>
        /// <param name="str">message</param>
        /// <param name="lower">lower bound of char</param>
        /// <param name="upper">upper bound of char</param>
        /// <returns></returns>
        private static char GetChar(string str, char lower, char upper)
        {
            char ch;
            Console.Write(str);
            while (!char.TryParse(Console.ReadLine(), out ch) || ch < lower || ch > upper)
            {
                Console.WriteLine("Wrong input");
            }

            return ch;
        }
    }
}
