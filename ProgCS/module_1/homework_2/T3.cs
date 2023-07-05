using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please press any key.");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.Clear();
                Console.Write("Input A: "); double.TryParse(Console.ReadLine(), out double a);
                Console.Write("Input B: "); double.TryParse(Console.ReadLine(), out double b);
                Console.Write("Input C: "); double.TryParse(Console.ReadLine(), out double c);
                Console.WriteLine(QuadEq(a, b, c));
                Console.WriteLine("To continue press any key");
                Console.WriteLine("To exit the programm press ESCAPE");
            }
            
        }

        public static string QuadEq(double a, double b, double c)
        {
            // метод который высчитывает значение корней, либо указывает, что корни комплексны
            double D = b * b - 4 * a * c;
            double x1 = (-b + Math.Sqrt(D)) / (2 * a); 
            double x2 = (-b - Math.Sqrt(D)) / (2 * a);
            x1.ToString("G3"); x2.ToString("G3");
            string res;
            // используем тернарную операцию, для определения дескриминанта
            res = D >= 0 ? "X1 = " + x1 + ", X2 = " + x2 : "The roots are complex";
            return res;
        } 
       

    }
}
