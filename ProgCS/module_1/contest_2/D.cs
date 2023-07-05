using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D
{
    class D
    {
        static void Main()
        {
            int N;
            double x;

            if (!double.TryParse(Console.ReadLine(), out x) || x < -1000 || x > 1000)
            /// Check for correctness of input and input of the variable x
            {
                Console.WriteLine("wrong");
                return;
            }

            if (!int.TryParse(Console.ReadLine(), out N) || N < 1 || N > 1000)
            /// Check for correctness of input and input of the variable N
            {
                Console.WriteLine("wrong");
                return;
            }
            Console.WriteLine($"{Sin(x, N):f3}");
        }

        /// <summary>
        ///  method takes the parameter of the function (x) 
        /// and returns the value of the function 
        /// at the point (x) with accuracy (n)
        /// </summary>

        static double Sin(double x, int N)
        {
            int num = 1;
            /// num is counter for loop
            double result = x;
            /// if N = 0 , result = x
            double next = x;
            /// next number from Taylor series
            while (N >= num)
            {
                /// This is loop for calculating sinus
                next *= (-1) * x * x / (((2 * num + 1) * num * 2));
                result += next;
                num++;
            }
            return result;
        }
    }
}
