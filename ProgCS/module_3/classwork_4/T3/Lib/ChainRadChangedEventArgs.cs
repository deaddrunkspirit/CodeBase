using System;
using System.Collections.Generic;
using System.Text;

namespace Task3Lib
{
    public class ChainRadChangedEventArgs : EventArgs
    {
        public ChainRadChangedEventArgs(int beadsCount)
        {
            BeadsCount = beadsCount;
        }

        public double BeadsCount { get; }
    }
}