using System;
using Algorithms.ch03.trees;

namespace Algorithms.ch03.interview
{
    public class BinaryTreeComparer
    {
        public bool AreIdentical<T>(BinaryTreeNode<T>? first, BinaryTreeNode<T>? second) where T : IEquatable<T>
        {
            if (first is null)
            {
                return second is null;
            }

            if (second is null)
            {
                return false;
            }

            if (!first.Data.Equals(second.Data))
            {
                return false;
            }

            return AreIdentical(first.Left, second.Left)
                && AreIdentical(first.Right, second.Right);
        }
    }
}
