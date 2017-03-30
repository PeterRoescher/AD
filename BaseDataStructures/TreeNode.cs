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
    }
    public class TreeNode<T>
    {
        public TreeNode<T> FirstChild { get; set; }
        public TreeNode<T> NextSibling { get; set; }

        public T Data;


    }
}
