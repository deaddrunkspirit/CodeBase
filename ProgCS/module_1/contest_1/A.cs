using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A
{
    class Program
    {
        static void Main()
        {
            int a, b;
            if (!int.TryParse(Console.ReadLine(), out a))
            // проверка на правильность ввода и ввод переменной a
            {
                Console.WriteLine("wrong");
                return;
            }
            if (!int.TryParse(Console.ReadLine(), out b))
            //  проверка на правильность ввода и ввод переменной b
            {
                Console.WriteLine("wrong");
                return;
            }
            Change(ref a, ref b);
            Console.WriteLine($"{a} {b}");
        }

        static void Change(ref int FirstNum, ref int SecondNum)
        {
            // Change - метод меняющий местами значения двух целочисленных переменных 
            FirstNum += SecondNum;
            SecondNum = FirstNum - SecondNum;
            FirstNum -= SecondNum;
        }
    }
}
