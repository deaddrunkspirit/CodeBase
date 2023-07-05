using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace E
{
    class E
    {
        static void Main()
        {
            int number,
                fibNum;
            if (!int.TryParse(Console.ReadLine(), out number) || number < 0)
            // Check for correctness of input and input of the variable x
            {
                Console.WriteLine("wrong");
                return;
            }
            while (number > 0)
            {
                if (!int.TryParse(Console.ReadLine(), out fibNum) || number < 0)
                // Check for correctness of input and input of the variable x
                {
                    Console.WriteLine("wrong");
                    return;
                }
                else
                {

                }
                number--;
            }
        }

        static bool IsFibonacciNumber(int number)
        {

        }

        static int FibonacciNumber(int number)
        {
            int fibNum = 0,
                prev = 1,
                cur = 1,
                i; 
            while (number > 0)
            {
                fibNum += prev + cur;
                i = cur;
                prev = cur;
                cur = i + prev;
                number--;
            }
            return fibNum;
        }
    }
}
