using System;

namespace Task2Lib
{
    public class Publisher
    {
        public delegate void EventHappened();

        public event EventHappened somethingHappened;

        public void fireEvent()
        {
            Console.WriteLine("Fire somethingHappened!!!");
            somethingHappened();
        }
    }
}
