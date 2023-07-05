using System;

namespace ClassLibrary1
{
    [Serializable]
    public class ControlElement
    {
        public string Name { get; set; }

        private int weight;

        public int Weight
        {
            get => weight;
            set
            {
                if (weight <= 0 || weight > 80)
                    weight = value;
            }
        }

        public ControlElement() { }

        public ControlElement(int weight, string name)
        {
            Name = name;
            Weight = weight;
        }

        public override string ToString()
            => $"Name: {Name}, Weight {weight}";
    }
}
