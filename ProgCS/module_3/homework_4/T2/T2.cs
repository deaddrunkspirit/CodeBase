using System;
using Task2Lib;

namespace Task2
{
    public class T2
    {
        private static Random rnd = new Random();

        public static void Main()
        {
            var circleCenter = new Dot(rnd.Next(-10, 10), rnd.Next(-10, 10));
            var circle = new Circle(circleCenter, rnd.Next(10));

            Console.WriteLine($"Current circle:\n{circle}");

            circleCenter.ChangeAbscissEvent += delegate
            {
                Console.WriteLine($"X was changed\n{circle}");
            };

            circleCenter.ChangeOrdinateEvent += delegate
            {
                Console.WriteLine($"Y was changed\n{circle}");
            };

            ChangeDotParametrs(circle);
        }

        private static void ChangeDotParametrs(Circle circle)
        {
            do
            {
                int choice = ChooseWhatToChange();
                double newValue = GetDouble();
                switch (choice)
                {
                    case 1:
                        circle.Center.X = newValue;
                        break;

                    case 2:
                        circle.Center.Y = newValue;
                        break;
                }
                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo change block's side again press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static int ChooseWhatToChange()
        {
            Console.WriteLine("\n\n1. Change X\n2. Change Y");
            return GetInt("Your choice: ", 1, 2);
        }

        private static double GetDouble(string message = "Input new value: ",
            double lowerBound = int.MinValue, double upperBound = int.MaxValue)
        {
            Console.Write(message);
            double number;
            while (!double.TryParse(Console.ReadLine(), out number) ||
                number <= lowerBound || number > upperBound)
                Console.WriteLine
                    ($"Please input real number in [{lowerBound}, {upperBound}]");

            return number;
        }

        private static int GetInt(string message = "Your choice: ",
            int lowerBound = 0, int upperBound = int.MaxValue)
        {
            Console.Write(message);
            int number;
            while (!int.TryParse(Console.ReadLine(), out number) ||
                number < lowerBound || number > upperBound)
                Console.WriteLine
                    ($"Please input real number in [{lowerBound}, {upperBound}]");

            return number;
        }
    }
}