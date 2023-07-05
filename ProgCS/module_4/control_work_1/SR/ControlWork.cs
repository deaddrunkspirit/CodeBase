using System;

namespace SR
{
    public partial class Program
    {
        [Serializable]
        public class ControlWork : ControlElement
        {
            private int variant;

            public int Variant
            {
                get => variant;
                set
                {
                    if (value < 0)
                        throw new ArgumentException("Invalid variant");
                }
            }

            public ControlWork(double weight, string name, int variant) : base(weight, name)
            {
                Variant = variant;
            }
        }
    }
}
