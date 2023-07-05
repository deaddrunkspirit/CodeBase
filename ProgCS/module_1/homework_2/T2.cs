using System;

namespace Task02
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("To continue press Enter");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.Clear();
                Console.Write("Input some three-digit number: ");
                int.TryParse(Console.ReadLine(), out int num);
                if ((num / 100 != 0) && (num / 1000 == 0))
                {
                    Console.WriteLine("The biggest number is {0}", MaxNumber(num));
                }
                else
                {
                    Console.WriteLine("Incorrect Input");
                }
                Console.WriteLine("To continue press any key.");
                Console.WriteLine("To exit press ESCAPE key.");
            }
        }



        static public int MaxNumber(int num)
        {
            /* MaxNumber - метод который получает число и выводит 
               наибольшее число составленное из цифр исходного */
            int a = num / 100;        // a - число из разряда сотен
            int b = (num / 10) % 10;  // b - число из разряда десятков
            int c = num % 10;         // c - число из разряда единиц

            if (a >= b && a >= c)
            {
                if (b >= c)
                {
                    return ThreeDigitNum(a, b, c);
                }
                else
                {
                    return ThreeDigitNum(a, c, b);
                }
            }
            else if (b >= a && b >= c)
            {
                if (a >= c)
                {
                    return ThreeDigitNum(b, a, c);
                }
                else
                {
                    return ThreeDigitNum(b, c, a);
                }
            }
            else if (c >= a && c >= b)
            {
                if (a >= b)
                {
                    return ThreeDigitNum(c, a, b);
                }
                else
                {
                    return ThreeDigitNum(c, b, a);
                }
            }
            else
            {
                return ThreeDigitNum(a, b, c);
            }
        }


        static int ThreeDigitNum(int x, int y, int z)
        {
            int res = x * 100 + y * 10 + z;
            return res;
        }
    }
}

