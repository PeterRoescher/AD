using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_12
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 9, 8, 4, 3, 8, 1, 1, 2, 8, 2, 1, 6, 0, 9, 8, 7, 0, 7, 3, 2, 1 };
            var array2D = Pixels1D_naar_2D(array);
            var array1D = Pixels2D_naar_1D(array2D);
        }

        public static int[,] Pixels1D_naar_2D(int[] pixels1d)
        {
            int width = 2;
            int height = (int)Math.Round((double)pixels1d.Length / width + 0.5);

            int[,] result = new int[height, width];

            //for (int i = 0, iHeight = 0; iHeight < height; iHeight++) // O(N²)
            //{
            //    for (int iWidth = 0; iWidth < width; iWidth++)
            //    {
            //        result[iWidth, iHeight] = pixels1d[i];
            //        i++;
            //    }
            //}

            int heightIndex = -1;
            for (int i = 0; i < pixels1d.Length; i++) // O(N)
            {
                int index = i % width;
                if (index == 0)
                {
                    heightIndex++;
                }

                result[heightIndex, index] = pixels1d[i];
            }

            return result;
        }

        static int[] Pixels2D_naar_1D(int[,] pixels2d)
        {
            int height = pixels2d.GetLength(0);
            int width = pixels2d.GetLength(1);

            int[] result = new int[height * width];

            int heightIndex = -1;
            for (int i = 0; i < result.Length; i++)
            {
                int index = i % width;
                if (index == 0)
                {
                    heightIndex++;
                }

                result[i] = pixels2d[heightIndex, index];
            }

            return result;
        }
    }
}
