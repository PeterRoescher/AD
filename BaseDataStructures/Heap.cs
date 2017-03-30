using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BaseDataStructures.Interfaces;

namespace BaseDataStructures
{
    /*
     * Heap = boom in array form. Startende bij 1 
     * Childpos = ParentPos * 2 & ParentPos * 2 + 1 
     * MinHeap > kleinste bovenaan
     * MaxHeap > grootste bovenaan
     */
    public class Heap<T> : IHeap<T> where T : IComparable
    {
        private T[] _internalArray;
        public int Size { get; private set; }

        public bool IsComplete
        {
            get
            {
                for (int i = 1; i < Size; i++)
                {
                    if (_internalArray[i].Equals(default(T))) return false;
                }
                return true;
            }
        }

        public bool IsPerfect
        {
            get
            {
                double value = Math.Log(Size + 1, 2) - 1.0;
                return !(value > (int) value);
            }
        }

        public int Height
        {
            get
            {
                if (Size == 0) return 0;

                double value= Math.Log(Size + 1, 2) - 1.0;

                //inperfect
                //if (value > (int) value) value++;
                value = Math.Ceiling(value);

                return (int)value;

            }
        }

        public Heap(int initialSize)
        {
            _internalArray = new T[initialSize];
            Size = 0;
        }
        public bool Add(T data)
        {
            if (Size < _internalArray.Length)
            {
                Doubling();
            }

            _internalArray[++Size] = data;
            PercolateUp(Size);
            return true;
        }

        public T Remove()
        {
            T value = _internalArray[1];
            //set last element in top
            _internalArray[1] = _internalArray[Size--];
            PercolateDown(1);
            return value;
        }

        private void Doubling()
        {
            T[] newArray = new T[_internalArray.Length * 2];
            for (int i = 1; i <= Size; i++)
            {
                newArray[i] = _internalArray[i];
            }
            _internalArray = newArray;
        }

        private void PercolateUp(int hole)
        {
            int parentHole = hole / 2;
            while (parentHole >= 2 && _internalArray[parentHole].CompareTo(_internalArray[hole]) > 0)
            {
                //use 0 position to store tmp data;
                _internalArray[0] = _internalArray[parentHole];
                _internalArray[parentHole] = _internalArray[hole];
                _internalArray[hole] = _internalArray[0];

                hole = parentHole;
                parentHole = hole / 2;
            }
        }

        private void PercolateDown(int hole)
        {
            int childHole = hole * 2;

            //use 0 position to store tmp data;
            _internalArray[0] = _internalArray[hole];
            while (childHole <= Size)
            {
                //if there is a right child and its data larger then the left child, get the right child
                if (childHole < Size && _internalArray[childHole].CompareTo(_internalArray[childHole + 1]) > 0)
                {
                    childHole++;
                }

                if (_internalArray[childHole].CompareTo(_internalArray[0]) < 0)
                {
                    _internalArray[hole] = _internalArray[childHole];
                }
                else
                {
                    break;
                }
                hole = childHole;
                childHole = hole * 2;
            }
            _internalArray[hole] = _internalArray[0];
        }

        private void BuildHeap()
        {
            for (int i = Size / 2; i > 0; i--)
            {
                PercolateDown(i);
            }
        }

        public override string ToString()
        {
            string result = String.Empty;
            for (int i = 1; i <= Size; i++)
            {
                result += _internalArray[i];
                if (i + 1 <= Size)
                {
                    result += ", ";
                }
            }
            return result;
        }
    }
}
