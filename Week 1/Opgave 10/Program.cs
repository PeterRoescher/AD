using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_10
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        static bool IsAanwezig(int[] array, int getal)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == getal) return true;
            }
            return false;
        }    }
}
