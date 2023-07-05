namespace Task5Lib
{
    public class Cockroach : Animal, IRun
    {
        private readonly int speed;

        public Cockroach(int age, int speed) : base(age)
        {
            this.speed = speed;
        }

        public string Run()
            => $"Cockroach's speed is {speed} km/h";

        public override string ToString()
            => $"Cockroach";
    }
}