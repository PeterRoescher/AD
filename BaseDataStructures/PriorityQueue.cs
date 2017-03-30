using System;
using System.Net.NetworkInformation;

namespace BaseDataStructures
{
    public class PriorityQueue<T> : Heap<T> where T : IComparable<T>, IComparable
    {
        public PriorityQueue(int initialSize) : base(initialSize)
        {
        }
    }
}