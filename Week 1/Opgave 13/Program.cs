using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_13
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[]
            {
                9, 8,
                4, 3,
                8, 1,
                1, 2, 8, 2, 1, 6, 0, 9, 8, 7, 0, 7, 3, 2
            };
            var array2D = Opgave_12.Program.Pixels1D_naar_2D(array);

            int dichstbijzijndeIndex = Dichtstbijzijnde(array2D, 4, 2, 10);
        }

        static int Dichtstbijzijnde(int[,] coords, int x, int y, double max)
        {
            int closestIndex = -1;
            int closesDiff = Int32.MaxValue;

            for (int i = 0; i < coords.GetLength(0); i++)
            {
                int coordY = coords[i, 0];
                int coordX = coords[i, 1];

                int diffX = coordX - x;
                int diffY = coordY - y;

                if (diffX < 0) diffX = -diffX;
                if (diffY < 0) diffY = -diffY;
            
                int diff = diffX + diffY;

                if (closesDiff > diff)
                {
                    closesDiff = diff;
                    closestIndex = i;
                }
            }
            return closestIndex;
        }
    }
}
