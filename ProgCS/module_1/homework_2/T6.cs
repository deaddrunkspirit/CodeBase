using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please press ENTER.");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.Clear();;
                Console.WriteLine("Input Budget (rub): ");
                double.TryParse(Console.ReadLine(), out double budget);
                Console.WriteLine("Input games percentage of budget (integer): ");
                Console.WriteLine(double.TryParse(Console.ReadLine(), out double per));
                Console.WriteLine("You have {0} rubels for computer games", PercentOfSmth(budget, per));
                Console.WriteLine("To continue press any key");
                Console.WriteLine("To exit the programm press ESCAPE");
            }
        }

        static double PercentOfSmth(double number, double percent)
        {
            // PercentOfSmth - метод который получает на вход дробное значение number - сумму бюджета
            // и целое значение percent - количество процентов бюджета, отведенных на компьютерные игры
            // и выводит значение result - деньги выделенные на компьютерные игры
            double result = number * (percent / 100);
            return result;
        }
    }
}
