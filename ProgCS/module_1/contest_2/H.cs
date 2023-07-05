using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H
{
    class H
    {
        static void Main()
        {
            long number;
            if (!long.TryParse(Console.ReadLine(), out number) || number < 1
                || number > 2000000000)
            /// Checking of correct input and input of variable number
            {
                Console.WriteLine("wrong");
                return;
            }

            Console.WriteLine(IsPrime(number) ? "prime" : "composite");
        }

        /// <summary>
        /// This is a method that determines whether it
        /// is a prime or a composite number
        /// </summary>

        static bool IsPrime(long number)
        {
            int i = 2;
            /// i - is a counter
            while (i <= Math.Sqrt(number))
            {
                /// this cycle determines whether the number is prime
                if (number % i == 0)
                {
                    return false;
                }
                i++;
            }
            return true;
        }
    }
}
