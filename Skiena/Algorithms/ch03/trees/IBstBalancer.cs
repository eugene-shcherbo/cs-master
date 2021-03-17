using System;
namespace Algorithms.ch03.trees
{
    public interface IBstBalancer
    {
        BinaryTreeNode<T>? CreateBalanced<T>(BinaryTreeNode<T>? bst);
    }
}
