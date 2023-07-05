using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C
{
    class C
    {
        static void Main()
        {
            double firstSide = 0, secondSide = 0;
            if (!CorrectInput(Console.ReadLine(), Console.ReadLine(),
                 ref firstSide, ref secondSide))
            {
                Console.WriteLine("wrong");
            }
            else
            {
                Console.WriteLine($"{RectanglePerimetr(firstSide, secondSide):f3} " +
                    $"{RectangleArea(firstSide, secondSide):f3}");
            }
        }

        /// <summary>
        /// This method checks the variables for the 
        /// correctness of their type and positivity
        /// </summary>

        static bool CorrectInput(string inputFirst, string inputSecond,
            ref double firstSide, ref double secondSide)
        {
            bool res = double.TryParse(inputFirst, out firstSide)
                && double.TryParse(inputSecond, out secondSide)
                && firstSide > 0 && secondSide > 0;
            return res;
        }

        /// <summary>
        /// This method calculates the area on two sides
        /// of a rectangle
        /// </summary>

        static double RectangleArea(double firstSide, double secondSide)
        {
            return firstSide * secondSide;
        }

        /// <summary>
        /// This method calculates the perimetr
        /// on two sides of a rectangle
        /// </summary>

        static double RectanglePerimetr(double firstSide, double secondSide)
        {
            return (firstSide + secondSide) * 2;
        }
    }
}
