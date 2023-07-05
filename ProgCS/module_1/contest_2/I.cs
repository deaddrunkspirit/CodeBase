using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I
{
    class I
    {
        static void Main()
        {
            int n, // production rate (parts per day)
                k, // money for a part
                r, // count of parts (per day)
                m, // month of work
                t; // days of work in m

            if (!int.TryParse(Console.ReadLine(), out n) || n < 10 || n > 100)
            // Check for correctness of input and input of the variable n
            {
                Console.WriteLine("wrong");
                return;
            }

            if (!int.TryParse(Console.ReadLine(), out k) || k < 50 || k > 100)
            // Check for correctness of input and input of the variable k
            {
                Console.WriteLine("wrong");
                return;
            }

            if (!int.TryParse(Console.ReadLine(), out r) || r < 1 || r > 200)
            // Check for correctness of input and input of the variable r
            {
                Console.WriteLine("wrong");
                return;
            }

            if (!int.TryParse(Console.ReadLine(), out m) || m < 2 || m > 10)
            // Check for correctness of input and input of the variable m
            {
                Console.WriteLine("wrong");
                return;
            }

            if (!int.TryParse(Console.ReadLine(), out t) || t < 5 || t > 30)
            // Check for correctness of input and input of the variable t
            {
                Console.WriteLine("wrong");
                return;
            }
            Console.WriteLine($"{Salary(n, k, r, m, t):f3}");
            Console.ReadLine();
        }

        /// <summary>
        /// This is a method which calculates salary by 5 parametrs
        /// </summary>
        /// <param name="n">production rate (parts per day)</param>
        /// <param name="k">money for a part</param>
        /// <param name="r">count of parts (per day)</param>
        /// <param name="m">month of work</param>
        /// <param name="t">days of work in m</param>
        /// <returns></returns>

        static double Salary(int n, int k, int r, int m, int t)
        {
            double salary;
            if (r < n)
            {
                salary = m * t * r * (0.5 * k);
            }
            else
            {
                salary = m * t * ((r - n) * 1.25 + n) * k;
            }
            return salary;
        }
    }
}
