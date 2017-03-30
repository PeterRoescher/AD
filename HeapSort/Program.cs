
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization.Configuration;
using BaseDataStructures;

namespace HeapSort
{


    class Program
    {
        static void Main(string[] args)
        {
            Heap<int> heap = new Heap<int>(4);
            Console.WriteLine($"Height (0): {heap.Height}");
            heap.Add(10);
            Console.WriteLine($"IsPerfect ({heap.Size}): {heap.IsPerfect}");
            Console.WriteLine($"Height (1): {heap.Height}");
            heap.Add(40);
            heap.Add(80);
            Console.WriteLine($"IsPerfect ({heap.Size}): {heap.IsPerfect}");
            Console.WriteLine($"Height (3): {heap.Height}");
            heap.Add(30);
            heap.Add(40);
            heap.Add(20);
            heap.Add(41);
            Console.WriteLine($"IsPerfect ({heap.Size}): {heap.IsPerfect}");
            Console.WriteLine($"Height (7): {heap.Height}");
            heap.Add(45);
            Console.WriteLine($"IsPerfect ({heap.Size}): {heap.IsPerfect}");
            Console.WriteLine($"Height (8): {heap.Height}");
            heap.Add(23);
            heap.Add(34);
            heap.Add(47);
            heap.Add(29);
            heap.Add(34);
            heap.Add(29);
            heap.Add(34);
            Console.WriteLine($"Height: {heap.Height}");
            Console.WriteLine($"Is Complete: {heap.IsComplete}");

            //heap.Add(4);
            //heap.Add(6);
            //heap.Add(8);
            //heap.Add(10);
            //heap.Add(12);
            //heap.Add(3);
            //heap.Add(1);
            //heap.Add(1);
            //heap.Add(2);
            //heap.Add(5);
            Console.WriteLine(heap);
            Console.WriteLine($"Dequeue: {heap.Remove()}");
            Console.WriteLine(heap);
            Console.WriteLine($"Dequeue: {heap.Remove()}");
            Console.WriteLine(heap);
            //Console.WriteLine($"Dequeue: {heap.Dequeue()}");
            //Console.WriteLine(heap);
            //Console.WriteLine($"Dequeue: {heap.Dequeue()}");
            //Console.WriteLine(heap);
            //Console.WriteLine($"Dequeue: {heap.Dequeue()}");
            //Console.WriteLine(heap);
            //Console.WriteLine($"Dequeue: {heap.Dequeue()}");
            //Console.WriteLine(heap);
            //Console.WriteLine($"Dequeue: {heap.Dequeue()}");
            //Console.WriteLine(heap);
            //Console.WriteLine($"Dequeue: {heap.Dequeue()}");
            //Console.WriteLine(heap);
            //Console.WriteLine($"Dequeue: {heap.Dequeue()}");
            //Console.WriteLine(heap);
        }
    }

    //public class Heap
    //{
    //    public int[] heap;
    //    public int size;

    //    public Heap(int initialSize)
    //    {
    //        heap = new int[initialSize];
    //        size = 1;
    //    }

    //    public void Add(int data)
    //    {
    //        heap[size++] = data;
    //        if (size == 2) return;

    //        int position = size - 1;
    //        int abovePosition = position / 2;
    //        while (abovePosition > 0 && heap[abovePosition] > heap[position])
    //        {
    //            int tmp = heap[abovePosition];
    //            heap[abovePosition] = heap[position];
    //            heap[position] = tmp;

    //            position = abovePosition;
    //            abovePosition = position / 2;
    //        }
    //    }

    //    public int Dequeue()
    //    {
    //        int result = heap[1];
    //        size--;
    //        heap[1] = heap[size];

    //        int position = 1;
    //        int left = position * 2 > size ? -1 : heap[position * 2];
    //        int right = position * 2 + 1 > size ? -1 : heap[position * 2 + 1];

    //        while (position < size && (heap[position] > left || heap[position] > right))
    //        {
    //            if (left < right)
    //            {
    //                int tmp = heap[position];
    //                heap[position] = left;
    //                heap[position * 2] = tmp;
    //                position = position * 2;
    //            }
    //            else
    //            {
    //                int tmp = heap[position];
    //                heap[position] = right;
    //                heap[position * 2 + 1] = tmp;
    //                position = position * 2 + 1;
    //            }

    //            if (position * 2 > size || position * 2 + 1 > size) break;
    //            left = heap[position * 2];
    //            right = heap[position * 2 + 1];
    //        }

    //        return result;
    //    }

    //    public override string ToString()
    //    {
    //        string result = String.Empty;
    //        for (int i = 1; i < size; i++)
    //        {
    //            result += $"{heap[i]}, ";
    //        }
    //        return result;
    //    }
    //}
}
