using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("To continue press ENTER");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.Clear();
                Console.Write("Input four-digit number: ");
                int.TryParse(Console.ReadLine(), out int num);
                if ((num / 10000 == 0) && (num / 1000 != 0))
                {
                    Console.WriteLine("The result is: {0}", Reverse(num));
                }
                else
                {
                    Console.WriteLine("Your input is incorrect!");
                }
                Console.WriteLine("To continue press any key");
                Console.WriteLine("To exit the programm press ESCAPE key");

            }
        }

        static int Reverse(int x)
        {
            // Reverse - is a methot which turn the number upside down
            int res = x % 10 * 1000 + x / 10 % 10 * 100 + x / 100 % 10 * 10 + x / 1000;
            return res;
        }
    }
}
