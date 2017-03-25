using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_14
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine(BinairZoeken(-5, array));
        }

        static int LineairZoeken(int getal, int[] array) //O(N)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == getal) return i;
            }
            return -1;
        }

        static int BinairZoeken(int getal, int[] gesorteerdeArray)
        {
            int min = 0;
            int max = gesorteerdeArray.Length - 1;
            int index = max / 2;

            while (true)
            {
                if (gesorteerdeArray[index] == getal) return index;

                bool higher = gesorteerdeArray[index] < getal;

                if (higher) min = index;
                else max = index;

                int step = (max - min) / 2;

                if (!higher) step = -step;
                if (step == 0) //check final step
                {
                    if (higher && gesorteerdeArray[index + 1] == getal) return index + 1;
                    if (!higher && gesorteerdeArray[index - 1] == getal) return index - 1;
                    return -1;
                }

                index += step;
            }
            return -1;
        } //O(logN)

        static int BinarySearch(int number, int[] sortedArray)//O(logN)
        {
            var currentIndex = (sortedArray.Length - 1) / 2;
            var currentVal = sortedArray[currentIndex];
            while (currentVal != number)
            {
                if (currentVal < number)
                {
                    currentIndex += currentIndex / 2;
                }
                else
                {
                    currentIndex -= currentIndex / 2;
                }
                currentVal = sortedArray[currentIndex];
            }
            return currentIndex;
        }
    }
}
