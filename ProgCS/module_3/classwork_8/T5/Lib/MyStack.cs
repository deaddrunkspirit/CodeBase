namespace Task5Lib
{
    public class MyStack<T>
    {
        private const int maxStack = 10;

        private T[] stackArray;

        private int stackPointer = 0;

        public MyStack()
            => stackArray = new T[maxStack];

        private bool IsStackFull
            => stackPointer >= maxStack;

        private bool IsStackEmpty
            => stackPointer <= 0;

        public void Push(T x)
        {
            if (!IsStackFull)
                stackArray[stackPointer++] = x;
        }

        public T Pop()
            => !IsStackEmpty ? stackArray[--stackPointer] : stackArray[0];

        public override string ToString()
        {
            string result = "";
            for (int i = stackPointer - 1; i >= 0; i--)
                result += $"Value: {stackArray[i]}";
            return result;
        }
    }
}