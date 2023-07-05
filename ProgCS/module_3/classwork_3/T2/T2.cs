using System;
using Task2Lib;

namespace Task2
{
    public class T2
    {
        public static void Main()
        {
            var pub = new Publisher();
            var shs = new SomethingHappenedSubscriber();

            do
            {
                Console.Clear();

                pub.somethingHappened += shs.SomethingHappenedHandler;
                pub.fireEvent();

                Console.WriteLine("To exit press Escape key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
