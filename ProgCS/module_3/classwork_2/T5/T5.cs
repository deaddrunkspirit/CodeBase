using System;

namespace Task5
{
    public class T5
    {
        /// <summary>
        /// Main plot of the program
        /// </summary>
        public static void Main()
        {
            do
            {
                Console.Clear();
                double[] arr = new double[5];
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = GetDouble($"Input {i + 1} number: ");
                PrintArr(arr);
                try
                {
                    NormArr(ref arr);
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine(e.Message);
                }
                PrintArr(arr, "Norm array:\t");
                Array.Sort(arr,
                    (x, y) =>
                    {
                        if (x < y) return 1;
                        if (x == y) return 0;
                        return -1;
                    });
                PrintArr(arr, "Sorted 1:\t");
                Array.Sort(arr,
                    (x, y) =>
                    {
                        if (x % 2 != 0 && y % 2 == 0) return 1;
                        if (x == y) return 0;
                        return -1;
                    });
                PrintArr(arr, "Sorted 2:\t");
                Console.WriteLine("\n\nTo exit press Escape key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// This method divides every number by the absolute maximum in this array
        /// </summary>
        /// <param name="arr">array of double numbers</param>
        private static void NormArr(ref double[] arr)
        {
            double max = double.MinValue;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] != 0 && Math.Abs(arr[i]) > max)
                    max = arr[i];
            arr = Array.ConvertAll(arr, n => n / max);
        }

        /// <summary>
        /// This mehod prints a double array
        /// </summary>
        /// <param name="arr">array of double number</param>
        /// <param name="mes">message</param>
        public static void PrintArr(double[] arr, string mes = "Array:\t\t")
        {
            Console.Write($"\n{mes}");
            Array.ForEach(arr, el => Console.Write($"{el:f3}\t"));
            Console.WriteLine();
        }

        /// <summary>
        /// This method gets an integer number from user
        /// </summary>
        /// <param name="mes">message for user</param>
        /// <param name="lower">lower bound of the number value</param>
        /// <param name="upper">upper bound of the number value</param>
        /// <returns></returns>
        private static double GetDouble(string mes = "Input some int: ",
            double lower = double.MinValue, double upper = double.MaxValue)
        {
            double num;
            Console.Write(mes);
            while (!double.TryParse(Console.ReadLine(), out num) || num < lower || num > upper)
                Console.WriteLine($"Please input double number in [{lower}, {upper}]");
            return num;
        }
    }
}
