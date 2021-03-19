using System;

namespace Algorithms.ch03.trees
{
    public class BinaryTreeNode<TData>
    {
        public TData Data { get; }

        public BinaryTreeNode<TData>? Right { get; }

        public BinaryTreeNode<TData>? Left { get; }

        public BinaryTreeNode(TData data, BinaryTreeNode<TData>? left = null, BinaryTreeNode<TData>? right = null)
        {
            Data = data;
            Left = left;
            Right = right;
        }
    }
}