﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDataStructs.Structs.Lists
{
    public class DoublyLinkedList<T>
    {
        private DoublyLinkedListNode? head;
        private DoublyLinkedListNode? tail;
        private int count;
        public int Count => count;
        public void AddStart(T value)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(value);
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
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(value);
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
        private class DoublyLinkedListNode
        {
            public readonly T value;
            public DoublyLinkedListNode? next;
            public DoublyLinkedListNode? prev;
            public DoublyLinkedListNode(T value) 
            {
                this.value = value;
            }
        }
    }
}

