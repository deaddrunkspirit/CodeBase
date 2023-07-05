using System;

namespace Task2Lib
{
    public class Dot
    {
        public Dot(double x, double y)
        {
            _x = x;
            _y = y;
        }

        private double _x;

        private double _y;

        public double X
        {
            get => _x;
            set
            {
                _x = value;
                OnXHasChanged(new ChangeAbscissEventArgs(_x));
            }
        }

        public double Y
        {
            get => _y;
            set
            {
                _y = value;
                OnYHasChanged(new ChangeOrdinateEventArgs(_y));
            }
        }

        public event EventHandler<ChangeAbscissEventArgs> ChangeAbscissEvent;

        public event EventHandler<ChangeOrdinateEventArgs> ChangeOrdinateEvent;

        protected virtual void OnXHasChanged(ChangeAbscissEventArgs e) =>
            ChangeAbscissEvent?.Invoke(this, e);

        protected virtual void OnYHasChanged(ChangeOrdinateEventArgs e) =>
            ChangeOrdinateEvent?.Invoke(this, e);

        public override string ToString()
            => $"Dot: x = {X}, y = {Y}";
    }
}