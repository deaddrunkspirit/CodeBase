using System;
using Task5Lib;

namespace Task5
{
    public class T5
    {
        private static Random rnd = new Random();

        public static void Main()
        {
            do
            {
                Console.Clear();
                Animal[] zoo = GenerateZoo();
                foreach (var animal in zoo)
                {
                    Console.WriteLine(animal);
                    if (animal is IJump)
                        Console.WriteLine(((IJump)animal).Jump());
                    if (animal is IRun)
                        Console.WriteLine(((IRun)animal).Run());
                    Console.Beep();
                    Console.WriteLine("\n\nTo exit press Escape key" +
                        "\nTo continue press any key . . .");
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static Animal[] GenerateZoo()
        {
            var zoo = new Animal[10];
            for (int i = 0; i < zoo.Length; i++)
                switch (rnd.Next(0, 3))
                {
                    case 0:
                        zoo[i] = new Cockroach(rnd.Next(0, 5), rnd.Next(3, 8));
                        break;

                    case 1:
                        zoo[i] = new Kangaroo(rnd.Next(0, 30), rnd.Next(1, 5));
                        break;

                    case 2:
                        zoo[i] = new Cheetah(rnd.Next(0, 30),
                            rnd.Next(70, 120), rnd.Next(3, 8));
                        break;
                }
            return zoo;
        }
    }
}