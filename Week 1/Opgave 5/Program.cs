using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Average(5, 1000000);
            Console.Clear();

            Average(5, 1000000);
            Average(5, 2000000);
            Average(5, 4000000);
            Average(5, 8000000);
        }

        static long Average(int performTest, int arraySize)
        {
            long resultArray100 = 0;
            for (int i = 0; i < performTest; i++)
            {
                double[] array = Opgave_3.Program.MaakRandomDoubleArray(arraySize, 0, arraySize);
                resultArray100 += PerformanceTest(array);
            }
            long average = resultArray100 / performTest;
            Console.WriteLine($"Average on arraysize {arraySize:N0}: {average:N2} ticks");
            return average;
        }

        static long PerformanceTest(double[] array)
        {
            Stopwatch sw = Stopwatch.StartNew();
            double max = Opgave_4.Program.GetMax(array);
            sw.Stop();
            Console.WriteLine($"Test took: {sw.ElapsedTicks:N0} ticks (max: {max:N0})");
            return sw.ElapsedTicks;
        }
    }
}
