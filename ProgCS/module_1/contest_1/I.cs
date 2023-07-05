using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I
{
    class Program
    {
        static void Main()
        {
            int N;
            if (!int.TryParse(Console.ReadLine(), out N) || N < 1)
            // проверка на правильность ввода и ввод переменной N
            {
                Console.WriteLine("wrong");
                return;
            }
            Console.WriteLine(IsPow2(N));
            Console.ReadLine();
        }

        static string IsPow2(int number)
        {
            // IsPow2 - метод определяющий, является ли число
            // точной степенью двойки
            int reminder = 0;
            if (number == 1)
            {
                // 1 - степень двойки, но в основном цикле не учтется
                // поэтому отдельно проверим не является ли число единицей
                return "YES";
            } 

            // reminder - остатки от деления на 2
            while (number > 1)
            {
                // этот цикл подсчитывает сумму остатков от деления на 2
                reminder += number % 2;
                number /= 2; 
            }
            if (reminder == 0)
            {
                // этот оператор определяет было  ли число степенью двойки
                return "YES";
            }
            else
            {
                return "NO";
            }

        }
    }
}
