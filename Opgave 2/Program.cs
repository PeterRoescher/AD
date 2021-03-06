﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_2
{
    class Program
    {
        static void Main(string[] args)
        {
        }


        public class EvenOddSLL<T> : LinkedList<T>
        {
            private int Length { get; set; }
            protected EvenOddSLLNode<T> _evenNode;
            protected EvenOddSLLNode<T> _oddNode;

            public EvenOddSLL()
            {
                Length = 0;
            }

            public void Add(int index, T data)
            {
                if (index > Length) throw new ArgumentOutOfRangeException(nameof(index));
                if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));

                EvenOddSLLNode<T> newNode = new EvenOddSLLNode<T>(data);

                if (index == 0)
                {
                    newNode.Next = _evenNode;
                    newNode.NextOddOrEven = _oddNode;

                    _oddNode = _evenNode;
                    _evenNode = newNode;
                    Length++;
                    return;
                }

                EvenOddSLLNode<T> node = index % 2 == 0 ? _evenNode : _oddNode;
                for (int i = 0; i + 2 < index; i += 2)
                {
                    node = node?.NextOddOrEven;
                }

                newNode.Next = node?.NextOddOrEven;
                newNode.NextOddOrEven = node?.Next?.NextOddOrEven;

                if (node != null)
                {
                    if (node.Next != null)
                    {
                        node.Next.Next = newNode;
                        node.Next.NextOddOrEven = newNode?.Next;
                    }

                    node.NextOddOrEven = newNode;
                }

                Length++;
            }

            public T Get(int index)
            {
                if (index > Length) throw new ArgumentOutOfRangeException(nameof(index));
                if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));

                EvenOddSLLNode<T> node = index % 2 == 0 ? _evenNode : _oddNode;
                for (int i = 0; i + 1 < index; i += 2)
                {
                    node = node.NextOddOrEven;
                }
                return node.Data;
            }

            public void Remove(int index)
            {
                if (index > Length) throw new ArgumentOutOfRangeException(nameof(index));
                if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));

                if (index < 2) //special case since there is no node 2 nodes before this
                {
                    if (index == 0) //remove evenNode
                    {
                        _evenNode = _evenNode?.Next;
                    }
                    else //remove oddNode
                    {
                        _evenNode.Next = _oddNode.Next;
                        _evenNode.NextOddOrEven = _oddNode.NextOddOrEven;
                    }
                    _oddNode = _oddNode.Next;
                    Length--;
                    return;
                }

                //Get 2 nodes before the one to remove
                EvenOddSLLNode<T> node = index % 2 == 0 ? _evenNode : _oddNode;
                for (int i = 0; i + 3 < index; i += 2)
                {
                    node = node?.NextOddOrEven;
                }

                EvenOddSLLNode<T> nodeToRemove = node?.NextOddOrEven;
                node.Next.Next = nodeToRemove?.Next;
                node.Next.NextOddOrEven = nodeToRemove?.NextOddOrEven;
                node.NextOddOrEven = nodeToRemove.Next;
                Length--;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                if (_evenNode == null)
                {
                    sb.AppendLine("List is empty");
                    return sb.ToString();
                }
                EvenOddSLLNode<T> node = _evenNode;

                while (node != null)
                {
                    sb.Append($"{node.Data}");
                    if (node.Next != null) sb.Append(" -> ");
                    node = node.Next;
                }
                sb.AppendLine();
                return sb.ToString();
            }

            public string ToStringEven()
            {
                StringBuilder sb = new StringBuilder();
                if (_evenNode == null)
                {
                    sb.AppendLine("List is empty");
                    return sb.ToString();
                }
                EvenOddSLLNode<T> node = _evenNode;

                while (node != null)
                {
                    sb.Append($"{node.Data}");
                    if (node.Next != null) sb.Append(" -> ");
                    node = node.NextOddOrEven;
                }
                sb.AppendLine();
                return sb.ToString();
            }

            public string ToStringOdd()
            {
                StringBuilder sb = new StringBuilder();
                if (_oddNode == null)
                {
                    sb.AppendLine("List is empty");
                    return sb.ToString();
                }
                EvenOddSLLNode<T> node = _oddNode;

                while (node != null)
                {
                    sb.Append($"{node.Data}");
                    if (node.Next != null) sb.Append(" -> ");
                    node = node.NextOddOrEven;
                }
                sb.AppendLine();
                return sb.ToString();
            }

            protected class EvenOddSLLNode<T>
            {
                public EvenOddSLLNode<T> Next { get; set; }
                public EvenOddSLLNode<T> NextOddOrEven { get; set; }

                public T Data { get; }
                public EvenOddSLLNode(T data)
                {
                    Data = data;
                }

                public override string ToString()
                {
                    return $"Node ({Data})";
                }
            }
        }
    }
}
