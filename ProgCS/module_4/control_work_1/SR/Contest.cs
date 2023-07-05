using System;

namespace SR
{
    public partial class Program
    {
        [Serializable]
        public class Contest : ControlElement
        {
            private int taskNumber;

            public int TaskNumber
            {
                get => taskNumber;
                set
                {
                    if (value < 1 || value > 10)
                        throw new ArgumentException("Invalid taskNumber");
                    taskNumber = value;
                }
            }

            public Contest()
            {
            }

            public Contest(double weight, string name, int taskNumber) : base(weight, name)
            {
                TaskNumber = taskNumber;
            }
        }
    }
}
