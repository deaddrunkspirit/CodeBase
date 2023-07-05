using System;

namespace Task1Lib
{
    public class Rectangle
    {
        public event EventHandler<ChangeRectangleSideEventArgs> ChangeRectangleSideEvent;

        private double _sideA, _sideB;

        public Rectangle(double sideA, double sideB)
        {
            SideA = sideA;
            SideB = sideB;
        }

        public double SideA
        {
            get { return _sideA; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Rectangle side can't be negative or 0");
                _sideA = value;
                OnChangeRectangle(new ChangeRectangleSideEventArgs(_sideA, _sideB));
            }
        }

        public double SideB
        {
            get { return _sideB; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Rectangle side can't be negative or 0");
                _sideB = value;
                OnChangeRectangle(new ChangeRectangleSideEventArgs(_sideA, _sideB));
            }
        }

        public virtual void OnChangeRectangle(ChangeRectangleSideEventArgs e)
        {
            ChangeRectangleSideEvent?.Invoke(this, e);
        }

        public double Area => SideA * SideB;

        public override string ToString()
            => $"Rectangle\n\tSide A: {SideA:f3}\n\tSide B: {SideB:f3}";
    }
}