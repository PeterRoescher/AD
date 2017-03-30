using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDataStructures.Interfaces;

namespace BaseDataStructures
{
    public class ArrayList<T> : ISimpleArrayList<T>
    {
        private T[] _data;
        private int _currentIndex = -1;
        public int CurrentIndex { get { return _currentIndex; } }

        public ArrayList(int initialSize = 4)
        {
            _data = new T[initialSize];
        }

        public void Add(T data) //O(1)
        {
            if (_currentIndex + 1 >= _data.Length) Doubling();//throw new IndexOutOfRangeException("Array is full");
            _data[++_currentIndex] = data;
        }

        private void Doubling()
        {
            T[] newArray = new T[_data.Length * 2];
            for (int i = 0; i < _data.Length; i++)
            {
                newArray[i] = _data[i];
            }
            _data = newArray;
        }

        public T Get(int index) //O(1)
        {
            if (index < 0 || index > _data.Length) throw new ArgumentOutOfRangeException(nameof(index));

            return _data[index];
        }

        public void Set(int index, T data) //O(1)
        {
            if (index < 0 || index > _data.Length) throw new ArgumentOutOfRangeException(nameof(index));

            _data[index] = data;
        }

        public void Print() //O(N)
        {
            Console.WriteLine(String.Join(", ", _data));
        }

        public void Clear() //O(1)
        {
            _data = new T[_data.Length];
        }

        public int CountOccurences(T data) //O(N)
        {
            int counter = 0;
            for (int i = 0; i < _data.Length; i++)
            {
                if (_data[i].Equals(data)) counter++;
            }
            return counter;
        }

        public int GetMaxIndex()
        {
            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
            {
                throw new Exception("Object <T> does not implement IComparable");
            }

            IComparable maxValue = null;
            int maxIndex = -1;
            for (int i = 0; i < _data.Length; i++)
            {
                IComparable data = _data[i] as IComparable;
                
                if (data != null && (maxValue == null || maxValue.CompareTo(data) < 0))
                {
                    maxValue = data;
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        public T GetMax()
        {
            return _data[GetMaxIndex()];
        }
    }
}
