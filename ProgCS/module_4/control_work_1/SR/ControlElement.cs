using System;

namespace SR
{
    public partial class Program
    {
        [Serializable]
        public class ControlElement
        {
            public double weight;

            private string name;

            public string Name
            {
                get => name;
                set => name = value;
            }

            private double Weight
            {
                get => weight;
                set
                {
                    if (value <= 0 || value > 80)
                        throw new ArgumentException("Invalid weight");
                    weight = value;
                }
            }

            public ControlElement() { }

            public ControlElement(double weight, string name)
            {
                Name = name;
                Weight = weight;
            }
        }
    }
}
