using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDataStructures.Interfaces;

namespace BaseDataStructures
{
    public class Stack<T> : IStack<T>
    {
        private LinkedList<T> _internalList = new LinkedList<T>();
        public void Push(T data)
        {
            _internalList.AddFirst(data);
        }

        public T Pop()
        {
            T data = Top();
            _internalList.RemoveFirst();
            return data;
        }

        public T Top()
        {
            return _internalList.GetFirst();
        }

        public bool HasItems { get { return _internalList.HasItems; } }
    }
}
