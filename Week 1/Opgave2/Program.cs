using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave2
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzz(100);
        }

        static void FizzBuzz(int maxNumber)
        {
            for (int i = 1; i <= maxNumber; i++)
            {
                bool fizzBuzz = false;
                if (i % 3 == 0) { Console.Write("Fizz"); fizzBuzz = true; }
                if (i % 5 == 0) { Console.Write("Buzz"); fizzBuzz = true; }

                if (!fizzBuzz) { Console.Write(i); }

                Console.Write(", ");
            }
        }
    }
}
