namespace Task5Lib
{
    public class Kangaroo : Animal, IJump
    {
        private readonly int length;

        public Kangaroo(int age, int length) : base(age)
        {
            this.length = length;
        }

        public string Jump()
            => $"Kangaroo jumps on {length} meters";
    }
}