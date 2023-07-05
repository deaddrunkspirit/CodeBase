using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To continue press Enter");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.Clear();
                Console.Write("Input x : ");
                int x;
                int.TryParse(Console.ReadLine(), out x); // Считываем значение х
                int res = Fx(x);                         // Применяем функцию F(x)
                Console.WriteLine("F(x) = {0}", res);
                Console.WriteLine("To continue press any key.");
                Console.WriteLine("To exit press ESCAPE key.");
            }



        }
        public static int Fx(int x) // Создадим метод, который высчитывает F(x)
        {
            int a = x * x;  // Для минимизации умножения назначим переменную а, которая является 3й степенью х
            int f = (12 * a * a) + (9 * a * x) - (3 * a) + (2 * x) - 4;
            return f;
        }
    }
}
