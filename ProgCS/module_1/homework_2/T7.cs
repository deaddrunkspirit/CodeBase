using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task07
{
    class Program
    {
        static public void Main()
        {
            Console.WriteLine("Please press ENTER.");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                double fric, sq, sqrt;
                int intg;
                Console.Clear();
                Console.Write("Input real number:");
                double.TryParse(Console.ReadLine(), out double num);
                FracNInt(num, out intg, out fric);
                SqNSqrt(num, out sqrt, out sq);
                Console.WriteLine($"{sqrt:g4} - is square root of the number");
                Console.WriteLine("{0} - is square of the number", sq.ToString("g4"));
                Console.WriteLine("{0} - integer part of the number", intg);
                Console.WriteLine("{0} - frictional part of the number", fric.ToString("g4"));
                Console.WriteLine("To continue press any key");
                Console.WriteLine("To exit the programm press ESCAPE");
            }
        }

        static void FracNInt(double num, out int intg, out double fric)
        {
            // этот метод возвращает целую часть числа и дробную часть числа
            intg = Convert.ToInt32(Math.Floor(num));    // intg -  целая часть числа
            fric = num - intg;              // fric -  дробная часть числа
            return;
            
        }

        static void SqNSqrt(double num, out double sqrt, out double sq)
        {
            // SqNSqrt - метод, который получает на вход вещественное число и возводит его в квадрат и 2 степень и возвращает эти значения
            sq = Math.Pow(num, 2);  // sq - квадрат числа
            sqrt = Math.Sqrt(num);  // sqrt - квадратный корень числа
            return;
        }
    }
}
