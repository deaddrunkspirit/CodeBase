using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B
{
    class Program
    {
        static void Main()
        {
            int FourDigNum; 
            // FourDigNum - полученное на вход четырехзначное число
            if (!int.TryParse(Console.ReadLine(), out FourDigNum) || FourDigNum > 9999 || FourDigNum < 1000)
            // проверка на правильность ввода и ввод переменной FourDigNum
            {
                Console.WriteLine("wrong");
                return;
            }
            Console.WriteLine(IsSymmetrical(FourDigNum));
            Console.ReadLine();
        }

        static int IsSymmetrical(int number)
        {
            // IsSymmetrical - метод получающий четырехзначное число
            // и определяющий, является ли это число симметричным 
            int FirstDig = number / 1000;  
            int SecDig = (number / 100) % 10;
            int ThirDig = (number / 10) % 10;
            int FourDig = number % 10;
            // FirstDig, SecDig, ThirDig, FourDig - цифры этого числа
            return (FirstDig - FourDig) * (FirstDig - FourDig) + (SecDig - ThirDig) * (SecDig - ThirDig) + 1;
            // метод возвращает 1 (если число симметричное) или любое другое
            // положительное число (если симметрии нет)

        }
    }
}
