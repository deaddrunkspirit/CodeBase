using System;

namespace Task5
{
    public class T5
    {
		/// <summary>
		/// Main plot of the programm
		/// </summary>
        public static void Main()
        {
			// delegate for multiplication
			Func<double, int, int, double> mul = (x, i, jmax) => {
				double res = 1;
				for (int j = 1; j <= jmax; j++) 
					res *= i * x / j;
				return res;
			};

			// delegate for sum of compositions
			Func<double, int, double> sum = (x, imax) => {
				double res = 0;
				for (int i = 1; i <= imax; i++)
					res += mul(x, i, 5);
				return res;
			};

			do
			{
				double number = GetDouble("Input some real number: ");
				Console.WriteLine($"\nResult: {sum(number, 5)}\n\n" +
					"To exit press Escape key\nTo continue press any key . . .");
			} while (Console.ReadKey().Key != ConsoleKey.Escape);
		}

		/// <summary>
		/// This method gets a double number from user
		/// </summary>
		/// <param name="mes">message for user</param>
		/// <param name="lower">lower bound of number value</param>
		/// <param name="upper">upper bound of number value</param>
		/// <returns></returns>
		private static double GetDouble(string mes = "Input n: ", 
			double lower = 0, double upper = 999999999)
		{
			double n;
			Console.Write(mes);
			while (!double.TryParse(Console.ReadLine(), out n) || n < lower || n > upper)
				Console.WriteLine($"Input real number in [{lower}, {upper}]");
			return n;
		}
    }
}
