using System;

namespace SR
{
    public class Var1
    {
        /// <summary>
        /// Delegate with 1 integer parametr (returns nothing)
        /// </summary>
        public delegate void TriangleDelegate(int x);

        /// <summary>
        /// Main plot of the program
        /// </summary>
        public static void Main()
        {
            do // repeat cycle
            {
                try
                {
                    Triangle triangle = new Triangle(GetDouble(),
                        GetDouble("Input side b: "), GetDouble("Input side c: "));
                    TriangleDelegate f = Triangle.Identify;
                    f += triangle.Expand;
                    f += triangle.MultPer;
                    f(GetInt());
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                
                Console.WriteLine("To exit press Escape key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// This method gets an integer number from user
        /// </summary>
        /// <param name="mes">message for user</param>
        /// <param name="lower">lower bound of number value</param>
        /// <param name="upper">upper bound of number value</param>
        /// <returns></returns>
        private static double GetDouble(string mes = "Input side a: ", 
            double lower = 0, double upper = double.MaxValue)
        {
            Console.Write(mes);
            double number;
            while (!double.TryParse(Console.ReadLine(), out number) || number <= lower || number > upper)
                Console.WriteLine($"Please input real number in ({lower}, {upper}]");
            return number;
        }

        /// <summary>
        /// This method getsan integer number from user
        /// </summary>
        /// <param name="mes">message for user</param>
        /// <param name="lower">lower bound of number value</param>
        /// <param name="upper">upper bound of number value</param>
        /// <returns></returns>
        private static int GetInt(string mes = "Input x: ",
            int lower = 0, int upper = int.MaxValue)
        {
            Console.Write(mes);
            int number;
            while (!int.TryParse(Console.ReadLine(), out number) || number < lower || number > upper)
                Console.WriteLine($"Please input integer number in [{lower}, {upper}]");
            return number;
        }
    }
}
