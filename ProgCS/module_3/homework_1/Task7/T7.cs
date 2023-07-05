using System;
using Task7Lib;

namespace Task7
{
    public class T7
    {
        public static void Main()
        {
            MyDel intSum = new MyDel(TestClass.TestMethod);
            do
            { 
                double first = GetDouble("Input first number: "),
                    second = GetDouble("Input second number: ");
                Console.WriteLine($"\nSum of integer parts of two numbers {intSum(first, second):f3}\n\n" +
                    "To exit press Escape key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// This method gets double number from user
        /// </summary>
        /// <param name="mes">message for user</param>
        /// <param name="lower">lower bound of the number value</param>
        /// <param name="upper">upper bound of the number value</param>
        /// <returns></returns>
        private static double GetDouble(string mes = "Input n: ",
            double lower = -999999999, double upper = 999999999)
        {
            double n;
            Console.Write(mes);
            while (!double.TryParse(Console.ReadLine(), out n) || n < lower || n > upper)
                Console.WriteLine($"Please input real number in [{lower:f3}, {upper:f3}]");
            return n;
        }
    }
}
