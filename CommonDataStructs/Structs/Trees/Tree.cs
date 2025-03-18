using System;

namespace CommonDataStructs.Structs
{
    public partial class Tree
    {

        public void Insert(int value)
        {
            if (root is null)
                root = new Node(value);
            else
                Insert(root, value);
        }
        public Node? Search(int value)
        {
            return Search(root, value);
        }
        public Node? Delete(int value)
        {
            return Delete(root, value);
        }
        public Node? GetMin()
        {
            return GetMin(root);
        }
        public Node? GetMax()
        {
            return GetMax(root);
        }
        public void Print()
        {
            Print(root);
            Console.WriteLine();
        }
        public Tree Copy()
        {
            Tree tree = new Tree();
            tree.root = Copy(root);
            return tree;
        }
        public class Node
        {
            public int value;
            public Node? left;
            public Node? right;

            public Node(int value)
            {
                this.value = value;
            }
        }
    }
}
