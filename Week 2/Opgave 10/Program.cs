using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BaseDataStructures;

namespace Opgave_10
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new SimpleLinkedListPriorityQueue();
            queue.Insert(2);
            queue.Insert(6);
            queue.Insert(5);
            queue.Insert(2);
            queue.Insert(8);
            queue.Insert(3);
            queue.Insert(4);
            queue.Insert(7);
            queue.Insert(10);
            queue.Insert(9);
            queue.Insert(1);
            queue.Print();
            Console.WriteLine($"{queue.FindMin()}");
            queue.DeleteMin();
            queue.Print();
            Console.WriteLine($"{queue.FindMin()}");
            queue.DeleteMin();
            queue.Print();
            Console.WriteLine($"{queue.FindMin()}");
            queue.DeleteMin();
            queue.Print();
            Console.WriteLine($"{queue.FindMin()}");
        }
    }

    public class SimplePriorityQueue
    {
        public int Length { get; set; }
        private int[] _internalArray;

        public SimplePriorityQueue(int initialSize)
        {
            Length = 0;
            _internalArray = new int[initialSize];
        }

        public void Insert(int element)
        {
            _internalArray[Length++] = element;
        }

        public int FindMin()
        {
            int minValue = Int32.MaxValue;

            for (int i = 0; i < Length; i++)
            {
                if (_internalArray[i] < minValue) minValue = _internalArray[i];
            }
            return minValue;
        }

        public void DeleteMin()
        {
            int minValue = Int32.MaxValue;
            int minIndex = -1;
            for (int i = 0; i < Length; i++)
            {
                if (_internalArray[i] < minValue)
                {
                    minValue = _internalArray[i];
                    minIndex = i;
                }
            }

            for (int i = minIndex; i < Length; i++)
            {
                _internalArray[i] = i + 1 == Length ? default(int) : _internalArray[i + 1];
            }
            Length--;
        }

    }

    public class SimpleLinkedListPriorityQueue : LinkedList<int>
    {
        public void Insert(int element)
        {
            AddFirst(element);
        }

        public int FindMin()
        {
            Node<int> node = _headerNode;
            int minValue = Int32.MaxValue;

            while (node != null)
            {
                if (node.Data < minValue) minValue = node.Data;
                node = node.NextNode;
            }
            return minValue;            
        }

        public void DeleteMin()
        {
            if (_headerNode == null) throw new Exception("List is empty");

            Node<int> prevMinNode = null;
            Node<int> node = _headerNode;
            int minValue = _headerNode.Data;


            while (node?.NextNode != null)
            {
                if (node.NextNode.Data < minValue)
                {
                    minValue = node.NextNode.Data;
                    prevMinNode = node;
                }
                node = node.NextNode;
            }

            if (prevMinNode != null)
            {
                prevMinNode.NextNode = prevMinNode.NextNode.NextNode;
            }
            else
            {
                _headerNode = _headerNode.NextNode;
            }
        }
    }
}
