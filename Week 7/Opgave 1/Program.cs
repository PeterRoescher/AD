using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_1
{
    class Program
    {
        static Random Random = new Random();

        static void Main(string[] args)
        {
            int[] primes = { 5, 7, 11, 13, 17, 19, 23 };

            for (int i = 0; i < primes.Length; i++)
            {
                PerformTest(primes[i]);
            }
        }

        private static void PerformTest(int tabelSize)
        {
            int[] counterTable = new int[tabelSize];
            for (int i = 0; i < tabelSize * 100; i++)
            {
                int hashValue = HashValue(Random.Next(0, tabelSize * 4), tabelSize);
                counterTable[hashValue]++;
            }

            Console.WriteLine("Results for tabelsize: " + tabelSize);
            for (int i = 0; i < counterTable.Length; i++)
            {
                Console.WriteLine($"{i}: {counterTable[i]}");
            }
        }

        private static int HashValue(int x, int tabelsize)
        {
            return x % tabelsize;
        }
    }
}
