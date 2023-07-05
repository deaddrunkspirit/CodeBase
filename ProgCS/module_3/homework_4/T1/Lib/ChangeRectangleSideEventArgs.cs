using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Lib
{
    public class ChangeRectangleSideEventArgs : EventArgs
    {
        public ChangeRectangleSideEventArgs(double newSideA, double newSideB)
        {
            SideA = newSideA;
            SideB = newSideB;
        }

        public double SideA { get; set; }

        public double SideB { get; set; }
    }
}