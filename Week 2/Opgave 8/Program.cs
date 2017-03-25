using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDataStructures;

namespace Opgave_8
{
    class Program
    {
        static void Main(string[] args)
        {

            EvenOddSLL<int> linkedList = new EvenOddSLL<int>();
            linkedList.Add(0, 10);
            linkedList.Add(0, 9);
            linkedList.Add(0, 8);
            linkedList.Add(0, 7);
            linkedList.Add(0, 6);
            //            linkedList.Add(0, 5);
            linkedList.Add(0, 4);
            linkedList.Add(0, 3);
            linkedList.Add(0, 2);
            linkedList.Add(0, 1);
            linkedList.Print();
            linkedList.PrintEvenPositions();
            linkedList.PrintOddPositions();

            linkedList.Add(4, 5);
            linkedList.Print();
            linkedList.PrintEvenPositions();
            linkedList.PrintOddPositions();

            linkedList.Add(10, 11);
            linkedList.Print();
            linkedList.PrintEvenPositions();
            linkedList.PrintOddPositions();

            //linkedList.Add(-1, 5);
            //linkedList.Add(15, 5);

            Console.WriteLine(linkedList.Get(0));
            Console.WriteLine(linkedList.Get(5));
            Console.WriteLine(linkedList.Get(10));
            //Console.WriteLine(linkedList.Get(-1));
            //Console.WriteLine(linkedList.Get(11));

            linkedList.Remove(10);
            linkedList.Print();
            linkedList.PrintEvenPositions();
            linkedList.PrintOddPositions();
        }

    }

    public class EvenOddSLL<T> : LinkedList<T>
    {
        protected EvenOddSLLNode<T> _evenNode;
        protected EvenOddSLLNode<T> _oddNode;

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

        public override void Print()
        {
            if (_evenNode == null)
            {
                Console.WriteLine("List is empty");
            }
            EvenOddSLLNode<T> node = _evenNode;

            while (node != null)
            {
                Console.Write($"{node.Data}");
                if (node.Next != null) Console.Write(" -> ");
                node = node.Next;
            }
            Console.WriteLine();
        }

        public void PrintEvenPositions()
        {
            if (_evenNode == null)
            {
                Console.WriteLine("List is empty");
            }
            EvenOddSLLNode<T> node = _evenNode;

            while (node != null)
            {
                Console.Write($"{node.Data}");
                if (node.NextOddOrEven != null) Console.Write(" -> ");
                node = node.NextOddOrEven;
            }
            Console.WriteLine();
        }

        public void PrintOddPositions()
        {
            if (_oddNode == null)
            {
                Console.WriteLine("List is empty");
            }
            EvenOddSLLNode<T> node = _oddNode;

            while (node != null)
            {
                Console.Write($"{node.Data}");
                if (node.NextOddOrEven != null) Console.Write(" -> ");
                node = node.NextOddOrEven;
            }
            Console.WriteLine();
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
