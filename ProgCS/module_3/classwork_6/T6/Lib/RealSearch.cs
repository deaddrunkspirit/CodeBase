using System;

namespace Task6Lib
{
    public class RealSearch : IInterFunction, IInterRoot
    {
        private readonly double lowerBound;
        private readonly double upperBound;
        private readonly double epsilon;
        private int iterationCount;

        public RealSearch(double lowerBound, double upperBound, double epsilon)
        {
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
            this.epsilon = epsilon;
            iterationCount = 0;
        }

        public int IterationQuality
        {
            get
            {
                if (iterationCount == 0)
                    RootSearch();
                return iterationCount;
            }
        }

        double IInterFunction.ArifmeticFunction(double r)
            => Math.Sin(r);

        public double RootSearch()
        {
            double x = lowerBound, y = upperBound, c, fc,
                fx = ((IInterFunction)this).ArifmeticFunction(x),
                fy = ((IInterFunction)this).ArifmeticFunction(y);
            if (fx * fy > 0)
                throw new ArgumentException("Error in root localisation!");
            do
            {
                c = (y + x) / 2;
                fc = ((IInterFunction)this).ArifmeticFunction(c);
                if (fc * fx > 0)
                {
                    x = c;
                    fx = fc;
                }
                else
                {
                    y = c;
                    fy = fc;
                }
                iterationCount++;
            } while (fc != 0 && y - x > epsilon);

            return c;
        }
    }
}