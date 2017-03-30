using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDataStructures
{
    public abstract class HashTableQuadProbing<T>
    {
        private T[] _internalArray;

        protected int TableSize { get { return _internalArray.Length; } }

        public int Size { get; private set; }
        public double LoadFactor { get { return (double)Size / TableSize; } }


        public HashTableQuadProbing(int initialSize)
        {
            _internalArray = new T[initialSize];
            Size = 0;
        }

        public abstract int HashValue(T data, int tableSize);

        public void Add(T data)
        {
            int initialHash = HashValue(data, TableSize);
            int hash = initialHash;
            int i = 1;

            while (!_internalArray[hash].Equals(default(T)))
            {
                hash = initialHash + (int)Math.Pow(i, 2);
                hash = hash % TableSize;
                i++;
            }
            _internalArray[hash] = data;
            Size++;
            CheckLoadFactor();
        }

        public void Remove(T data)
        {
            int initialHash = HashValue(data, TableSize);
            int hash = initialHash;
            int i = 1;
            while (!_internalArray[hash].Equals(data) && !_internalArray[hash].Equals(default(T)))
            {
                hash = initialHash + (int)Math.Pow(i, 2);
                hash = hash % TableSize;
                i++;
            }

            if (_internalArray[hash].Equals(default(T)))
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }
            _internalArray[hash] = default(T);
            Size--;
        }

        private void CheckLoadFactor()
        {
            if (LoadFactor > 0.5)
            {
                Rehash();
            }
        }

        private void Rehash()
        {
            T[] newArray = new T[GetNextPrime(_internalArray.Length * 2)];
            for (int i = 0; i < TableSize; i++)
            {
                int newHash = HashValue(_internalArray[i], newArray.Length);

                int iHash = 1;
                while (!newArray[newHash].Equals(default(T)))
                {
                    newHash += (int)Math.Pow(iHash, 2);
                    newHash = newHash % TableSize;
                    iHash++;
                }
                newArray[newHash] = _internalArray[i];
            }
            _internalArray = newArray;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Tablesize: {TableSize}");
            sb.AppendLine($"Size: {Size}");
            sb.AppendLine($"Load factor: {LoadFactor}");

            for (int i = 0; i < _internalArray.Length; i++)
            {
                sb.Append($"{i}: \t");
                if (_internalArray[i].Equals(default(T)))
                {
                    sb.AppendLine();
                }
                else
                {
                    sb.AppendLine($"{_internalArray[i]}");
                }
            }

            return sb.ToString();
        }

        public static uint GetNextPrime(int number)
        {
            if (number % 2 == 0) number++;
            uint max = (uint)Math.Ceiling(Math.Sqrt(number));

            for (uint possiblePrime = (uint)number + 2; possiblePrime < UInt32.MaxValue; possiblePrime += 2)
            {
                if (IsPrime(possiblePrime)) return possiblePrime;
            }
            throw new Exception("No prime found");
        }

        private static bool IsPrime(uint possiblePrime)
        {
            if (possiblePrime < 2) return false;
            if (possiblePrime == 2 || possiblePrime == 3) return true;
            if (possiblePrime % 2 == 0) return false;

            for (int iL = 3; iL * iL < possiblePrime; iL += 2)
            {
                if (possiblePrime % iL == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
