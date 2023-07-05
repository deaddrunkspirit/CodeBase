using System;

namespace Task1
{
    public class T1
    {
        public delegate int Cast(double p);

        /// <summary>
        /// Method to round the number to the nearest even number
        /// </summary>
        private static int EvenRound(double number) 
        {
            int res = 0;
            if ((int)number % 2 == 0)
                res = (int)number;
            else
            {
                if (number % 1 != 0)
                    res = (int)number - 1;
                else
                    res = (int)number + 1;
            }
            return res;
        }

        /// <summary>
        /// This method calculates the order of number
        /// </summary>
        private static int Order(double number)
            => (int)Math.Log10(number) + 1;

        /// <summary>
        /// Main plot of the program
        /// </summary>
        public static void Main()
        {
            do
            {
                // First part
                Cast round = new Cast(EvenRound),
                    order = new Cast(Order);
                double[] numbers =
                    { 0.00000001, 123.123123312,
                123142, 2136267.1623421 };
                foreach (double num in numbers)
                    Console.WriteLine($"Number: {num};\nOrder: {order(num)};" +
                        $"\nEven round: {round(num)}");

                // Second part 
                Cast obj1 = (par) =>
                {
                    Console.WriteLine("DEL 1");
                    return (int)Math.Ceiling(par);
                };
                obj1 += (double par) =>
                {
                    Console.WriteLine("DEL 2");
                    return (int)Math.Log10(par) + 1;
                };
                Console.WriteLine(obj1(15.68));
                Console.WriteLine(obj1(4.46));
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
