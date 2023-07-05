using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E
{
    class Program
    {
        static void Main()
        {
            int FirstNum, SecondNum, ThirdNum;
            if (!int.TryParse(Console.ReadLine(), out FirstNum))
            // проверка на правильность ввода и ввод переменной ThirdNum
            {
                Console.WriteLine("wrong");
                return;
            }
            if (!int.TryParse(Console.ReadLine(), out SecondNum))
            // проверка на правильность ввода и ввод переменной SecondNum
            {
                Console.WriteLine("wrong");
                return;
            }
            if (!int.TryParse(Console.ReadLine(), out ThirdNum))
            // проверка на правильность ввода и ввод переменной ThirdNum
            {
                Console.WriteLine("wrong");
                return;
            }
            Console.WriteLine(Is3NumEqal(FirstNum, SecondNum, ThirdNum));
            Console.ReadLine();
        }

        static int Is3NumEqal(int First, int Second, int Third)
        {
            // - метод который определяет количество совпадающих чисел
            if (First == Second && Second == Third)
            {
                return 3;
            }
            else if (First != Second && Second != Third && Third != First)
            {
                return 0;
            }
            else
            {
                return 2;
            }
        }
    }
}
