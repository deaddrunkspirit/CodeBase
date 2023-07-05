using System;
using Task2Lib;
using Task2LibOther;


namespace Task2
{
    public class T2
    {
        /// <summary>
        /// Main plot of the program
        /// </summary>
        public static void Main() 
        {
            do
            {
                Delegate1 make = new Delegate1(Methods.ArrayOfDigits);
                Delegate2 print = new Delegate2(Methods.PrintIntArray);
                int number = 56743;
                int[] numArr = make(number);
                int[] numbers = 
                    { 12, 34, 21, 78, 93, 90, 15, 55, 88, 83};
                Console.WriteLine($"Delegate1\nMethod: {make.Method}\nTarget: {make.Target}" +
                    $"\n\nDelegate2\nMethod: {print.Method}\nTarget: {print.Target}\n1 test (number):");
                print(numArr);
                Console.WriteLine("2 test (array):");
                print(numbers);
                Console.WriteLine("\n\nTo exit press Escape" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
