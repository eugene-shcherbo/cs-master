using System;

namespace Algorithms.ch03.trees
{
    public class BinaryTreeNode<T>
    {
        public T Data { get; }

        public BinaryTreeNode<T>? Right { get; }

        public BinaryTreeNode<T>? Left { get; }

        public BinaryTreeNode(T data, BinaryTreeNode<T>? left, BinaryTreeNode<T>? right)
        {
            Data = data;
            Right = right;
            Left = left;
        }
    }
}