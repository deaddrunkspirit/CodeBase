﻿namespace Task3Lib
{
    public class Fibonacci : ISeries
    {
        private int oldElement, lastElement;

        public Fibonacci() => SetBegin();

        public int this[int i]
        {
            get
            {
                int currentElement = 0;
                SetBegin();
                if (i <= 0)
                    return -1;
                for (int j = 0; j < i; j++)
                    currentElement = GetNext;
                return currentElement;
            }
        }

        public int GetNext
        {
            get
            {
                int now = oldElement + lastElement;
                oldElement = lastElement; lastElement = now;
                return now;
            }
        }

        public void SetBegin()
        {
            oldElement = 0;
            lastElement = 1;
        }
    }
}