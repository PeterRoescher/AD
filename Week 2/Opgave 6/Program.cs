using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDataStructures;

namespace Opgave_6
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(5);
            list.AddFirst(1);
            list.AddFirst(1);
            list.Print();
            int maxIndex = list.GetMaxIndex();
            Console.WriteLine($"max index: {maxIndex}, max value: {list.GetMax()}");

            ArrayList<int> arrayList = new ArrayList<int>();
            arrayList.Add(1);
            arrayList.Add(5);
            arrayList.Add(1);
            arrayList.Add(1);
            arrayList.Print();
            maxIndex = arrayList.GetMaxIndex();
            Console.WriteLine($"max index: {maxIndex}, max value: {arrayList.GetMax()}");

        }
    }
}
