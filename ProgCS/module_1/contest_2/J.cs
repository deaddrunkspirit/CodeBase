using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J
{
    class J
    {
        static void Main()
        {
            double A, B, C, D;
            if (!double.TryParse(Console.ReadLine(), out A) || A < 0)
            /// Check for correctness of input and input of the variable A
            {
                Console.WriteLine("wrong");
                return;
            }

            if (!double.TryParse(Console.ReadLine(), out B) || B < 0)
            /// Check for correctness of input and input of the variable B
            {
                Console.WriteLine("wrong");
                return;
            }

            if (!double.TryParse(Console.ReadLine(), out C) || C < 0)
            /// Check for correctness of input and input of the variable C
            {
                Console.WriteLine("wrong");
                return;
            }

            if (!double.TryParse(Console.ReadLine(), out D) || D < 0)
            /// Check for correctness of input and input of the variable D
            {
                Console.WriteLine("wrong");
                return;
            }

            double maxG = -(A * B);
            int numberOfPairs = Function(A, B, C, D, ref maxG);
            Console.WriteLine(numberOfPairs);
            Console.WriteLine(maxG);

        }

        /// <summary>
        /// This method returns the number of pairs x and y when max(G(x, y)),
        /// also it returns maximum of G(x, y) 
        /// </summary>

        static int Function(double A, double B, double C, double D, ref double max)
        {
            int x = -50;
            int y = -50;
            int i = 0; /// counter
            while (x <= 50)
            {
                while (y <= 50)
                {

                    double functionF = A * Math.Sin(B * x)
                        + C * (Math.Pow(Math.Cos(D * y), 3));
                    /// Function F(x, y)
                    double functionG =
                        Math.Round(functionF, MidpointRounding.AwayFromZero);
                    /// Function G(x, y) = [F(x, y)]
                    if (functionG > max)
                    {
                        max = functionG;
                        i = 0;
                    }
                    if (functionG == max)
                    {
                        i++;
                    }
                    y++;
                }
                y = -50;
                x++;
            }
            return i;


        }
    }
}
