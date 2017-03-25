using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_3
{
    public class Program
    {
        private static readonly Random Random = new Random();        

        static void Main(string[] args)
        {
            MaakRandomIntArray(10, 0, 10).Print();
            MaakRandomDoubleArray(10, 0, 10).Print();
        }

        public static int[] MaakRandomIntArray(int lengte, int min, int max)
        {
            int[] array = new int[lengte];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Random.Next(min, max);
            }
            return array;
        }

        public static double[] MaakRandomDoubleArray(int lengte, int min, int max)
        {            
            double[] array = new double[lengte];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Random.NextDouble() * (max - min) + min;
            }
            return array;
        }
    }

    public static class ArrayExtensions
    {
        public static void Print(this int[] array)
        {
            Console.WriteLine(String.Join(", ", array));
        }

        public static void Print(this double[] array)
        {
            Console.WriteLine(String.Join(", ", array));
        }
    }
}
