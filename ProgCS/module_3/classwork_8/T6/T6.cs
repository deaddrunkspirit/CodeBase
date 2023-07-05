using System;
using Task6Lib;

namespace Task6
{
    public class T6
    {
        public static void Main()
        {
            do
            {
                Console.Clear();

                var binaryTree = new BinaryTree<string>();
                binaryTree.Insert("Me");
                binaryTree.Insert("Mom");
                binaryTree.Insert("Dad");
                binaryTree.Insert("Dad's dad");
                binaryTree.Insert("Mom's mom");
                binaryTree.Insert("Dad's mom");
                binaryTree.Insert("Mom's dad");
                binaryTree.Print();

                var intBinaryTree = new BinaryTree<int>();
                intBinaryTree.Insert(-4);
                intBinaryTree.Insert(9);
                intBinaryTree.Insert(3);
                intBinaryTree.Insert(7);
                intBinaryTree.Insert(-4);
                intBinaryTree.Insert(9);
                intBinaryTree.Print();

                Console.WriteLine("Preorder: ");
                binaryTree.Preorder(binaryTree.Root);
                Console.WriteLine();

                string inorderInfo = "";
                binaryTree.Inorder(binaryTree.Root, ref inorderInfo);
                Console.WriteLine("Inorder: " + inorderInfo);

                string postorderInfo = "";
                binaryTree.Postorder(binaryTree.Root, ref postorderInfo);
                Console.WriteLine("Postorder: " + postorderInfo);

                binaryTree.Delete("Mom's dad");
                binaryTree.Print();

                Console.Beep();
                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}