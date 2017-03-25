using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_1
{

    //with mapsize: 1073741823
    //Time taken 1: 6360785 ticks - 2331 ms            2s
    //Time taken 10: 24750500 ticks - 9072 ms          9s
    //Time taken 100: 125327007 ticks - 45939 ms      45s
    //Time taken 1000: 277216979 ticks - 101616 ms   101s
    //Time taken 10000: 484036528 ticks - 177428 ms  177s
    class Program
    {
        private static bool[] _map = new bool[int.MaxValue / 2];
        static void Main(string[] args)
        {
            FindNPrimeNumbers(1);
            PerformanceTest(1);
            PerformanceTest(10);
            PerformanceTest(100);
            PerformanceTest(1000);
            PerformanceTest(10000);
        }

        static void PerformanceTest(int n)
        {
            Stopwatch sw = Stopwatch.StartNew();
            FindNPrimeNumbers(n);
            sw.Stop();
            Console.WriteLine($"Time taken {n}: {sw.ElapsedTicks} ticks - {sw.ElapsedMilliseconds} ms");
            _map = new bool[_map.Length];
        }

        static void FindNPrimeNumbers(int n)
        {
            int primeNumbersFound = 0;
            int i = 2;
            while (primeNumbersFound < n && i < _map.Length)
            {
                if (!_map[i])
                {
                    primeNumbersFound++;
                }

                for (int x = i; x < _map.Length - i; x += i)
                {
                    _map[x] = true;
                }
                i++;
            }

            if (primeNumbersFound < n)
            {
                Console.WriteLine("Buffer to low!");
            }
        }
    }
}
