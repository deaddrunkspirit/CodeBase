using System;

namespace Task2Lib
{
    public class Car
    {
        public delegate void CarEngineHandler(string msgForCaller);

        private CarEngineHandler listOfHandlers;

        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers = methodToCall;
        }

        public void Accelerate(int delta)
        {
            // Если машина сломана, отправляем оповещение.
            if (carIsDead)
            {
                if (listOfHandlers != null)
                    listOfHandlers("Car broken :( ...");
            }
            else
            {
                CurrentSpeed += delta;
                // Машина почти сломана?
                if (10 == (MaxSpeed - CurrentSpeed)
                && listOfHandlers != null)
                {
                    listOfHandlers("Warning! Be careful");

                }
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine($"Speed = {CurrentSpeed}");
            }
        }

        public int CurrentSpeed { get; set; }

        public int MaxSpeed { get; set; }

        public string PetName { get; set; }

        private bool carIsDead;

        public Car() { MaxSpeed = 100; }

        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }
    }
}
