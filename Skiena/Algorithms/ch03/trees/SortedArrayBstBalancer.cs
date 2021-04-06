using System.Collections.Generic;

namespace Algorithms.ch03.trees
{
    public class SortedArrayBstBalancer : IBstBalancer
    {
        public BinaryTreeNode<T>? CreateBalanced<T>(BinaryTreeNode<T>? bst)
        {
            if (bst is null)
            {
                return null;
            }

            var sortedElements = new List<T>();
            YieldElementsFromInOrderTraversal(bst, sortedElements);

            return CreateBalancedBstFrom(sortedElements, 0, sortedElements.Count - 1);
        }

        private BinaryTreeNode<T>? CreateBalancedBstFrom<T>(IList<T> sortedElements, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;

            BinaryTreeNode<T> root = new(
                sortedElements[mid],
                CreateBalancedBstFrom(sortedElements, start, mid - 1),
                CreateBalancedBstFrom(sortedElements, mid + 1, end));

            return root;
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
    }
}
