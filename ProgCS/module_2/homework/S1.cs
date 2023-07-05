using System;

namespace S1
{
    class Circle
    {
        double _r;

        public Circle()
        {
            _r = 1;
        }

        public Circle(double radius)
        {
            _r = radius;
        }

        public double S { get { return Math.PI * Math.Pow(_r, 2); } }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                do
                {
                    double rMin = GetDouble("Input minimum radius: ", 0, Double.MaxValue);
                    double rMax = GetDouble("Input maximur radius: ", 1, Double.MaxValue);
                    double delta = GetDouble("Input delta: ", 0, Double.MaxValue);
                    // Input

                    while (rMin <= rMax)
                    {
                        var circle = new Circle(rMin);
                        Console.WriteLine($"Square of radius {rMin} is: {circle.S}");
                        rMin += delta;
                    }
                    // Output

                    Console.WriteLine("To exit press Escape key");
                    Console.WriteLine("To continue press any key . . .");
                    // Messege to continue running programm
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// This method gets double integer in [lower, upper]
        /// </summary>
        /// <param name="str">message</param>
        /// <param name="lower">lower bound</param>
        /// <param name="upper">upper bound</param>
        /// <returns></returns>
        private static double GetDouble(string str, double lower, double upper)
        {
            double n;
            Console.Write(str);
            while (!double.TryParse(Console.ReadLine(), out n) || n < lower || n > upper)
            {
                Console.WriteLine("Please input double number");
                Console.ReadKey();
            }

            return n;
        }
    }
}
