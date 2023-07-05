using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J
{
    class Program
    {
        static void Main()
        {
            int A;
            if (!int.TryParse(Console.ReadLine(), out A) || A < 1)
            // проверка на правильность ввода и ввод переменной A
            {
                Console.WriteLine("wrong");
                return;
            }
            Console.WriteLine(FibNum(A));
        }


        static int FibNum(int num)
        {
            // FibNum - метод возвращающий номер числа
            // в последовательности Фибоначчи
            int i = 2;      // - счетчик номера
            int cur = 1;    // - текущий элемент
            int prev = 1;   // - предыдущий элемент
            if (cur > num)
            {
                return -1;
            }
            while (cur <= num)
            {
                if (cur == num)
                {
                    return i;
                }
                int midVal = cur;
                // midVal - промежуточная переменная для сохранения 
                // значения текущего элемента
                cur += prev;
                prev = midVal;
                i++;
            }
            return -1;
        }
    }
}
