using System;
using MyClassLibrary;

/*  ФИО         Мосолков Евгений Николаевич
 *  Группа      БПИ196
 *  Вариант     1
 *  Дисциплина  Программирование
 */

namespace SR2Events
{
    public class Program
    {
        public static void Main()
        {
            do
            {
                Console.Clear();

                int n = GetInt("Input N: ", 1, 20);
                OnCountListener listener1 = new OnCountListener(2),
                listener2 = new OnCountListener(3);
                Counter counter = new Counter(n);
                counter.countEvent += listener1.OnCount;
                counter.countEvent += listener2.OnCount;
                counter.Count();

                Console.WriteLine("To exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static int GetInt(string message = "Input N: ",
            int lowerBound = 0, int upperBound = int.MaxValue)
        {
            Console.Write(message);
            int number;
            while (!int.TryParse(Console.ReadLine(), out number)
                || number < lowerBound || number > upperBound)
                Console.WriteLine
                    ($"Please input integer number in [{lowerBound}, {upperBound}]");

            return number;
        }
    }
}