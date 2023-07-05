using System;

namespace Task1Lib
{
    public struct TestStruct : IComparable<TestStruct>
    {
        public int x;

        public int CompareTo(TestStruct another)
            => x > another.x ? 1 : x < another.x ? -1 : 0;
    }
}