using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_11
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 9, 8, 4, 3, 8, 1, 1, 2, 8, 2, 1, 6, 0, 9, 8, 7, 0, 7, 3, 2 };
            int[] grenzen = new int[] { 0, 3, 6, 9, 12 };

            int[] histogram = MaakHistogram(array, grenzen);
            Console.WriteLine("{ " + String.Join(", ", histogram) + " }");
        }

        private static int[] MaakHistogram(int[] array, int[] grenzen)
        {
            var maxValue = int.MinValue;
            var minValue = int.MaxValue;

            //bepaal min en maximum value
            for (int i = 0; i < array.Length; i++)
            {
                if (maxValue < array[i]) maxValue = array[i];
                if (minValue > array[i]) minValue = array[i];
            }

            //tijdelijke array om te turfen
            int[] tmpArray = new int[(maxValue - minValue) + 1];
            int[] result = new int[grenzen.Length - 1];

            //turn elk getal
            for (int i = 0; i < array.Length; i++)
            {
                tmpArray[array[i] - minValue]++;
            }

            int currentCategory = 0;
            int currentMaximum = grenzen[currentCategory + 1];

            //voeg het tufde aantal toe aan juiste category
            for (int i = 0; i < tmpArray.Length; i++)
            {
                if (i + minValue > currentMaximum - 1 && currentCategory < result.Length)
                {
                    currentCategory++;
                    currentMaximum = grenzen[currentCategory + 1];
                }

                result[currentCategory]+=tmpArray[i];
            }
            return result;
        }
    }
}
