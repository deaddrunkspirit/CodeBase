using System;

namespace Task3Lib
{
    public class RightCone
    {
        public RightCone(Point top, double x, double y, double z, double radius)
        {
            Top = top;
            Base = new Circle(x, y, z, radius);
        }

        public Circle Base { get; private set; }

        public Point Top { get; private set; }

        /// <summary>
        /// This method calculates section of the cone
        /// </summary>
        /// <returns></returns>
        public double Section()
        {
            double distance = Base.Center.Distance(Top),
                inclined = Math.Sqrt(Math.Pow(Base.Radius, 2) + Math.Pow(distance, 2)),
                halfPerimetr = (Base.Radius * 2 + inclined * 2) / 2,
                section = Math.Sqrt(halfPerimetr * (halfPerimetr - Base.Radius * 2) *
                (halfPerimetr - inclined) * (halfPerimetr - inclined));

            return section;
        }

        public override string ToString()
            => $"Right cone:\n\tTop\n\t\t{Top}\n\tBase:\n\t{Base}";
    }
}