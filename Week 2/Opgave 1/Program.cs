using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDataStructures;

namespace Opgave_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new ArrayList<int>();
            array.Add(1);
            array.Add(3);
            array.Add(3);
            array.Add(3);
            Console.WriteLine(array.CountOccurences(3));
            array.Set(0, 0);
            array.Print();
            
//            array.Add(4);
        }
    }
}
