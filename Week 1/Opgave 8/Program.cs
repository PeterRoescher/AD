using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 1, 5, 10, 11, 14, 15, 16 };
            int[] array2 = { 0, 2, 3, 5, 6, 7 };
            int[] resultaat = VoegSamen(array1, array2);
            Console.WriteLine(String.Join(", ", resultaat));

        }

        private static int[] VoegSamen(int[] array1, int[] array2)
        {
            int[] result = new int[array1.Length + array2.Length];

            int resultIndex = 0;
            int array1Index = 0;
            int array2Index = 0;
            while (resultIndex < result.Length)
            {
                int value;
                if (array2.Length <= array2Index || 
                    (array1.Length > array1Index && array1[array1Index] < array2[array2Index]))
                {
                    value = array1[array1Index++];
                }
                else
                {
                    value = array2[array2Index++];
                }

                result[resultIndex++] = value;
            }
            return result;
        }
    }
}
