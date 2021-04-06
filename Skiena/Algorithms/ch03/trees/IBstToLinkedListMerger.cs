using System.Collections.Generic;

namespace Algorithms.ch03.trees
{
    public interface IBstToLinkedListMerger
    {
        public LinkedList<T> MergeTrees<T>(BinaryTreeNode<T>? tree1, BinaryTreeNode<T>? tree2, IComparer<T> comparer);
    }
}