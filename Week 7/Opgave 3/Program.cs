using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDataStructures;

namespace Opgave_3
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTableSepChain<int> hastTable = new IntHashTableSepChain(10);
            hastTable.Add(0);
            hastTable.Add(1);
            hastTable.Add(81);
            hastTable.Add(15);
            hastTable.Add(64);
            hastTable.Add(4);
            hastTable.Add(25);
            hastTable.Add(36);
            hastTable.Add(16);
            hastTable.Add(49);
            hastTable.Add(9);
            hastTable.Remove(15);
            hastTable.Remove(15);
            Console.WriteLine(hastTable);
        }
    }
}
