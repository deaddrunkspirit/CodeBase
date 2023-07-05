using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H
{
    class Program
    {
        static void Main()
        {
            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 1028)
            // проверка на правильность ввода и ввод переменной n
            {
                Console.WriteLine("wrong");
                return;
            }
            Console.WriteLine(SumOfCubes(n));
        }

        static string SumOfCubes(int number)
        {
            // SumOfCubes - метод выводящий тва куба чисел
            // из которых состоит число вошедшее в метод или
            // выводится слово impossible
            // 
            // Найдем эти два куба методом перебора, через 2 цикла while
            int i = 0; // - счетчик первого куба
            int j = 0; // - счетчик второго куба

            while (i <= 10)
            {
                // 1й цикл
                while (j <= 10)
                {
                    // 2й цикл
                    if (Math.Pow(i, 3) + Math.Pow(j, 3) == number)
                    {
                        // проверка на равенство числу
                        if (Math.Pow(j, 3) > Math.Pow(i, 3))
                        {
                            // вывод в порядке неубывания
                            return $"{Math.Pow(j, 3)} { Math.Pow(i, 3)}";
                        }
                        else
                        {

                            return $"{Math.Pow(i, 3)} { Math.Pow(j, 3)}";
                        }
                    }
                    j++;
                }
                i++;
            }
            return "impossible";
        }
    }
}