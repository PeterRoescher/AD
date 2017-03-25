using System;

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
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(0);
            stack.Push(5);

            Console.WriteLine(stack.Top());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Top());
        }
    }
}
