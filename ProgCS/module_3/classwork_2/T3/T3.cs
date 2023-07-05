using System;
using Numerical;

namespace Task3
{
    public class T3
    {
        /// <summary>
        /// Main plot of the program
        /// </summary>
        public static void Main()
        {
            do
            {
                // Bisec test
                function[] funcArr = {
                    F, (x) => Math.Log10(x),
                    delegate(double x) { return Math.Log10(x); },
                    Math.Log10
                };
                string[] names = { "My function: ", "Math.Log: ", "Anonimus method: ", "Lambda: " };
                Console.WriteLine("Bisec test\n-----------------");
                for (int i = 0; i < funcArr.Length; i++)
                {
                    Console.Write($"{names[i]}\n" +
                        $"Minimal value = {NumMeth.Bisec(0, 1, 0.001, 0, funcArr[i])}\n\n");
                }
                Console.WriteLine("\n\nOptimum_1 test\n-----------------");
                // Optimum_1 test
                var methods = new NumMeth();
                function f1 = (double x) => Math.Cos(x);
                double a1 = 3, b1 = 6;
                function f2 = (double x) => x * (x * x - 2) - 5;
                double a2 = 0, b2 = 1;
                function f3 = (double x) => -Math.Sin(x) - Math.Sin(3 * x) / 3;
                Console.WriteLine($"f1: {NumMeth.Optimum_1(f1, a1, b1, 0.0001, 0.0001)}\n" +
                    $"f2: {NumMeth.Optimum_1(f2, a2, b2, 0.0001, 0.0001)}\n" +
                    $"f3: {NumMeth.Optimum_1(f3, a2, b2, 0.0001, 0.0001)}\n\n" +
                    $"To exit press Escape key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Custom function to find log
        /// </summary>
        /// <param name="x">argument</param>
        /// <returns></returns>
        private static double F(double x)
            => Math.Log10(x);
    }
}
