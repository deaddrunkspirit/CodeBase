using System;

namespace Task8
{
    public delegate double Sum(int n);

    public class T8
    {
        public static void Main()
        {
            Sum[] sums = { FirstSum, SecondSum };
            do
            {
                int count = GetInt();
                Console.WriteLine($"First sum is {sums[0](count):f3}" +
                    $"\nSecond sum is {sums[1](count):f3}\n\n" +
                    $"To exit press Escape key\nTo continue press any key . . ."); 
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// This method gets an integer number from user
        /// </summary>
        /// <param name="mes">message for user</param>
        /// <param name="lower">lower bound of the number value</param>
        /// <param name="upper">upper bound of the number value</param>
        /// <returns></returns>
        private static int GetInt(string mes = "Input the count of sums elements: ",
            int lower = 1, int upper = 999999)
        {
            int number;
            Console.Write(mes);
            while (!int.TryParse(Console.ReadLine(), out number) || number < lower || number > upper)
                Console.WriteLine($"Please input integer number in [{lower}, {upper}]");
            return number;
        }

        /// <summary>
        /// first testing sum
        /// </summary>
        /// <param name="n">count of elements</param>
        /// <returns></returns>
        public static double FirstSum(int n)
        {
            double sum = 0;
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= i; j++)
                    sum += 1 / j;
            return sum;
        }

        /// <summary>
        /// second testing sum
        /// </summary>
        /// <param name="n">count of elements</param>
        /// <returns></returns>
        public static double SecondSum(int n)
        {
            double sum = 0;
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= i; j++)
                    sum += 1 / Math.Pow(2, j);
            return sum;
        } 
    }
}
