using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BaseDataStructures;

namespace Opgave_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 4, 5, 3, 2, 1, 1, 4, 8, 10, 12, 15, 18, 20 };

            LinkedList list = new LinkedList();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                list.AddFirst(input[i]);
            }

            double[] output = list.MovingAverage(4);
            Console.WriteLine(String.Join(", ", output));

            Console.WriteLine(list.CumulatieveSom(3));
        }

        public class LinkedList : LinkedList<int>
        {
            public double[] MovingAverage(int n)
            {
                double[] result = new double[Length];
                double subTotal = 0;
                Node<int> node = _headerNode;
                int i = 0;
                Queue<int> queue = new Queue<int>(Length);
                while (node != null)
                {
                    queue.Enqueue(node.Data);
                    subTotal += node.Data;
                    if (i < n)
                    {
                        result[i] = subTotal / (i + 1);
                    }
                    else
                    {
                        subTotal -= queue.Dequeue();
                        result[i] = subTotal / n;
                    }

                    node = node.NextNode;
                    i++;
                }

                return result;
            }

            public int CumulatieveSom(int index)
            {
                int i = 0;
                int result = 0;
                Node<int> node = _headerNode;
                while (node != null && i < index)
                {
                    result += node.Data;

                    node = node.NextNode;
                    i++;
                }
                return result;
            }
        }
    }
}
