using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please press ENTER.");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.Clear();
                Console.Write("Input A: "); double.TryParse(Console.ReadLine(), out double a);
                Console.Write("Input B: "); double.TryParse(Console.ReadLine(), out double b);
                Console.Write("Input C: "); double.TryParse(Console.ReadLine(), out double c);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("a = {0}, b = {1}, c = {2}", a.ToString("G3"), b.ToString("G3"), c.ToString("G3"));
                Console.WriteLine(IneqTriang(a, b, c));
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("To continue press any key");
                Console.WriteLine("To exit the programm press ESCAPE");
            }
        }
        static string IneqTriang(double a, double b, double c)
        {
            bool sign = a < b + c && b < a + c && c < a + b;
            string report = sign ? "a, b, c - sides of triangle" : "Triangle can not be build";
            return report;
        }
    }
}
