using System;

namespace Task1
{
    public delegate void Del();

    public class T1
    {
        public static event Del Ev;

        private static void f1() { Console.WriteLine("f1"); }

        private static void f2() { Console.WriteLine("f2"); }
        
        private static void f3() { Console.WriteLine("f3"); }

        public static void Main()
        {
            do
            {
                Console.Clear();

                Ev += f1;
                Ev += f3;
                Ev += f2;
                Ev();

                Console.WriteLine("To exit press Escape key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
