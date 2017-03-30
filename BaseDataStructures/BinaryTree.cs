using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization.Configuration;

namespace BaseDataStructures
{
    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; set; }
        public bool IsEmpty { get { return Root == null; } }

        public int Size { get { return BinaryTreeNode<T>.Size(Root); } }
        public int Height { get { return BinaryTreeNode<T>.Height(Root); } }

        public BinaryTree() : this(default(T))
        {

        }

        public BinaryTree(T data)
        {
            if (!data.Equals(default(T)))
            {
                Root = new BinaryTreeNode<T>(data);
            }
        }

        public void Clear()
        {
            Root = null;
        }

        public void Merge(T rootItem, BinaryTree<T> tree1, BinaryTree<T> tree2)
        {
            if (tree1.Root == tree2.Root && tree1.Root != null) throw new ArgumentException("tree1 and tree2 cannot be the same tree");

            Root = new BinaryTreeNode<T>(rootItem, tree1.Root, tree2.Root);

            //Ensure that every node is in one tree
            if (this != tree1)
                tree1.Root = null;
            if (this != tree2)
                tree2.Root = null;
        }

        public void PrintPreOrder()
        {
            Root?.PrintPreOrder();
        }

        public void PrintInOrder()
        {
            Root?.PrintInOrder();
        }

        public void PrintPostOrder()
        {
            Root?.PrintPostOrder();
        }


    }

    public class BinaryTreeNode<T>
    {
        private T rootItem;
        private BinaryTreeNode<T> root1;
        private BinaryTreeNode<T> root2;

        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public T Data { get; private set; }

        public BinaryTreeNode(T data) : this(data, null, null) { }
        public BinaryTreeNode(T data, BinaryTreeNode<T> leftNode, BinaryTreeNode<T> rightNode)
        {
            Data = data;
            Left = leftNode;
            Right = rightNode;
        }

        public BinaryTreeNode<T> Duplicate()
        {
            BinaryTreeNode<T> root = new BinaryTreeNode<T>(Data, Left?.Duplicate(), Right?.Duplicate());
            return root;

        }

        public static int Size(BinaryTreeNode<T> node)
        {
            if (node == null) return 0;

            return 1 + Size(node.Left) + Size(node.Right);
        }

        public static int Height(BinaryTreeNode<T> node)
        {
            if (node == null) return -1;

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        public void PrintPreOrder()
        {
            Console.WriteLine(Data);
            Left?.PrintPreOrder();
            Right?.PrintPreOrder();
        }

        public void PrintInOrder()
        {
            Left?.PrintInOrder();
            Console.WriteLine(Data);
            Right?.PrintInOrder();
        }

        public void PrintPostOrder()
        {
            Left?.PrintPostOrder();
            Right?.PrintPostOrder();
            Console.WriteLine(Data);
        }

    }
}
