using BaseDataStructures;

namespace Opgave_2
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(1);
            list.Insert(1, 12);
            list.Insert(1, 6);
            list.RemoveFirst();
            list.Print();
            list.Clear();
            list.Print();
        }
    }
}
