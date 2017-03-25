using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDataStructures;

namespace Opgave_9
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.AddFirst(7);
            list.AddFirst(6);
            list.AddFirst(5);
            list.AddFirst(4);
            list.AddFirst(3);
            list.AddFirst(2);
            list.AddFirst(1);
            list.AddFirst(0);
            list.Print();

            list.SwapSublist(0, 7);
            list.Print();
        }
    }

    public class LinkedList : LinkedList<int>
    {

        public void SwapSublist(int pos1, int pos2)
        {
            if (pos1 > pos2)
            {
                int tmp = pos2;
                pos2 = pos1;
                pos1 = tmp;
            }

            Node<int>[] swapNodes = new Node<int>[pos2 - pos1 + 3]; //also include previous node and node after last position
            Node<int> currentNode = _headerNode;
            for (int i = 0; i <= pos2 + 1; i++)
            {
                if (i >= pos1 - 1)
                {
                    swapNodes[i - pos1 + 1] = currentNode;
                }
                currentNode = currentNode?.NextNode;
            }

            for (int i = 1; i < swapNodes.Length / 2; i++)
            {                
                Node<int> previousFirstNode = swapNodes[i - 1];
                Node<int> previousLastNode = swapNodes[swapNodes.Length - i - 2];
                Node<int> firstNode = swapNodes[i];
                Node<int> lastNode = swapNodes[swapNodes.Length - i - 1];


                if (previousLastNode == firstNode)
                {
                    previousFirstNode.NextNode = lastNode;
                    lastNode.NextNode = firstNode;
                    firstNode.NextNode = swapNodes[i + 2];
                }
                else
                {
                    if (previousFirstNode == null)
                    {
                        _headerNode = lastNode;
                    }
                    else
                    {
                        previousFirstNode.NextNode = lastNode;
                    }

                    lastNode.NextNode = swapNodes[i + 1];
                    previousLastNode.NextNode = firstNode;
                    firstNode.NextNode = swapNodes[swapNodes.Length - i];

                    Node<int> tmp = swapNodes[i];
                    swapNodes[i] = swapNodes[swapNodes.Length - i - 1];
                    swapNodes[swapNodes.Length - i - 1] = tmp;
                }
            }
        }

        public void Swap(int pos1, int pos2)
        {
            if (pos1 > pos2)
            {
                int tmp = pos2;
                pos2 = pos1;
                pos1 = tmp;
            }

            Node<int> prevFirstPos = null;
            Node<int> prevSecondPos = null;
            Node<int> currentNode = _headerNode;

            for (int i = 0; i < pos2; i++)
            {
                if (i + 1 == pos1) prevFirstPos = currentNode;
                if (i + 1 == pos2) prevSecondPos = currentNode;

                currentNode = currentNode.NextNode;
            }

            if (prevFirstPos != null && prevSecondPos != null)
            {
                var first = prevFirstPos.NextNode;
                var second = prevSecondPos.NextNode;
                var tmp = second.NextNode;

                prevFirstPos.NextNode = second;
                second.NextNode = first.NextNode;
                prevSecondPos.NextNode = first;
                first.NextNode = tmp;
            }
        }
    }

}
