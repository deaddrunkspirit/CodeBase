using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("To continue please press any key");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.Clear();
                MirrorTriNum(out int s, out int num);
                Console.WriteLine($"The number is: {s}");
                Console.WriteLine($"The last member of the sequence is: {num}");
                Console.WriteLine($"S = 1 + 2 + 3 + ... + {num - 2} + {num - 1} + {num}");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("To continue press any key");
                Console.WriteLine("To exit press ESCAPE");
            }
            
        }

        public static void MirrorTriNum(out int s, out int num)
        {
            /* Метод, который находит число s, являющееся сумой арифметической прогрессии
             полледний элемент которого - num */ 
            s = 1;   // изнаальное значение суммы (когда количество членов равно 0
            num = 1; // счетчик, который показывает последний элемент последовательности
            while ((s % 10 != s / 10 % 10) && (s % 10 != s / 100))
            {
                num++;
                s = (1 + num) / 2 * num;
            }
        }
    }
}
