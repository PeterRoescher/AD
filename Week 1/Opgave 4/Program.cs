using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Opgave_3;

namespace Opgave_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            double[] doubleArray = Opgave_3.Program.MaakRandomDoubleArray(20, 0, 10);
            doubleArray.Print();

            Console.WriteLine($"Max index: {GetMaxIndex(doubleArray)}");
            Console.WriteLine($"Max value: {GetMax(doubleArray)}");
        }

        public static int GetMaxIndex(double[] array)
        {
            double maxValue = -1;
            int maxIndex = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (maxValue < array[i])
                {
                    maxValue = array[i];
                    maxIndex = i;
                }
            }
            return maxIndex;            
        }

        public static double GetMax(double[] array)
        {
            return array[GetMaxIndex(array)];
        }
    }
}
