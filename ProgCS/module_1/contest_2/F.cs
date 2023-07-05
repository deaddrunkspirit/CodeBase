using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F
{
    class F
    {
        static void Main()
        {
            int wordCount,
                shift;
            if (!int.TryParse(Console.ReadLine(), out wordCount) || wordCount < 1)
            /// Check for correctness of input and input of the variable wordCount
            {
                Console.WriteLine("wrong");
                Environment.Exit(0);
            }

            if (!int.TryParse(Console.ReadLine(), out shift))
            /// Check for correctness of input and input of the variable shift
            {
                Console.WriteLine("wrong");
                return;
            }
            
            string result = "";
            if (wordCount == 0)
            {
                Console.WriteLine("");
                return;
            }
            while (wordCount > 0)
            {
                /// output of every encoded word
                string stringInput = InputCorrectString();
                Caesar(stringInput, shift, out result);
                Console.WriteLine(result);
                wordCount--;
            }

        }

        /// <summary>
        /// This method returns a string,
        /// checking that the input of this string is correct 
        /// </summary>

        static string InputCorrectString()
        {
            string input = Console.ReadLine();
            int i = 0;
            while (i < input.Length)
            {
                /// Check for correctness of input and input of the variable input))
                if (char.IsUpper(input[i]) || input[i] < 97 || input[i] > 122 )
                {
                    Console.WriteLine("wrong");
                    Environment.Exit(0);
                }
                i++;
            }
            return input;

        }

        /// <summary>
        /// This method applies Caesar's cipher in lower case words
        /// </summary>
        /// <param name="word">word in lower case</param>
        /// <param name="shift">shift of the letters</param>
        /// <param name="ciphertext">encrypted word</param>

        static void Caesar(string word, int shift, out string ciphertext)
        {
            int i = 0; /// counter
            ciphertext = "";
            shift %=  26;
            while (i < word.Length)
            {
                double parametr = word[i] + shift;
                if (parametr > 122)
                {
                    parametr = (parametr % 122) + 96;
                }
                if (parametr < 97)
                {
                    parametr = 123 - (97 - parametr);
                }
                ciphertext += (char)(parametr);
                i++;
            }
        }
    }
}
