namespace Task5Lib
{
    public abstract class Animal
    {
        protected Animal(int age)
        {
            Age = age;
        }

        public int Age { get; private set; }

        public override string ToString()
            => $"{this.GetType().Name}\nAge: {Age}";
    }
}