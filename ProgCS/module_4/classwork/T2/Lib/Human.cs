using System;

namespace Task2Lib
{
    [Serializable]
    public class Human
    {
        public string Name { get; set; }
        
        public Human() { }

        public Human(string name) =>
            Name = name;

    }
}
