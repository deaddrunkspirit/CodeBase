using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B
{
    class B
    {
        static void Main()
        {
            int number, baseNumSys;
            // number - a variable that contains a number
            // in the number system with a base - baseNumSys
            if (!int.TryParse(Console.ReadLine(), out baseNumSys)
                || baseNumSys < 2 || baseNumSys > 9)
            // Check for correctness of input and input of the variable baseNumSys
            {
                Console.WriteLine("wrong");
                return;
            }

            if (!int.TryParse(Console.ReadLine(), out number) || number < 0)
            // Check for correctness of input and input of the variable - number 
            {
                Console.WriteLine("wrong");
                return;
            }

            int numCheck = number;
            // numCkeck - is a variable which helps to check the
            // number for belonging to the number system
            while (numCheck != 0)
            // Сhecking the number for belonging to the number system
            {
                if (numCheck % 10 >= baseNumSys)
                {
                    Console.WriteLine("wrong");
                    return;
                }
                numCheck /= 10;
            }

            Console.WriteLine(ConvertFromNumberSystems(number, baseNumSys));
        }

        /// <summary>
        /// a method that receives two variables as input 
        /// and translates the number (number) from the number 
        /// system with the base (baseNumSys) to the decimal number system
        /// </summary>

        static int ConvertFromNumberSystems(int number, int baseNumSys)
        {
            double result = 0, i = 0;
            while (number != 0)
            {
                result += number % 10 * Math.Pow(baseNumSys, i);
                number /= 10;
                i++;
            }
            return Convert.ToInt32(result);
        }
    }
}
