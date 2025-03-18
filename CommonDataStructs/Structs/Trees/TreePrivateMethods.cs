using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDataStructs.Structs
{
    public partial class Tree
    {
        private Node? root;
        private void Insert(Node node, int value)
        {
            if (value < node.value)
            {
                if (node.left is null) node.left = new Node(value);
                else Insert(node.left, value);
            }
            else
            {
                if (node.right is null) node.right = new Node(value);
                else Insert(node.right, value);
            }
        }
        private Node? Search(Node? node, int value)
        {
            if (node is null) return null;
            if (node.value == value) return node;
            return (value < node.value) ? Search(node.left, value) : Search(node.right, value);
        }
        private Node? Delete(Node? node, int value)
        {
            if (node is null) return null;
            else if (value < node.value) node.left = Delete(node.left, value);
            else if (value > node.value) node.right = Delete(node.right, value);
            else
            {
                if (node.left is null || node.right is null)
                {
                    node = (node.left is null) ? node.right : node.left;
                }
                else
                {
                    Node? maxInLeft = GetMax(node.left);
                    node.value = maxInLeft!.value;
                    node.left = Delete(node.left!, maxInLeft.value);
                }
            }
            return node;
        }
        private Node? GetMin(Node? node)
        {
            if (node is null) return null;
            return node.left is null ? node : GetMin(node.left);
        }
        private Node? GetMax(Node? node)
        {
            if (node is null) return null;
            return node.right is null ? node : GetMax(node.right);
        }
        private void Print(Node? node)
        {
            if (node is null) return;
            Print(node.left);
            Console.Write($"{node.value} ");
            Print(node.right);
        }
        private Node? Copy(Node? node)
        {
            if (node is null) return null!;
            Node newNode = new Node(node.value);
            newNode.left = Copy(node.left);
            newNode.right = Copy(node.right);
            return newNode;
        }
    }
}
