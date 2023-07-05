using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D
{
    class Program
    {
        static void Main()
        {
            int FirstSide, SecSide, ThirdSide;
            if (!int.TryParse(Console.ReadLine(), out FirstSide) || 1 > FirstSide)
            // проверка на правильность ввода и ввод переменной FirstSide
            {
                Console.WriteLine("wrong");
                return;
            }
            if (!int.TryParse(Console.ReadLine(), out SecSide) || 1 > SecSide)
            // проверка на правильность ввода и ввод переменной SecSide
            {
                Console.WriteLine("wrong");
                return;
            }
            if (!int.TryParse(Console.ReadLine(), out ThirdSide) || 1 > ThirdSide)
            // проверка на правильность ввода и ввод переменной ThirdSide
            {
                Console.WriteLine("wrong");
                return;
            }
            ValueSort(ref FirstSide, ref SecSide, ref ThirdSide);
            // сортируем полученые значения
            Console.WriteLine(TriangleView(FirstSide, SecSide, ThirdSide));
        }

        static string TriangleView(int a, int b, int c)
        {
            // TriangleView - метод определяющий вид треугольника,
            // получая значения сторон в порядке возрастания значений
            string res = (a * a + b * b > c * c) ? "obtuse" : ((a * a + b * b == c * c) ? "right" : ((a * a + b * b < c * c) ? "acute" : "impossible"));
            return res;
        }

        static void ValueSort(ref int x, ref int y, ref int z)
        {
            // ValueSort - метод сортирующий 3 переменные по возрастанию
            int min = x < y ? (z < x ? z : x) : (y < z ? y : z);
            int max = x > y ? (z > x ? z : x) : (y > z ? y : z);
            y = x + y + z - min - max;
            x = min;
            z = max;

        }
    }
}
