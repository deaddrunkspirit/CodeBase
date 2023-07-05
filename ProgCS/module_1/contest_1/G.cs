using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G
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
            Console.WriteLine(SumOfSequence(N).ToString("g6"));
            Console.ReadLine();
        }

        static double SumOfSequence(double number)
        {
            // SumOfSequence - метод считающий сумму 
            // ( 1 / 1! + 1/ 2! + ... + 1 / N!)
            double sum = 0;
            while (number >= 0)
            { 
                sum += 1 / Factorial(number);
                number--;
            }
            return sum;
        }

        static double Factorial(double number)
        {
            // Factorial - метод высчитывающий факториал числа
            double comp = 1;
            // comp - значение факториала (изначально = 1, 
            // так как факториал - произведение)
            if (number == 0)
            {
                // 0! = 1, следовательно для того, чтобы не 
                // получить в ответе 0, сделаем 0! - исключением
                return comp;
            }
            while (number > 0)
            {
                comp *= number;
                number--;
            }
            return comp;
        }
    }
}
