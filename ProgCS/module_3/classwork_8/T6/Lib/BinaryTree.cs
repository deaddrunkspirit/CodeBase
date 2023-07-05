using System;

namespace Task6Lib
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public BTnode<T> Root { get; private set; }

        public BinaryTree()
            => Root = null;

        public void Insert(T element)
        {
            if (Root == null)
                Root = new BTnode<T>(element);
            else
                Root.InsertValue(element);
        }

        public bool Empty
            => Root == null;

        public void Preorder(BTnode<T> pt)
        {
            if (pt != null)
            {
                Console.Write(pt.value + " ");
                if (pt.leftChild != null)
                    Preorder(pt.leftChild);
                if (pt.rightChild != null)
                    Preorder(pt.rightChild);
            }
        }

        public void Inorder(BTnode<T> pt, ref string res)
        {
            if (pt != null)
            {
                res += pt.value.ToString() + " ";
                if (pt.rightChild != null)
                    Inorder(pt.rightChild, ref res);
                if (pt.leftChild != null)
                    Inorder(pt.leftChild, ref res);
            }
            return;
        }

        public void Postorder(BTnode<T> pt, ref string res)
        {
            if (pt != null)
            {
                if (pt.rightChild != null)
                    Inorder(pt.rightChild, ref res);
                res += pt.value + " ";
                if (pt.leftChild != null)
                    Inorder(pt.leftChild, ref res);
            }
            return;
        }

        public bool Find(T value)
        {
            if (Root == null)
                return false;
            else return Root.FindValue(value);
        }

        public void Clear()
            => Root = null;

        public void Delete(T value)
        {
            if (Root == null)
                throw new ArgumentException("Tree is empty!");
            if (value.Equals(Root.value))
            {
                Clear();
                return;
            }
            Root.DeleteValue(value);
        }

        public void Print()
        {
            Console.Write($"Binary tree: ");
            Preorder(Root);
            Console.WriteLine();
        }
    }
}