using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Opgave_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = {4, 5, 3, 2, 1, 1, 4, 8, 10, 12, 15, 18, 20};
            double[] output = MovingAverage(input, 4);

            Console.WriteLine(String.Join(", ", output));
        }

        private static double[] MovingAverage(int[] input, int n)
        {
            double[] result = new double[input.Length];
            double subTotal = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (n == 1)
                {
                    result[i] = input[i];
                    continue;                    
                }

                subTotal += input[i];
                if (i < n)
                {
                    result[i] = subTotal / (i + 1);
                }
                else
                {
                    subTotal -= input[i - n];
                    result[i] = subTotal / n;
                }
            }
            return result;
        }
    }
}
