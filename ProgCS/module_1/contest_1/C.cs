using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C
{
    class Program
    {
        static void Main()
        {
            int X;
            if (!int.TryParse(Console.ReadLine(), out X) || 1 > X || X > 100 )
            // проверка на правильность ввода и ввод переменной X
            {
                Console.WriteLine("wrong");
                return;
            }
            Console.WriteLine(ConvToRomSysCalc(X));
        }


        static string ConvToRomSysCalc(int num)
        {
            /* ConvToRomSysCal - метод преобразующий целое число
             * от 1 до 100 из арабской в римскую систему исчисления */
            string res = "";
            switch (num / 10)
            {
            // перевод разряда десятков (и числа 100)
                case 1:
                    res += "X";
                    break;
                case 2:
                    res += "XX";
                    break;
                case 3:
                    res += "XXX";
                    break;
                case 4:
                    res += "XL";
                    break;
                case 5:
                    res += "L";
                    break;
                case 6:
                    res += "LX";
                    break;
                case 7:
                    res += "LXX";
                    break;
                case 8:
                    res += "LXXX";
                    break;
                case 9:
                    res += "XC";
                    break;
                case 10:
                    res += "C";
                    break;

            }

            switch (num % 10)
            {
            // перевод разряда единиц
                case 1:
                    res += "I";
                    break;
                case 2:
                    res += "II";
                    break;
                case 3:
                    res += "III";
                    break;
                case 4:
                    res += "IV";
                    break;
                case 5:
                    res += "V";
                    break;
                case 6:
                    res += "VI";
                    break;
                case 7:
                    res += "VII";
                    break;
                case 8:
                    res += "VIII";
                    break;
                case 9:
                    res += "IX";
                    break;

            }
            return res;
            
        }
    }
}
