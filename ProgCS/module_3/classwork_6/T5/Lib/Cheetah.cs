namespace Task5Lib
{
    public class Cheetah : Animal, IJump, IRun
    {
        private readonly int speed;

        private readonly int length;

        public Cheetah(int age, int speed, int length) : base(age)
        {
            this.speed = speed;
            this.length = length;
        }

        public string Jump()
            => $"Cheetah jump on {length} meters";

        public string Run()
            => $"Cheetah runs {speed} km/h";
    }
}