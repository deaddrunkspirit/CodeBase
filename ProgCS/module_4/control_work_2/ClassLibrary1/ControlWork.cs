using System;

namespace ClassLibrary1
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
                if (variant < 0)
                    throw new ArgumentException("Invalid variant");
                variant = value;
            }
        }

        public ControlWork(int variant, int weight, string name) : base(weight, name)
        {
            Variant = variant;
        }

        public ControlWork() { }

        public override string ToString()
            => "\nControl work\n" + base.ToString() + $"Variant: {Variant}";
    }
}
