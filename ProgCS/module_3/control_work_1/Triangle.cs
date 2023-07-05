using System;

namespace SR
{
    public class Triangle
    {
        /// <summary>
        /// This field is triangle side a
        /// </summary>
        private double _a;

        /// <summary>
        /// This field is triangle side b
        /// </summary>
        private double _b;

        /// <summary>
        /// This field is triangle side c
        /// </summary>
        private double _c;

        /// <summary>
        /// This constructor with 3 parametrs creates an instant of Triangle type
        /// </summary>
        /// <param name="a">siade a</param>
        /// <param name="b">side b</param>
        /// <param name="c">side c</param>
        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Triangle sides can't be negative!");
            if (a > b + c || b > a + c || c > a + b)
                throw new ArgumentException("Triangle inequality is false!");
            _a = a;
            _b = b;
            _c = c;
        }

        /// <summary>
        /// This method identifies triangle
        /// </summary>
        public static void Identify(int x) 
        { 
            Console.WriteLine($"Я - метод который не использует x = {x}"); 
        }

        /// <summary>
        /// This mehod expands all sides of 
        /// triangle multiplying them on x
        /// </summary>
        public void Expand(int x)
        {
            _a *= x;
            _b *= x;
            _c *= x;
            Console.WriteLine($"Expanded sides:\na = {_a:f3}\nb = {_b:f3}\nc = {_c:f3}");
        }

        /// <summary>
        /// This method prints perimetr * x
        /// </summary>
        public void MultPer(int x)
        {
            Console.WriteLine($"Perimetr * x: {(_a + _b + _c) * x:f3}");
        }
    }
}
