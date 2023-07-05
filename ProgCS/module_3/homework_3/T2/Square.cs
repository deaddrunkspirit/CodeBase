using System;

namespace Task2Lib
{
    public delegate void SquareSizeChanged(double par);

    public class Square
    {
        private double _x1, _y1, // upper left corner coordinates
            _x2, _y2; // lower right corner coordinayes

        public Square(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public static event SquareSizeChanged OnSizeChanged;

        public double Side => Math.Abs(_x1 - _x2);

        public double X1
        {
            get { return _x1; }
            private set
            {
                _x1 = value;
                OnSizeChanged?.Invoke(Side);
            }
        }

        public double Y1
        {
            get { return _y1; }
            private set
            {
                _y1 = value;
                OnSizeChanged?.Invoke(Side);
            }
        }

        public double X2
        {
            get { return _x2; }
            set
            {
                _x2 = value;
                OnSizeChanged?.Invoke(Side);
            }
        }

        public double Y2
        {
            get { return _y2; }
            set
            {
                _y2 = value;
                OnSizeChanged?.Invoke(Side);
            }
        }
    }
}
