using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDataStructures
{
    public class IntHashTableSepChain : HashTableSepChain<int>
    {
        public IntHashTableSepChain(int tableSize) : base(tableSize)
        {
        }

        public override int HashValue(int data)
        {
            return data % _internalList.Length;
        }       
    }

    public abstract class HashTableSepChain<T>
    {
        protected LinkedList<T>[] _internalList;

        protected HashTableSepChain(int tableSize)
        {
            _internalList = new LinkedList<T>[tableSize];
        }

        public void Add(T data)
        {
            int hashValue = HashValue(data);

            if (_internalList[hashValue] == null)
                _internalList[hashValue] = new LinkedList<T>();

            _internalList[hashValue].AddFirst(data);
        }

        public void Remove(T data)
        {
            int hashValue = HashValue(data);
            LinkedList<T> subList = _internalList[hashValue];
            if (_internalList[hashValue] != null && _internalList[hashValue].HasItems)
            {
                subList.Remove(data);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }
        }

        public abstract int HashValue(T data);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _internalList.Length; i++)
            {
                if (_internalList[i] != null)
                {
                    sb.Append($"{i}: \t{_internalList[i]}");
                }
                else
                {
                    sb.AppendLine($"{i}: \tnull");
                }
            }

            return sb.ToString();
        }
    }
}
