using System;
using Task1Lib;

namespace Task1
{
    public class T1
    {
        private static Random rnd = new Random();

        public static void Main()
        {
            do
            {
                var blockBase = new Rectangle(rnd.Next(5, 21), rnd.Next(5, 10));
                var block = new Block(blockBase, rnd.Next(1, 10));
                Console.WriteLine($"Current block:\n{block}");
                ChangeBlockSides(block);
                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void ChangeBlockSides(Block block)
        {
            do
            {
                int choice = ChooseSideToChange();
                double newSide = GetDouble();
                switch (choice)
                {
                    case 1:
                        block.Base.SideA = newSide;
                        break;

                    case 2:
                        block.Base.SideB = newSide;
                        break;
                }
                Console.WriteLine($"{block}\n\nTo exit press Escape key" +
                    "\nTo change block's side again press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static int ChooseSideToChange()
        {
            Console.WriteLine("\n\n1. Change side A\n2. Change side B");
            return GetInt("Your choice: ", 1, 2);
        }

        private static double GetDouble(string message = "Input new side's value: ",
            double lowerBound = 0, double upperBound = int.MaxValue)
        {
            Console.Write(message);
            double number;
            while (!double.TryParse(Console.ReadLine(), out number) ||
                number <= lowerBound || number > upperBound)
                Console.WriteLine
                    ($"Please input real number in ({lowerBound}, {upperBound}]");

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