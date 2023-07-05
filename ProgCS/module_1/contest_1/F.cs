using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F
{
    class Program
    {
        static void Main()
        {
            double a;
            int n;
            if (!double.TryParse(Console.ReadLine(), out a))
            // проверка на правильность ввода и ввод переменной a
            {
                Console.WriteLine("wrong");
                return;
            }
            if (!int.TryParse(Console.ReadLine(), out n) || n < 0)
            //  проверка на правильность ввода и ввод переменной n
            {
                Console.WriteLine("wrong");
                return;
            }
            Console.WriteLine(SumOfGeometrProgress(a, n).ToString("g3"));
            Console.ReadLine();
        }

        static double SumOfGeometrProgress(double a, int n)
        {
            // SumOfGeometrProgress - метод высчитывающий сумму ( 1 + a  + a ^ 2 + ... + a ^ n ) 
            double sum = 0;
            while (n >= 0)
            {
                sum += Math.Pow(a, n);
                n--;
            }
            return sum;
        }
    }
}
