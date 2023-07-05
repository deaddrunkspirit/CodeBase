using System;
using Task2Lib;

namespace Task2
{
    public class T2
    {
        public static void Main()
        {
            Console.WriteLine("***** Using delegates to manage events *****\n");

            Car c1 = new Car("SlugBug", 100, 10);

            // Передаём в машину метод, который будет вызван при отправке оповещения.
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            // Разгоняем машину
            Console.WriteLine("***** Increasing speed *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            Console.ReadLine();
        }

        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message from an object of type Car *****");
            Console.WriteLine($"=> {msg}");
            Console.WriteLine("***********************************\n");

        }

    }
}
