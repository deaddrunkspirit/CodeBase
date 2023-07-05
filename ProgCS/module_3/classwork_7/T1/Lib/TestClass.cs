using System;

namespace Task1Lib
{
    public class TestClass : IComparable<TestClass>
    {
        public int X { get; set; }

        public int CompareTo(TestClass another)
            => X > another.X ? 1 : X < another.X ? -1 : 0;
    }
}