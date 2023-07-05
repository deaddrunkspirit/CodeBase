using System;
using System.Collections.Generic;

namespace Task5Lib
{
    public struct SetOfMassPoint
    {
        private readonly MassPoint[] set;
        public double Radius { get; private set; }

        public SetOfMassPoint(MassPoint[] collection, PointS point, double radius)
        {
            List<MassPoint> list = new List<MassPoint>();
            foreach (var massPoint in collection)
                if (massPoint.Coord.Distance(point) <= radius)
                    list.Add(massPoint);
            set = list.ToArray();
            this.Radius = radius;
        }

        public MassPoint MassCenter
        {
            get
            {
                double xc = 0, yc = 0, mc = 0;
                foreach (var massPoint in set)
                {
                    mc += massPoint.Mass;
                    xc += massPoint.Mass * massPoint.Coord.X;
                    yc += massPoint.Mass * massPoint.Coord.Y;
                }

                return new MassPoint(new PointS(xc / mc, yc / mc), mc);
            }
        }
    }
}