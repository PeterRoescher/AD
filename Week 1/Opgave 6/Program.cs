using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opgave_3;

namespace Opgave_6
{
    class Program
    {
        private const int multiplier = 100000;
        private const int attempsPerArray = 100;
        static Random Random = new Random();
        static void Main(string[] args)
        {
            AverageV1(5, 1 * multiplier, attempsPerArray);
            AverageV1(5, 2 * multiplier, attempsPerArray);
            AverageV1(5, 4 * multiplier, attempsPerArray);
            AverageV1(5, 8 * multiplier, attempsPerArray);
            AverageV1(5, 16 * multiplier, attempsPerArray);

            AverageV2(5, 1 * multiplier, attempsPerArray);
            AverageV2(5, 2 * multiplier, attempsPerArray);
            AverageV2(5, 4 * multiplier, attempsPerArray);
            AverageV2(5, 8 * multiplier, attempsPerArray);
            AverageV2(5, 16 * multiplier, attempsPerArray);
        }


        private static long AverageV1(int n, int arraySize, int attempsPerArray)
        {
            long result = 0;

            for (int i = 0; i < n; i++)
            {
                int[] intArray = Opgave_3.Program.MaakRandomIntArray(arraySize, 0, arraySize);
                long arrayAverage = 0;
                for (int i2 = 0; i2 < attempsPerArray; i2++)
                {
                    int index = Random.Next(0, intArray.Length);
                    arrayAverage += PerformanceTestV1(intArray, index);
                }
                result += arrayAverage / attempsPerArray;
            }

            long average = result / n;
            Console.WriteLine($"Average on arraysize {arraySize:N0}: {average:N0} ticks");
            return average;
        }

        private static long PerformanceTestV1(int[] array, int index)
        {
            Stopwatch sw = Stopwatch.StartNew();
            double max = CumulatieveSom(array, index);
            sw.Stop();
            //Console.WriteLine($"Test took: {sw.ElapsedTicks:N0} ticks (max: {max:N0})");
            return sw.ElapsedTicks;
        }

        private static long AverageV2(int n, int arraySize, int attempsPerArray)
        {
            long result = 0;

            for (int i = 0; i < n; i++)
            {                
                int[] intArray = Opgave_3.Program.MaakRandomIntArray(arraySize, 0, arraySize);
                
                Stopwatch sw = Stopwatch.StartNew();
                InitCumulatieveSom_v2(intArray);
                sw.Stop();
                long arrayAverage = sw.ElapsedTicks;

                for (int i2 = 0; i2 < attempsPerArray; i2++)
                {
                    int index = Random.Next(0, intArray.Length);
                    arrayAverage += PerformanceTestV2(intArray, index);                    
                }
                result += arrayAverage / attempsPerArray;
            }

            long average = result / n;
            Console.WriteLine($"Average V2 on arraysize {arraySize:N0}: {average:N0} ticks");
            return average;
        }

        private static long PerformanceTestV2(int[] array, int index)
        {
            Stopwatch sw = Stopwatch.StartNew();
            double max = CumulatieveSom_v2(array, index);
            sw.Stop();
            //Console.WriteLine($"Test took: {sw.ElapsedTicks:N0} ticks (max: {max:N0})");
            return sw.ElapsedTicks;
        }

        static int CumulatieveSom(int[] array, int index)
        {
            int result = 0;
            for (int i = 0; i <= index; i++)
            {
                result += array[index];
            }
            return result;
        }

        private static int[] cumulativeSumArray;
        static void InitCumulatieveSom_v2(int[] array)
        {
            cumulativeSumArray = new int[array.Length];
            for (int i = 0; i < cumulativeSumArray.Length; i++)
            {
                cumulativeSumArray[i] = i == 0 ? array[i] : array[i] + array[i - 1];
            }
        }

        static int CumulatieveSom_v2(int[] array, int index)
        {
            return cumulativeSumArray[index];
        }

    }
}
