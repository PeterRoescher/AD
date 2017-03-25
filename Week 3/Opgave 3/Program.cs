using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"f(5) = {RecursiveSomOmEnOm(5)}");
            Console.WriteLine($"f(6) = {RecursiveSomOmEnOm(6)}");
            Console.WriteLine($"f(7) = {RecursiveSomOmEnOm(7)}");
        }

        private static int RecursiveSomOmEnOm(int i)
        {
            if (i < 0) return 0;

            return i + RecursiveSomOmEnOm(i - 2);
        }
    }
}
