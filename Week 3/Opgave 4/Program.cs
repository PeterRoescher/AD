using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_4
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 16; i++)
            {
                Console.WriteLine($"f({i}) = {NumberOf1InBinaryRepresentationOf(i)}");
            }
        }

        static int NumberOf1InBinaryRepresentationOf(int n)
        {
            if (n < 2) return n % 2;
            return n % 2 + NumberOf1InBinaryRepresentationOf(n / 2);
        }
    }
}
