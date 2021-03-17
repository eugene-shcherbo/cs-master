using System;
using System.Collections.Generic;

namespace Algorithms.ch03.trees
{
    public class RecursiveInOrderBstToLinkedListMerger : IBstToLinkedListMerger
    {
        public LinkedList<T> MergeTrees<T>(BinaryTreeNode<T>? tree1, BinaryTreeNode<T>? tree2, IComparer<T> comparer)
        {
            var tree1SortedElements = new List<T>();
            var tree2SortedElements = new List<T>();
            YieldElementsFromInOrderTraversal(tree1, tree1SortedElements);
            YieldElementsFromInOrderTraversal(tree2, tree2SortedElements);

            return MergeElements(tree1SortedElements, tree2SortedElements, comparer);
        }

        private static void YieldElementsFromInOrderTraversal<T>(BinaryTreeNode<T>? root, IList<T> elements)
        {
            if (root is not null)
            {
                YieldElementsFromInOrderTraversal(root.Left, elements);
                elements.Add(root.Data);
                YieldElementsFromInOrderTraversal(root.Right, elements);
            }
        }

        private static LinkedList<T> MergeElements<T>(IList<T> first, IList<T> second, IComparer<T> comparer)
        {
            int firstPointer = 0;
            int secondPointer = 0;
            LinkedList<T> sortedList = new();

            while (firstPointer < first.Count || secondPointer < second.Count)
            {
                if (firstPointer == first.Count)
                {
                    sortedList.AddLast(second[secondPointer]);
                    secondPointer++;
                }
                else if (secondPointer == second.Count)
                {
                    sortedList.AddLast(first[firstPointer]);
                    firstPointer++;
                }
                else if (comparer.Compare(first[firstPointer], second[secondPointer]) < 0)
                {
                    sortedList.AddLast(first[firstPointer]);
                    firstPointer++;
                }
                else
                {
                    sortedList.AddLast(second[secondPointer]);
                    secondPointer++;
                }
            }

            return sortedList;
        }
    }
}