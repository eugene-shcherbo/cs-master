using System;
using Algorithms.ch03.interview;
using Algorithms.ch03.trees;
using Xunit;

namespace UnitTests.ch03.interview
{
    public class BinaryTreeComparerTests
    {
        [Fact]
        public void DifferentSingleElementTrees()
        {
            var first = BinaryTreeNode.Create(1);
            var second = BinaryTreeNode.Create(5);

            Assert.False(GetComparer().AreIdentical(first, second));
        }

        [Fact]
        public void ReversedTrees()
        {
            var first = BinaryTreeNode.Create(10,
                BinaryTreeNode.Create(12, BinaryTreeNode.Create(13), BinaryTreeNode.Create(14)),
                BinaryTreeNode.Create(20));

            var second = BinaryTreeNode.Create(10,
                BinaryTreeNode.Create(20),
                BinaryTreeNode.Create(12, BinaryTreeNode.Create(14), BinaryTreeNode.Create(13)));

            Assert.False(GetComparer().AreIdentical(first, second));
        }

        [Fact]
        public void SameInStructureWithDifferentElements()
        {
            var first = BinaryTreeNode.Create(10,
                BinaryTreeNode.Create(12, BinaryTreeNode.Create(13), BinaryTreeNode.Create(14)),
                BinaryTreeNode.Create(20));

            var second = BinaryTreeNode.Create(10,
                BinaryTreeNode.Create(12, BinaryTreeNode.Create(13), BinaryTreeNode.Create(14)),
                BinaryTreeNode.Create(22));

            Assert.False(GetComparer().AreIdentical(first, second));
        }

        [Fact]
        public void SameTrees()
        {
            var first = BinaryTreeNode.Create(10,
                BinaryTreeNode.Create(12, BinaryTreeNode.Create(13), BinaryTreeNode.Create(14)),
                BinaryTreeNode.Create(20));

            var second = BinaryTreeNode.Create(10,
                BinaryTreeNode.Create(12, BinaryTreeNode.Create(13), BinaryTreeNode.Create(14)),
                BinaryTreeNode.Create(20));

            Assert.True(GetComparer().AreIdentical(first, second));
        }

        private BinaryTreeComparer GetComparer()
            => new();
    }
}
