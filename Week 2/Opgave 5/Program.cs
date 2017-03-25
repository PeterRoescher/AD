using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDataStructures;
using BaseDataStructures.Interfaces;

namespace Opgave_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Waardeloze opdracht
            //Implement the array - based queue class with an ArrayList.What are the advantages and disadvantages of
            //this approach?

            BaseDataStructures.Queue<int> queue = new BaseDataStructures.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            Console.WriteLine(queue);
            Console.WriteLine($"Peek: {queue.Peek()}");
            Console.WriteLine(queue);
            queue.Dequeue();
            Console.WriteLine(queue);
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            //queue.Dequeue();
            Console.WriteLine(queue);
        }
    }

    public class Queue<T> : IQueue<T>
    {
        private ArrayList<T> _internalList = new ArrayList<T>();
        public void Enqueue(T data)
        {
            _internalList.Add(data);
        }

        public T Dequeue()
        {
            var value = _internalList.Get(_internalList.CurrentIndex);
            _internalList.Set(_internalList.CurrentIndex, default(T));

            return value;
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }
    }
}
