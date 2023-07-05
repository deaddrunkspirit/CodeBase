using System;

namespace Task6Lib
{
    public class BTnode<T> where T : IComparable<T>
    {
        public T value;
        private int count;
        public BTnode<T> leftChild;
        public BTnode<T> rightChild;

        public BTnode(T value)
        {
            this.value = value;
            count = 1;
            leftChild = rightChild = null;
        }

        public void InsertValue(T value)
        {
            if (value.Equals(this.value))
                count++;
            else if (value.CompareTo(this.value) < 0)
                if (leftChild == null)
                    leftChild = new BTnode<T>(value);
                else
                    leftChild.InsertValue(value);
            else
                if (rightChild == null)
                rightChild = new BTnode<T>(value);
            else
                rightChild.InsertValue(value);
        }

        public bool FindValue(T value)
        {
            if (value.Equals(this.value))
                return true;
            else if (value.CompareTo(this.value) < 0)
            {
                if (leftChild == null)
                    return false;
                else
                    return leftChild.FindValue(value);
            }
            else
            {
                if (rightChild == null)
                    return false;
                else
                    return rightChild.FindValue(value);
            }
        }

        public void DeleteValue(T value)
        {
            if (leftChild != null)
                if (leftChild.value.Equals(value))
                {
                    leftChild = null;
                    return;
                }

            if (rightChild != null)
                if (rightChild.value.Equals(value))
                {
                    rightChild = null;
                    return;
                }

            if (value.CompareTo(this.value) < 0)
            {
                if (leftChild == null)
                    throw new Exception("Value doesn't exist in the tree");
                else
                    leftChild.DeleteValue(value);
            }
            else
            {
                if (rightChild == null)
                    throw new Exception("Value doesn't exist in the tree");
                else
                    rightChild.DeleteValue(value);
            }
        }
    }
}