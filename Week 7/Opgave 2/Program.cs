using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_2
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
                string s = String.Empty;
                int stringLegnth = Random.Next(0, 10);
                while (s.Length < stringLegnth)
                {
                    s += Random.Next(0, 100) % 2;
                }

                int hashValue = HashValue(s, tabelSize);
                counterTable[hashValue]++;
            }

            Console.WriteLine("Results for tabelsize: " + tabelSize);
            for (int i = 0; i < counterTable.Length; i++)
            {
                Console.WriteLine($"{i}: {counterTable[i]}");
            }
        }

        private static int HashValue(string str, int tabelsize)
        {
            uint hashValue = 0;
            for (int i = 0; i < str.Length; i++)
            {
                hashValue = hashValue * 31 + (uint)str[i];
            }
            return (int)(hashValue % tabelsize);
        }
    }
}
