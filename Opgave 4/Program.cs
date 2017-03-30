using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BaseDataStructures;

namespace Opgave_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //uint i = 0;
            //Stopwatch sw = Stopwatch.StartNew();
            //while (i < UInt32.MaxValue)
            //{
            //    sw.Start();
            //    i = HashTableQuadProbing<int>.GetNextPrime((int) i);
            //    sw.Stop();
            //    Console.WriteLine($"{i} ({sw.ElapsedMilliseconds}ms), ");               
            //    sw.Reset();
            //}
            


            IntHashTableQuadProbing hashTable = new IntHashTableQuadProbing(10);

            hashTable.Add(89);
            Console.WriteLine(hashTable);
            hashTable.Add(18);
            hashTable.Add(49);
            hashTable.Add(58);
            hashTable.Add(9);
            hashTable.Remove(9);
            Console.WriteLine(hashTable);
            hashTable.Remove(58);
            Console.WriteLine(hashTable);
        }

        public class IntHashTableQuadProbing : HashTableQuadProbing<int>
        {
            public IntHashTableQuadProbing(int initialSize) : base(initialSize)
            {
            }

            public override int HashValue(int data, int tableSize)
            {
                return data % tableSize;
            }
        }
    }
}
