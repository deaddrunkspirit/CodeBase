using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Lib
{
    public class Cylinder : ITransform
    {
        private Circle cylinderBase = new Circle();

        private double height = 1;

        public void Transform(double coefficent)
            => height *= coefficent;

        public override string ToString()
            => $"Cylinder volume: {cylinderBase.Area * height:g4}";
    }
}