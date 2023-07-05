using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G
{
    class G
    {
        static void Main()
        {
            int count, i = 1;

            if (!int.TryParse(Console.ReadLine(), out count) || count < 1 || count > 255)
            /// Check for correctness of input and input of the variable count
            {
                Console.WriteLine("wrong");
                return;
            }
            Console.WriteLine(IsInGap(i, ref count));
        }

        /// <summary>
        /// This method determines whether the number is in the specified range
        /// </summary>
        /// <param name="i">counter</param>
        /// <param name="count">number of digits</param>
        /// <returns></returns>
        /// 
        static string IsInGap(int i, ref int count)
        {
            int input;
            if (int.TryParse(Console.ReadLine(), out input) && input >= 0 && input < 3)
            /// Check for correctness of input and input of the variable count
            {
                /// the given range is a number 0.(1) in ternary 
                /// number system that's why we use recursive algorithm 
                /// to find if this number is in range
                if (input != 1)
                /// condition in which the number is not in range
                {
                    return Convert.ToString(i);
                }
                if (i == count)
                /// condition in which the number is in range
                {
                    return "yes";
                }
                i++;
                return IsInGap(i, ref count);/// recursive algorithm
            }
            else
            {
                return "wrong";
            }
        }
    }
}

