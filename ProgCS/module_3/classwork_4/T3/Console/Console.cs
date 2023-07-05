using System;
using Task3Lib;

namespace Task3Console
{
    public class T3Console
    {
        public static void Main()
        {
            do
            {
                double length = 20;
                int beadsCount = 5, choice = 4;
                try
                {
                    var chain = new Chain(length, beadsCount);
                    Console.WriteLine($"Default chain:\n{chain}");
                    ShowMenu();
                    do
                    {
                        try
                        {
                            choice = GetInt("Press 1, 2, 3 or 4: ", 1, 4);
                            Changes(ref choice, ref chain);
                        }
                        catch (ArgumentOutOfRangeException e)
                        { Console.WriteLine(e.Message); }
                    } while (choice != 4);
                }
                catch (ArgumentOutOfRangeException e)
                { Console.WriteLine(e.Message); }
                Console.WriteLine("\n\nTo continue press any key" +
                    "\nTo exit press Escape key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\n\nPress number key to navigate\n" +
                "1.\tChange chain's length\n" +
                "2.\tChange the count of beads\n" +
                "3.\tChange the radius of each bead\n" +
                "4.\tExit menu\n");
        }

        private static int GetInt(string message = "Input n: ",
            int lowerBound = 0, int upperBound = int.MaxValue)
        {
            Console.Write(message);
            int number;
            while (!int.TryParse(Console.ReadLine(), out number) ||
                number < lowerBound || number > upperBound)
                Console.WriteLine
                    ($"Please input integer number in [{lowerBound}, {upperBound}]");

            return number;
        }

        private static double GetDouble(string message = "Input n: ",
            double lowerBound = 0, double upperBound = double.MaxValue)
        {
            Console.Write(message);
            double number;
            while (!double.TryParse(Console.ReadLine(), out number) ||
                number < lowerBound || number > upperBound)
                Console.WriteLine
                    ($"Please input real number in [{lowerBound}, {upperBound}]");

            return number;
        }

        private static void Changes(ref int choice, ref Chain chain)
        {
            switch (choice)
            {
                case 1:
                    ChangeLen(chain);
                    break;

                case 2:
                    ChangeBeadsCount(chain);
                    break;

                case 3:
                    ChangeBeadRadius(chain);
                    break;

                case 4:
                    break;
            }
        }

        public static void ChangeLen(Chain chain)
        {
            double newLength = GetDouble("Input new length of chain: ", 0, int.MaxValue);
            chain.Length = newLength;
            Console.Clear();
            Console.WriteLine($"Current chain:\n{chain}");
        }

        public static void ChangeBeadsCount(Chain chain)
        {
            int newBeadsCount = GetInt("Input new count of beads: ");
            chain.BeadsCount = newBeadsCount;
            Console.Clear();
            Console.WriteLine($"Current chain:\n{chain}");
        }

        public static void ChangeBeadRadius(Chain chain)
        {
            double newRadius = GetDouble("Input new radius: ");
            chain.Radius(newRadius);
            Console.Clear();
            Console.WriteLine($"Current chain:\n{chain}");
        }
    }
}