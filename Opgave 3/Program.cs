using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_3
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Add(6);
            bst.Add(2);
            bst.Add(1);
            bst.Add(4);
            bst.Add(3);
            bst.Add(8);
            //bst.Root = new BSTNode<int>(6);
            //bst.Root.Left = new BSTNode<int>(2);
            //bst.Root.Left.Left = new BSTNode<int>(1);
            //bst.Root.Left.Right = new BSTNode<int>(4);
            //bst.Root.Left.Right.Left = new BSTNode<int>(3);
            //bst.Root.Right = new BSTNode<int>(8);

            Console.WriteLine(bst);
        }

    }
    public class BinarySearchTree<T> where T : IComparable
    {
        public int Size { get; private set; }
        public int Depth { get; }
        public int Height { get; }

        public BSTNode<T> Root { get; set; }

        public void Add(T data)
        {
            BSTNode<T> newNode = new BSTNode<T>(data);
            if (Root == null)
            {
                Root = newNode;
                Size = 1;
            }
            else
            {
                BSTNode<T> currentNode = Root;
                BSTNode<T> nextNode = data.CompareTo(currentNode.Data) > 0 ? currentNode?.Right : currentNode?.Left;
                while (nextNode != null)
                {
                    currentNode = nextNode;
                    nextNode = data.CompareTo(currentNode.Data) > 0 ?  currentNode?.Right : currentNode?.Left;
                }

                int compareResult = data.CompareTo(currentNode.Data);
                if (compareResult > 0)
                {
                    currentNode.Right = newNode;
                    Size++;
                }
                else if (compareResult < 0)
                {
                    currentNode.Left = newNode;
                    Size++;
                }
                else
                {
                    throw new Exception("Cannot add same number twice");
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Number of items: {Size}");
            Root.PrintTree(4 , 0, sb);
            return sb.ToString();
        }
    }

    public class BSTNode<T>
    {
        public T Data { get; private set; }
        public BSTNode<T> Left { get; set; }
        public BSTNode<T> Right { get; set; }

        public BSTNode(T data)
        {
            Data = data;
        }

        public void PrintTree(int totalDepth, int currentDepth, StringBuilder sb)
        {
            string intend = String.Empty;
            for (int i = currentDepth; i < totalDepth / 2; i++)
            {
                intend += "\t";
            }
            sb.Append(intend + "  ");

            sb.AppendLine(Data.ToString());
            sb.Append(intend);
            if (Left != null)
            {
                sb.Append("/");
            }
            else
            {
                sb.Append(" ");
            }
            if (Right != null)
            {
                sb.Append("   \\");
            }
            sb.AppendLine();
            if (Left != null)
            {
                Left.PrintTree(totalDepth, currentDepth + 1, sb);
            }
            if (Right != null)
            {
                Right.PrintTree(totalDepth, currentDepth + 1, sb);
            }
        }
    }

}
