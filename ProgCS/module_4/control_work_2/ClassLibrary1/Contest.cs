using System;

namespace ClassLibrary1
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
                    throw new ArgumentException("Invalid task number");
                taskNumber = value;
            }
        }

        public Contest(int taskNumber, int weight, string name) : base(weight, name)
        {
            TaskNumber = taskNumber;
        }

        public Contest() { }

        public override string ToString()
            => "\nContest\n" + base.ToString() + $"Task number: {TaskNumber}"; 
    }
}
