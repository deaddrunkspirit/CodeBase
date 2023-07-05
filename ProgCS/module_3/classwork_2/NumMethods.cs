using System;

namespace Numerical
{
    public delegate double function(double x);

    public class NumMeth
    {
        /// <summary>
        ///  This method finds the real root 
        ///  of a function of one argument on a given interval.
        /// </summary>
        /// <param name="a">lower bound</param>
        /// <param name="b">upper bound</param>
        /// <param name="epsX">required accuracy x</param>
        /// <param name="epsY">yequired accuracy y</param>
        /// <param name="f">function</param>
        /// <returns></returns>
        public static double Bisec(double a, double b, 
            double epsX, double epsY, function f)
        {
            double x = a, y = f(x), z;
            if (Math.Abs(y) <= epsY)
                return x;
            x = b; z = f(x);
            if (Math.Abs(z) <= epsY)
                return x;
            if (y * z > 0)
                throw new Exception("The interval does not localize the root of the function!");
            do
            {
                x = a / 2 + b / 2; y = f(x);
                if (Math.Abs(y) <= epsY)
                    return x;
                if (y * z > 0)
                    b = x;
                else
                    a = x;
            } while (Math.Abs(b - a) >= epsX);
            return x;
        }

        /// <summary>
        /// This method finds maximum value on segment with given accuracy
        /// </summary>
        /// <param name="f">function</param>
        /// <param name="a">lower bound</param>
        /// <param name="b">upper</param>
        /// <param name="delta">accuracy x</param>
        /// <param name="epsilon">accuracy y</param>
        /// <returns></returns>
        public static double Optimum_1(function f, double a, double b, 
            double delta, double epsilon)
        {
            double rOne = (Math.Sqrt(5) - 1) / 2,
                rTwo = rOne * rOne,
                yA = f(a), yB = f(b), h = b - a,
                c = a + rTwo * h, d = a + rOne * h,
                p, yC = f(c), yP, yD = f(d);
            while (Math.Abs(yA - yB) > epsilon || h > delta)
                if (yC < yD)
                {
                    b = d; yB = yD;
                    d = c; yD = yC;
                    h = b - a;
                    c = a + rTwo * h;
                    yC = f(c);
                }
                else
                {
                    a = c; yA = yC;
                    c = d; yC = yD;
                    h = b - a;
                    d = a + rOne * h;
                    yD = f(d);
                }
            p = a; yP = yA;
            if (yB < yA)
            { p = b; yP = yB; }
            return p;

        }
    }
}
