using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_9
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
            int[] result = new int[grenzen.Length - 1];
            for (int i = 0; i < array.Length; i++)
            {
                int currentValue = array[i];
                int categoryIndex = 0;
                while (categoryIndex - 1 < grenzen.Length && currentValue >= grenzen[categoryIndex + 1])
                {
                    categoryIndex++;
                }
                result[categoryIndex]++;
            }
            return result;
        }
    }
}
