using System;

namespace S3
{
    public class Complex
    {
        double _a, _b; // поля со значениями действительной и мнимой частей числа

        /// <summary>
        /// конструктор с вещественными параметрами
        /// </summary>
        /// <param name="a">действительная часть</param>
        /// <param name="b">мнимая часть</param>
        public Complex(double a, double b)
        {
            _a = a;
            _b = b;
        }

        /// <summary>
        /// копирующий конструктор, получающий комплексное число как параметр
        /// </summary>
        /// <param name="number">комплексное число</param>
        public Complex(Complex number)
        {
            var copy = new Complex(number._a, number._b);
        }

        /// <summary>
        /// метод, возвращающий действительную часть комплексного числа
        /// </summary>
        /// <returns></returns>
        public double Re() { return _a; }

        /// <summary>
        /// метод, возвращающий мнимую часть комплексного числа
        /// </summary>
        /// <returns></returns>
        public double Im() { return _b; }

        /// <summary>
        /// метод, который показывает модуль комплексного числа
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static double Abs(Complex num)
        {
            return Math.Sqrt(num._a * num._a + num._b * num._b);
        }

        /// <summary>
        /// Метод, который возвращает аргумент комплексного числа
        /// </summary>
        /// <param name="num">комплексное число</param>
        /// <returns></returns>
        public static double Arg(Complex num)
        {
            double res, x = num._a, y = num._b;
            if (x == 0)
            {
                if (y > 0)
                {
                    res = Math.PI / 2;
                }
                else
                {
                    res = -(Math.PI / 2);
                }
            }
            else if (x > 0)
            {
                res = Math.Atan(y / x);
            }
            else
            {
                if (y < 0)
                {
                    res = Math.Atan(y / x) - Math.PI;
                }
                else
                {
                    res = Math.PI + Math.Atan(y / x);
                }
            }

            return res;
        }

        /// <summary>
        /// метод для сложения двух комплексных чисел
        /// </summary>
        /// <param name="first">первое число</param>
        /// <param name="second">второе число</param>
        /// <returns></returns>
        public static Complex Add(Complex first, Complex second)
        {
            double firA = first._a, firB = first._b,
                secA = second._a, secB = second._b;
            var res = new Complex(firA + secA, firB + secB);

            return res;
        }
        /// <summary>
        /// перегрузка метода Add, для сложения комплексного числа с вещественным
        /// </summary>
        /// <param name="first">вещественное число</param>
        /// <param name="sec">комплексное число</param>
        /// <returns></returns>
        public static Complex Add(Complex first, double sec)
        {
            double firA = first._a, firB = first._b;
            var res = new Complex(firA + sec, firB);

            return res;
        }

        /// <summary>
        /// метод для вычетания двух комплексных чисел
        /// </summary>
        /// <param name="first">первое число</param>
        /// <param name="second">второе число</param>
        /// <returns></returns>
        public static Complex Sub(Complex first, Complex second)
        {
            double firA = first._a, firB = first._b,
                secA = second._a, secB = second._b;
            var res = new Complex(firA - secA, firB - secB);

            return res;
        }

        /// <summary>
        /// перегрузка метода Sub, для вычетания из комплексного числа вещественного
        /// </summary>
        /// <param name="first">вещественное число</param>
        /// <param name="sec">комплексное число</param>
        /// <returns></returns>
        public static Complex Sub(Complex first, double sec)
        {
            double firA = first._a, firB = first._b;
            var res = new Complex(firA - sec, firB);

            return res;
        }

        /// <summary>
        /// метод для умножения двух комплексных чисел
        /// </summary>
        /// <param name="first">первое число</param>
        /// <param name="second">второе число</param>
        /// <returns></returns>
        public static Complex Mul(Complex first, Complex second)
        {
            double firA = first._a, firB = first._b,
                secA = second._a, secB = second._b;
            double resA = firA * secA - firB * secB;
            double resB = firA * secB + firB * secA;
            var res = new Complex(resA, resB);

            return res;
        }

        /// <summary>
        /// перегрузка метода Mul, для умножения комплексного числа на вещественное
        /// </summary>
        /// <param name="first">вещественное число</param>
        /// <param name="sec">комплексное число</param>
        /// <returns></returns>
        public static Complex Mul(Complex first, double sec)
        {
            double firA = first._a, firB = first._b;
            var res = new Complex(firA * sec, firB * sec);

            return res;
        }

        /// <summary>
        /// метод для деления двух комплексных чисел
        /// </summary>
        /// <param name="first">первое число</param>
        /// <param name="second">второе число</param>
        /// <returns></returns>
        public static Complex Div(Complex first, Complex second)
        {
            double firA = first._a, firB = first._b,
                secA = second._a, secB = second._b,
                denominator = (secA * secA + secB * secB),
                resA = (firA * secA + firB * secB) / denominator,
                resB = (firB * secA - firA * secB) / denominator;
            var res = new Complex(resA, resB);

            return res;
        }

        /// <summary>
        /// перегрузка метода Div, для деления комплексного числа на вещественное
        /// </summary>
        /// <param name="first">вещественное число</param>
        /// <param name="sec">комплексное число</param>
        /// <returns></returns>
        public static Complex Div(Complex first, double second)
        {
            double firA = first._a, firB = first._b,
                resA = firA / second,
                resB = firB / second;
            var res = new Complex(resA, resB);

            return res;
        }

        /// <summary>
        /// переопределенный унаследованный тип ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string res = "";
            res += _a;
            if (_b == 0)
            {
                return res;
            }
            else if (_b > 0)
            {
                return res += "+" + _b + "i";
            }
            else
            {
                return res += _b + "i";
            }
        }

    }

    class Program
    {
        const double lower = Double.MinValue;
        const double upper = Double.MaxValue;

        static void Main()
        {
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("-------------------------");
                    Console.WriteLine("-------------------------");

                    double a = GetDouble("Input the real part of the first complex number: "),
                        b = GetDouble("Input the imaginary part of the first complex number: ");
                    var first = new Complex(a, b);
                    a = GetDouble("Input the real part of the second complex number: ");
                    b = GetDouble("Input the imaginary part of the second complex number: ");
                    var second = new Complex(a, b);
                    Console.WriteLine("-------------------------");
                    Console.WriteLine("-------------------------");

                    Console.WriteLine("first + second = " + Complex.Add(first, second));
                    Console.WriteLine("first - second = " + Complex.Sub(first, second));
                    Console.WriteLine("first * second = " + Complex.Mul(first, second));
                    Console.WriteLine("first / second = " + Complex.Div(first, second));

                    Console.WriteLine("-------------------------");
                    Console.WriteLine("-------------------------");

                    int lambda = GetInt("Choose the complex number to see Abs and Arg (from 1 or 2): ", 1, 2);
                    switch (lambda)
                    {
                        case 1:
                            double n = GetDouble("Input some double value :");
                            Console.WriteLine($"Info about {first} number:");
                            Console.WriteLine($"{first} + {n} = " + Complex.Add(first, n));
                            Console.WriteLine($"{first} - {n} = " + Complex.Sub(first, n));
                            Console.WriteLine($"{first} * {n} = " + Complex.Mul(first, n));
                            Console.WriteLine($"{first} / {n} = " + Complex.Div(first, n));
                            Console.WriteLine("Abs: " + Complex.Abs(first));
                            Console.WriteLine("Arg: " + Complex.Arg(first));
                            Console.WriteLine("The real part of the number is: " + first.Re());
                            Console.WriteLine("The imaginary part of the number is: " + first.Im());
                            break;
                        case 2:
                            n = GetDouble("Input some double value :");
                            Console.WriteLine($"Info about {second} number:");
                            Console.WriteLine($"{second} + {n} = " + Complex.Add(second, n));
                            Console.WriteLine($"{second} - {n} = " + Complex.Sub(second, n));
                            Console.WriteLine($"{second} * {n} = " + Complex.Mul(second, n));
                            Console.WriteLine($"{second} / {n} = " + Complex.Div(second, n));
                            Console.WriteLine("Abs: " + Complex.Abs(second));
                            Console.WriteLine("Arg: " + Complex.Arg(second));
                            Console.WriteLine("The real part of the number is: " + second.Re());
                            Console.WriteLine("The imaginary part of the number is: " + second.Im());
                            break;
                    }
                    Console.WriteLine("To exit press Escape key");
                    Console.WriteLine("To continue press any key");
                    Console.WriteLine("-------------------------");
                    Console.WriteLine("-------------------------");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }

        /// <summary>
        /// метод для получения целочисленного значения в зааных границах
        /// </summary>
        /// <param name="str">сообщение</param>
        /// <param name="lower">нижняя граница</param>
        /// <param name="upper">верхняя граница</param>
        /// <returns></returns>
        private static int GetInt(string str, int lower, int upper)
        {
            int n;
            Console.Write(str);
            while (!int.TryParse(Console.ReadLine(), out n) || n < lower || n > upper)
            {
                Console.WriteLine($"Please input integer in [{lower}, {upper}]");
            }

            return n;
        }

        private static double GetDouble(string str)
        {
            double n;
            Console.Write(str);
            while (!double.TryParse(Console.ReadLine(), out n) || n < lower || n > upper)
            {
                Console.WriteLine("Please input double number");
            }

            return n;
        }
    }
}