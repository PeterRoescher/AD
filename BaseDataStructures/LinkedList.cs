using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BaseDataStructures.Interfaces;

namespace BaseDataStructures
{
    public class LinkedList<T> : ISimpleLinkedList<T>
    {
        protected Node<T> _headerNode;

        public int Length { get; protected set; }
        public void Insert(int index, T data)
        {
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));

            Node<T> node = _headerNode;
            Node<T> previousNode = null;
            int i = 0;
            while (i < index)
            {
                previousNode = node;
                if (previousNode == null) throw new ArgumentOutOfRangeException(nameof(index));
                node = node.NextNode;
                i++;
            }

            previousNode.NextNode = new Node<T>(data);
            previousNode.NextNode.NextNode = node;
            Length++;
        }
        public void AddFirst(T data)
        {
            var currentHeaderNode = _headerNode;
            _headerNode = new Node<T>(data);
            _headerNode.NextNode = currentHeaderNode;
            Length++;
        }
        public void RemoveFirst()
        {
            if (_headerNode == null) throw new Exception("List is empty");

            _headerNode = _headerNode.NextNode;
            Length--;
        }
        public T GetFirst()
        {
            if (_headerNode == null) throw new Exception("List is empty");

            return _headerNode.Data;
        }
        public void Clear()
        {
            Length = 0;
            _headerNode = null;
        }
        public virtual void Print()
        {
            if (_headerNode == null)
            {
                Console.WriteLine("List is empty");
            }
            Node<T> node = _headerNode;

            while (node != null)
            {
                Console.Write($"{node.Data}");
                if (node.NextNode != null) Console.Write(" -> ");
                node = node.NextNode;
            }
            Console.WriteLine();
        }

        public bool HasItems
        {
            get { return _headerNode != null; }
        }

        public int GetMaxIndex()
        {
            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
            {
                throw new Exception("Object <T> does not implement IComparable");
            }

            int maxIndex = -1;
            T currentMaxValue = default(T);
            int currentIndex = 0;
            Node<T> node = _headerNode;
            while (node != null)
            {
                IComparable data = node.Data as IComparable;
                if (data != null && data.CompareTo(currentMaxValue) > 0)
                {
                    currentMaxValue = node.Data;
                    maxIndex = currentIndex;
                }
                currentIndex++;
                node = node.NextNode;
            }
            return maxIndex;            
        }
        public T GetMax()
        {
            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
            {
                throw new Exception("Object <T> does not implement IComparable");
            }

            T currentMaxValue = default(T);
            Node<T> node = _headerNode;
            while (node != null)
            {
                IComparable data = node.Data as IComparable;
                if (data != null && data.CompareTo(currentMaxValue) > 0)
                {
                    currentMaxValue = node.Data;
                }
                node = node.NextNode;
            }
            return currentMaxValue;
        }


        protected class Node<T>
        {
            public Node<T> NextNode { get; set; }
            public T Data { get; set; }

            public Node(T data)
            {
                Data = data;
            }
        }
    }
}
