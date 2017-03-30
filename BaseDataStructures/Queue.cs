using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDataStructures.Interfaces;

namespace BaseDataStructures
{
    public class Queue<T> : IQueue<T>
    {
        private int _firstPosition = 0;
        private int _lastPosition = -1;

        private T[] _internalArray;

        public Queue(int initialSize = 4)
        {
            _internalArray = new T[initialSize];
        }
        public T Dequeue()
        {
            if (_lastPosition < _firstPosition) throw new Exception("Cannot dequeue while the queue is empty");
            return _internalArray[_firstPosition++];
        }

        public void Enqueue(T data)
        {
            if (_lastPosition + 1 >= _internalArray.Length) Doubling();//throw new Exception("Cannot enqueue while the queue is at its end");
            _internalArray[++_lastPosition] = data;
        }

        private void Doubling()
        {
            T[] newArray = new T[_internalArray.Length * 2];
            for (int i = 0; i < _internalArray.Length; i++)
            {
                newArray[i] = _internalArray[i];
            }
            _internalArray = newArray;
        }

        public T Peek()
        {
            if (_internalArray.Length <= _firstPosition) return default(T);
            return _internalArray[_firstPosition];
        }

        public override string ToString()
        {
            string result = String.Empty;
            for (int i = _firstPosition; i < _lastPosition+1; i++)
                result += $"{_internalArray[i]} -> ";
            return result;
        }
    }

}
