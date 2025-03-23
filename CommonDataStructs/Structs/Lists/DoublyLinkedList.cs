using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDataStructs.Structs.Lists
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private DoublyLinkedListNode<T>? head;
        private DoublyLinkedListNode<T>? tail;
        private int count;
        public int Count => count;
        public T Head
        {
            get
            {
                if (head is not null)
                {
                    return head.value;
                }
                else
                {
                    throw new ArgumentNullException(nameof(head));
                }
            }
        }
        public T Tail
        {
            get
            {
                if (tail is not null)
                {
                    return tail.value;
                }
                else
                {
                    throw new ArgumentNullException(nameof(tail));
                }
            }
        }
        public void AddStart(T value)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }
            count++;
        }
        public void AddEnd(T value)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value);
            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.prev = tail;
                tail = newNode;
            }
            count++;
        }
        public void AddAfter(DoublyLinkedListNode<T> node, T value)
        {
            ValidateNode(node);
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value);
            if (node == tail)
            {
                tail.next = newNode;
                newNode.prev = tail;
                tail = newNode;
            }
            else
            {
                newNode.next = node.next;
                node.next!.prev = newNode;

                node.next = newNode;
                newNode.prev = node;
            }
            count++;
        }
        public void AddBefore(DoublyLinkedListNode<T> node, T value)
        {
            ValidateNode(node);
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value);
            if (node == head)
            {
                head.prev = newNode;
                newNode.next = head;
                head = newNode;
            }
            else
            {
                newNode.prev = node.prev;
                node.prev!.next = newNode;

                node.prev = newNode;
                newNode.next = node;
            }
            count++;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (DoublyLinkedListNode<T>? current = head; current != null; current = current.next)
            {
                yield return current.value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class DoublyLinkedListNode<T>
        {
            public readonly T value;
            public DoublyLinkedListNode<T>? next;
            public DoublyLinkedListNode<T>? prev;
            public DoublyLinkedListNode(T value)
            {
                this.value = value;
            }
        }
        private void ValidateNode(DoublyLinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
        }
    }
}

