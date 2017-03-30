using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDataStructures
{

    public class GeneralTree<T>
    {
        public TreeNode<T> Root { get; set; }

        public void PrintPreOrder()
        {
            Root.PrintPreOrder();
        }

        public int GetSize()
        {
            return Root.GetSize();
        }
    }
    public class TreeNode<T>
    {
        public TreeNode<T> FirstChild { get; set; }
        public TreeNode<T> NextSibling { get; set; }

        public T Data;

        public void PrintPreOrder()
        {
            Console.Write(this);
            FirstChild?.PrintPreOrder();
            NextSibling?.PrintPreOrder();
        }

        public int GetSize()
        {
            int size = 1;
            if (FirstChild != null) size += FirstChild.GetSize();
            if (NextSibling != null) size += NextSibling.GetSize();
            return size;
        }
    }
}
