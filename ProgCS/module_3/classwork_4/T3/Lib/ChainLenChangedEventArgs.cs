using System;
using System.Collections.Generic;
using System.Text;

namespace Task3Lib
{
    public class ChainLenChangedEventArgs : EventArgs
    {
        public ChainLenChangedEventArgs(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; }
    }
}