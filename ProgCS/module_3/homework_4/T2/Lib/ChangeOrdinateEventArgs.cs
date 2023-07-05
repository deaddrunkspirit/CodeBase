using System;

namespace Task2Lib
{
    public class ChangeOrdinateEventArgs : EventArgs
    {
        public ChangeOrdinateEventArgs(double y)
        {
            Y = y;
        }

        public double Y { get; }
    }
}