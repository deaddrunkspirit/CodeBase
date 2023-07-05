using System;

namespace Task4Lib
{
    public class Stack<ItemType>
    {
        private static int stackSize = 100;

        private ItemType[] items = new ItemType[stackSize];

        private int index = 0;

        public void Push(ItemType data)
        {
            if (index == stackSize)
                throw new ApplicationException("Stack is full!");
            items[index++] = data;
        }

        public ItemType Pop()
        {
            if (index == 0)
                throw new ApplicationException("Stack is empty!");
            return items[--index];
        }
    }
}