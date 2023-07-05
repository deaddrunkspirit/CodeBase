using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task002
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("To continue press Enter");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                int num, max;
                Console.Write("Input some three-digit number: ");
                int.TryParse(Console.ReadLine(), out num);
                Console.WriteLine("The biggest number is {0}", MaxNumber(num));
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
            int max = 0;

            if (a > b)
            {
                if (a > c)
                {
                    max += a * 100;
                    if (b > c)
                    {
                        max += b * 10 + c;
                        return max;
                    }
                    else
                    {
                        max += c * 10 + b;
                        return max;
                    }
                }
            }

            else if (b > a)
            {
                if (b > c)
                {
                    max += b * 100;
                    if (a > c)
                    {
                        max += a * 10 + c;
                        return max;
                    }
                    else
                    {
                        max += c * 10 + a;
                        return max;
                    }
                }
            }

            else if (c > b)
            {
                if (c > a)
                {
                    max += c * 100;
                    if (b > a)
                    {
                        max += b * 10 + a;
                        return max;
                    }
                    else
                    {
                        max += a * 10 + b;
                        return max;
                    }
                }
            }
            else if (a = b)
            {
                if (a > c) 
                {
                    max += a * 100 + b * 10 + c;
                    return max;
                }
                else 
                {
                    max += c * 100 + b * 10 + a;
                }    
    

            }

            ;
        }
    }
}
