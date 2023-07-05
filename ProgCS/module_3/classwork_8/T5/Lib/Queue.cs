using System;
using System.Collections.Generic;

namespace Task5Lib
{
    public class MyQueue<T>
    {
        private const int Capacity = 100;

        private readonly List<T> items = new List<T>(100);

        public bool IsEmpty
            => items.Count == 0;

        public bool IsFull
            => items.Count == Capacity;

        public T FirstElement
        {
            get
            {
                if (items.Count == 0)
                    throw new ArgumentException("The queue is empty!");
                return items[0];
            }
        }

        public T LastElement
        {
            get
            {
                if (IsEmpty)
                    throw new ArgumentException("The queue is empty!");
                return items[items.Count - 1];
            }
        }

        internal void Enqueue(T data)
        {
            if (IsEmpty)
                throw new ApplicationException("The queue is full!");
            items.Insert(0, data);
        }

        /// <summary>
        /// Delete item from queue.
        /// </summary>
        /// <returns></returns>
        internal T Dequeue()
        {
            if (IsEmpty)
                throw new ArgumentException("The queue is empty!");
            var tmp = LastElement;
            items.RemoveAt(items.Count - 1);
            return tmp;
        }

        public override string ToString()
        {
            string result = "";
            for (var i = items.Count - 1; i >= 0; i--)
                result += $"Value: {items[i]}\n";
            return result;
        }
    }
}