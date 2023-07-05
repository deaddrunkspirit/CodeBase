using System;
using Task2Lib;

namespace Task2
{
    public class T2
    {
        public static void Main()
        {
            do
            {
                var me = new Expression(x => { return x * x + 2 * x - 3; });
                var vs = new ValueStore(me, 0);
                me.OnExpChanged += vs.OnExpChangeHandler;
                Console.WriteLine(vs.CurrVal);
                me.Ex = x => { return Math.Sqrt(Math.Abs(x)); };
                Console.WriteLine(vs.CurrVal);
                me.Ex = x => { return Math.Sin(x); };
                Console.WriteLine(vs.CurrVal);
                me.Ex = x => { return x * x * x - 1; };
                Console.WriteLine(vs.CurrVal + "\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}