using System;

namespace Task5
{
    public delegate void RadiusChanged();

    public class Circle
    {
        private int _radius;

        public Circle(int radius)
        {
            if (radius < 0)
                throw new ArgumentOutOfRangeException("Radius can't be negative or 0");
            _radius = radius;
        }

        public int Radius
        {
            get => _radius;
            set
            {
                _radius = value;
                OnRadiusChanged?.Invoke();
            }
        }

        public event RadiusChanged OnRadiusChanged;
    }
}