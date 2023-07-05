namespace Task2Lib
{
    public struct Person
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Person(string name, string lastName, int age)
        {
            Age = age;
            Name = name;
            LastName = lastName;
        }

        public override string ToString()
            => $"{Name} {LastName} {Age}";
    }
}