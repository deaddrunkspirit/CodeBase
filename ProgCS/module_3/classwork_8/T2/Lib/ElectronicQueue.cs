using System;
using System.Collections.Generic;

namespace Task2Lib
{
    public class ElectronicQueue<T> where T : struct
    {
        private Queue<T> electronicQueue = new Queue<T>();

        public void AddToElectronicQueue(T person)
            => electronicQueue.Enqueue(person);

        public string CallFromElectronicQueue()
        {
            if (electronicQueue.Count == 0)
                throw new ArgumentException("Queue is empty");
            return electronicQueue.Peek().ToString();
        }

        public void DeleteFromElectronicQueue()
        {
            if (electronicQueue.Count == 0)
                throw new ArgumentException("Queue is empty");
            electronicQueue.Dequeue();
        }
    }
}