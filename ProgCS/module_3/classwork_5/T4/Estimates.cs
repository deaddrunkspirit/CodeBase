using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Estimates
    {
        public Estimates()
        {
            Count = 0;
        }

        private double xSum, xSumSquare;

        public double XMin { get; private set; }

        public double XMax { get; private set; }

        public int Count { get; private set; }

        public double Average => (xSum / Count);

        private double Dispersion
            => xSumSquare / (Count - 1) - xSum * xSum / (Count * (Count - 1));

        public double Deviation => Math.Sqrt(Dispersion);

        public void Add(double newValue)
        {
            if (Count == 0)
            {
                XMin = newValue;
                XMax = newValue;
                Count = 1;
                xSum = newValue;
                xSumSquare = Math.Pow(newValue, 2);
            }
            else
            {
                XMax = newValue > XMax ? newValue : XMax;
                XMin = newValue < XMin ? newValue : XMin;
                Count++;
                xSum += newValue;
                xSumSquare += Math.Pow(newValue, 2.0);
            }
        }
    }
}