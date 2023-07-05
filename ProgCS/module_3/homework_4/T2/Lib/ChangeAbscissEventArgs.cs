using System;

namespace Task2Lib
{
    public class ChangeAbscissEventArgs : EventArgs
    {
        public ChangeAbscissEventArgs(double x)
        {
            X = x;
        }

        public double X { get; }
    }
}