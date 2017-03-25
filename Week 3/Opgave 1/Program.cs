using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Recursief");
            FaculteitsFunctieRecursief(100);

            Console.WriteLine("Niet Recursief");
            FaculteitsFunctieNietRecursief(100);
        }

        static long FaculteitsFunctieRecursief(int n)
        {
            if (n == 1) return 1;

            var val = FaculteitsFunctieRecursief(n - 1);
            Console.WriteLine(n * val);
            return n * val;
        }

        static void FaculteitsFunctieNietRecursief(int n)
        {
            long val = 1;
            for (var i = 1; i < n; i++)
            {
                val = i * val;
                Console.WriteLine(val);
            }
        }
    }
}
